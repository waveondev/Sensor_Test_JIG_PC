using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ioT_JIG_PC
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;

        // PC UI 실시간 판정 변수
        private bool _isOffsetCalibrated = false;
        private long _pcOffsetValue = 0;
        private long _currentRawValue = 0;

        // 4개 센서 판정 유지(Latch) 변수 ("READY", "PASS", "FAIL")
        private string _lcDisplayStatus = "READY";
        private string _motorDisplayStatus = "READY";
        private string _leftIrDisplayStatus = "READY";
        private string _rightIrDisplayStatus = "READY";

        private const long PASS_THRESHOLD = 50000;
        private const long FAIL_THRESHOLD = -50000;

        // 센서별 통계 데이터 구조체
        private class SensorStat
        {
            public int Total = 0;
            public int Pass = 0;
            public int Fail = 0;

            public double DefectRate => Total > 0 ? ((double)Fail / Total) * 100.0 : 0.0;

            public void Reset()
            {
                Total = 0;
                Pass = 0;
                Fail = 0;
            }

            public void AddResult(bool isPass)
            {
                Total++;
                if (isPass) Pass++;
                else Fail++;
            }
        }

        private SensorStat _statLc = new SensorStat();
        private SensorStat _statMotor = new SensorStat();
        private SensorStat _statLeftIr = new SensorStat();
        private SensorStat _statRightIr = new SensorStat();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 버전 정보 (기본: 1.00.00)
            string version = "v1.00";

            // 현재 실행 파일(.exe)의 빌드/수정 날짜 자동 취득
            string buildDate = System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString("yyyy-MM-dd");

            // 폼 타이틀바 텍스트 설정
            this.Text = $"JIG Test Monitor {version} (Build: {buildDate})";

            string[] ports = SerialPort.GetPortNames();
            cmbPort.Items.AddRange(ports);

            if (cmbPort.Items.Contains("COM9"))
            {
                cmbPort.SelectedItem = "COM9";
            }
            else if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;
            }

            ResetTestSequence();
            UpdateAllStatsUI();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                if (cmbPort.SelectedItem == null)
                {
                    MessageBox.Show("COM 포트를 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedPort = cmbPort.SelectedItem.ToString();

                try
                {
                    _serialPort = new SerialPort(selectedPort, 115200, Parity.None, 8, StopBits.One);
                    _serialPort.DtrEnable = false;
                    _serialPort.RtsEnable = false;

                    _serialPort.DataReceived += SerialPort_DataReceived;
                    _serialPort.Open();

                    btnConnect.Text = "연결 해제";
                    lblStatus.Text = $"상태: {selectedPort} 연결됨";
                    lblStatus.ForeColor = Color.Blue;
                    cmbPort.Enabled = false;

                    ResetTestSequence();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"포트 열기 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                CloseSerialPort();
                btnConnect.Text = "연결";
                lblStatus.Text = "상태: 연결 끊김";
                lblStatus.ForeColor = Color.Black;
                cmbPort.Enabled = true;
            }
        }

        // [다음 검사 (기록 및 초기화)]: 선택된(체크된) 항목은 PASS가 아니면 무조건 FAIL로 통계 반영
        private void btnResetTest_Click(object sender, EventArgs e)
        {
            // 1. 로드셀 검사 체크 시: 영점을 안 잡았거나(WAIT OFFSET), 누르지 않았거나(READY), FAIL인 경우 모두 FAIL 처리
            if (chkTestLc.Checked)
            {
                bool isLcPass = (_isOffsetCalibrated && _lcDisplayStatus == "PASS");
                _statLc.AddResult(isLcPass);
            }

            // 2. 모터 검사 체크 시: 오직 확정된 PASS일 때만 통과, 미연결/대기/FAIL은 불합격(FAIL)
            if (chkTestMotor.Checked)
            {
                bool isMotorPass = (_motorDisplayStatus == "PASS");
                _statMotor.AddResult(isMotorPass);
            }

            // 3. LEFT IR 검사 체크 시: 오직 PASS일 때만 통과, 그 외(대기, 미연결, FAIL)는 불합격(FAIL)
            if (chkTestLeftIr.Checked)
            {
                bool isLeftIrPass = (_leftIrDisplayStatus == "PASS");
                _statLeftIr.AddResult(isLeftIrPass);
            }

            // 4. RIGHT IR 검사 체크 시: 오직 PASS일 때만 통과, 그 외는 불합격(FAIL)
            if (chkTestRightIr.Checked)
            {
                bool isRightIrPass = (_rightIrDisplayStatus == "PASS");
                _statRightIr.AddResult(isRightIrPass);
            }

            UpdateAllStatsUI();
            ResetTestSequence();
        }

        private void ResetTestSequence()
        {
            _isOffsetCalibrated = false;
            _pcOffsetValue = 0;

            // 판정 변수 초기화
            _lcDisplayStatus = "READY";
            _motorDisplayStatus = "READY";
            _leftIrDisplayStatus = "READY";
            _rightIrDisplayStatus = "READY";

            lblOffsetVal.Text = "OFFSET : 없음 (리셋됨)";
            lblDeltaVal.Text = "가압량 (차이) : -";

            if (chkTestLc.Checked)
            {
                lblPassFail.Text = "WAIT OFFSET";
                lblPassFail.BackColor = Color.Goldenrod;
                lblPassFail.ForeColor = Color.White;
            }
            else
            {
                lblPassFail.Text = "검사 제외";
                lblPassFail.BackColor = Color.DimGray;
                lblPassFail.ForeColor = Color.White;
            }

            // 센서 판정 배지 초기화
            UpdateBadge(lblMotorStatus, chkTestMotor.Checked ? "대기" : "제외", chkTestMotor.Checked ? Color.LightGray : Color.DimGray, chkTestMotor.Checked ? Color.Black : Color.White);
            UpdateBadge(lblLeftIrStatus, chkTestLeftIr.Checked ? "대기" : "제외", chkTestLeftIr.Checked ? Color.LightGray : Color.DimGray, chkTestLeftIr.Checked ? Color.Black : Color.White);
            UpdateBadge(lblRightIrStatus, chkTestRightIr.Checked ? "대기" : "제외", chkTestRightIr.Checked ? Color.LightGray : Color.DimGray, chkTestRightIr.Checked ? Color.Black : Color.White);
        }

        private void UpdateAllStatsUI()
        {
            lblLcStats.Text = $"총: {_statLc.Total}회 | 불량: {_statLc.DefectRate:F1}%\r\nPASS: {_statLc.Pass}회\r\nFAIL: {_statLc.Fail}회";
            lblMotorStats.Text = $"총: {_statMotor.Total}회 | 불량: {_statMotor.DefectRate:F1}%\r\nPASS: {_statMotor.Pass}회\r\nFAIL: {_statMotor.Fail}회";
            lblLeftIrStats.Text = $"총: {_statLeftIr.Total}회 | 불량: {_statLeftIr.DefectRate:F1}%\r\nPASS: {_statLeftIr.Pass}회\r\nFAIL: {_statLeftIr.Fail}회";
            lblRightIrStats.Text = $"총: {_statRightIr.Total}회 | 불량: {_statRightIr.DefectRate:F1}%\r\nPASS: {_statRightIr.Pass}회\r\nFAIL: {_statRightIr.Fail}회";
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV 파일 (*.csv)|*.csv|모든 파일 (*.*)|*.*";
                sfd.FileName = $"JIG_검사통계_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.Title = "검사 통계 내보내기";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("검사항목,총검사수,합격(PASS),불합격(FAIL),불량률(%),적용여부");
                        sb.AppendLine($"로드셀,{_statLc.Total},{_statLc.Pass},{_statLc.Fail},{_statLc.DefectRate:F1}%,{(chkTestLc.Checked ? "적용" : "제외")}");
                        sb.AppendLine($"모터,{_statMotor.Total},{_statMotor.Pass},{_statMotor.Fail},{_statMotor.DefectRate:F1}%,{(chkTestMotor.Checked ? "적용" : "제외")}");
                        sb.AppendLine($"LEFT IR,{_statLeftIr.Total},{_statLeftIr.Pass},{_statLeftIr.Fail},{_statLeftIr.DefectRate:F1}%,{(chkTestLeftIr.Checked ? "적용" : "제외")}");
                        sb.AppendLine($"RIGHT IR,{_statRightIr.Total},{_statRightIr.Pass},{_statRightIr.Fail},{_statRightIr.DefectRate:F1}%,{(chkTestRightIr.Checked ? "적용" : "제외")}");
                        sb.AppendLine();
                        sb.AppendLine($"내보낸시간,{DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("검사 통계가 성공적으로 저장되었습니다.\n" + sfd.FileName, "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"파일 저장 중 오류가 발생했습니다: {ex.Message}", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClearAllStats_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("모든 센서의 통계를 초기화하시겠습니까?", "전체 초기화", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _statLc.Reset();
                _statMotor.Reset();
                _statLeftIr.Reset();
                _statRightIr.Reset();
                UpdateAllStatsUI();
            }
        }

        private void btnClearLcStats_Click(object sender, EventArgs e)
        {
            _statLc.Reset();
            UpdateAllStatsUI();
        }

        private void btnClearMotorStats_Click(object sender, EventArgs e)
        {
            _statMotor.Reset();
            UpdateAllStatsUI();
        }

        private void btnClearLeftIrStats_Click(object sender, EventArgs e)
        {
            _statLeftIr.Reset();
            UpdateAllStatsUI();
        }

        private void btnClearRightIrStats_Click(object sender, EventArgs e)
        {
            _statRightIr.Reset();
            UpdateAllStatsUI();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen) return;

            try
            {
                while (_serialPort.BytesToRead > 0)
                {
                    string line = _serialPort.ReadLine();
                    this.BeginInvoke(new Action(() => ParseAndDisplay(line)));
                }
            }
            catch (Exception)
            {
            }
        }

        private void ParseAndDisplay(string rawLine)
        {
            if (string.IsNullOrWhiteSpace(rawLine)) return;

            string cleanLine = Regex.Replace(rawLine, @"\x1B\[[^@-~]*[@-~]", "").Trim();

            // 1. LOADCELL RAW 수신[cite: 1]
            if (cleanLine.Contains("LOADCELL VALUE :"))
            {
                Match match = Regex.Match(cleanLine, @"LOADCELL VALUE\s*:\s*(-?\d+)");
                if (match.Success)
                {
                    if (long.TryParse(match.Groups[1].Value, out long parsedVal))
                    {
                        _currentRawValue = parsedVal;
                        lblLoadcellVal.Text = $"현재 RAW : {_currentRawValue}";
                        UpdateLoadcellJudgement();
                    }
                }
            }
            // 2. 하드웨어 영점 버튼 감지[cite: 1]
            else if (cleanLine.Contains("LOADCELL OFFSET :"))
            {
                Match match = Regex.Match(cleanLine, @"LOADCELL OFFSET\s*:\s*(-?\d+)\s*,\s*(true|false)");
                if (match.Success)
                {
                    bool btnPressed = bool.Parse(match.Groups[2].Value);
                    lblBtnState.Text = btnPressed ? "버튼 입력 : 눌림 (ON)" : "버튼 입력 : 미입력 (OFF)";
                    lblBtnState.ForeColor = btnPressed ? Color.Red : Color.Black;

                    if (btnPressed)
                    {
                        _pcOffsetValue = _currentRawValue;
                        _isOffsetCalibrated = true;
                        _lcDisplayStatus = "READY";

                        lblOffsetVal.Text = $"OFFSET : {_pcOffsetValue} (설정됨)";
                        UpdateLoadcellJudgement();
                    }
                }
            }
            // 3. ADC 센서 값 수신 및 판정[cite: 1]
            else if (cleanLine.Contains("MOTOR ADC :"))
            {
                Match match = Regex.Match(cleanLine, @"MOTOR ADC\s*:\s*(\d+),\s*LEFT IR ADC\s*:\s*(\d+),\s*RIGHT IR ADC\s*:\s*(\d+)");
                if (match.Success)
                {
                    int motor = int.Parse(match.Groups[1].Value);
                    int leftIr = int.Parse(match.Groups[2].Value);
                    int rightIr = int.Parse(match.Groups[3].Value);

                    lblMotorAdc.Text = $"MOTOR : {motor}";
                    lblLeftIrAdc.Text = $"LEFT IR : {leftIr}";
                    lblRightIrAdc.Text = $"RIGHT IR : {rightIr}";

                    // (1) 모터 판정 (220 ~ 260 PASS, 초과/미달 시 FAIL)
                    if (!chkTestMotor.Checked)
                    {
                        _motorDisplayStatus = "제외";
                        UpdateBadge(lblMotorStatus, "제외", Color.DimGray, Color.White);
                    }
                    else
                    {
                        if (motor >= 220 && motor <= 260)
                        {
                            _motorDisplayStatus = "PASS";
                            UpdateBadge(lblMotorStatus, "PASS", Color.DeepSkyBlue, Color.White);
                        }
                        else if (motor > 10)
                        {
                            _motorDisplayStatus = "FAIL";
                            UpdateBadge(lblMotorStatus, "FAIL", Color.Crimson, Color.White);
                        }
                        else
                        {
                            // 10 이하 (미연결)
                            _motorDisplayStatus = "FAIL";
                            UpdateBadge(lblMotorStatus, "미연결", Color.DarkOrange, Color.White);
                        }
                    }

                    // (2) LEFT IR 판정 (3000 이상 PASS, 미연결 시 FAIL)
                    if (!chkTestLeftIr.Checked)
                    {
                        _leftIrDisplayStatus = "제외";
                        UpdateBadge(lblLeftIrStatus, "제외", Color.DimGray, Color.White);
                    }
                    else
                    {
                        UpdateIrSensor(lblLeftIrStatus, leftIr, ref _leftIrDisplayStatus);
                    }

                    // (3) RIGHT IR 판정 (3000 이상 PASS, 미연결 시 FAIL)
                    if (!chkTestRightIr.Checked)
                    {
                        _rightIrDisplayStatus = "제외";
                        UpdateBadge(lblRightIrStatus, "제외", Color.DimGray, Color.White);
                    }
                    else
                    {
                        UpdateIrSensor(lblRightIrStatus, rightIr, ref _rightIrDisplayStatus);
                    }
                }
            }
        }

        // IR 센서 판정 (PASS/FAIL 도달 시 상태 유지 Latch 적용)
        private void UpdateIrSensor(Label lbl, int adcVal, ref string statusVar)
        {
            if (adcVal >= 3000)
            {
                statusVar = "PASS";
                UpdateBadge(lbl, "PASS", Color.DeepSkyBlue, Color.White);
            }
            else if (adcVal <= 10)
            {
                statusVar = "FAIL";
                UpdateBadge(lbl, "미연결", Color.DarkOrange, Color.White);
            }
            else
            {
                // 이전 판정 이력이 이미 PASS인 경우 유지, 아니라면 READY 표시
                if (statusVar == "PASS")
                {
                    UpdateBadge(lbl, "PASS", Color.DeepSkyBlue, Color.White);
                }
                else if (adcVal <= 2000)
                {
                    statusVar = "READY";
                    UpdateBadge(lbl, "READY", Color.LightGray, Color.Black);
                }
                else
                {
                    statusVar = "측정중";
                    UpdateBadge(lbl, "측정중", Color.Goldenrod, Color.White);
                }
            }
        }

        private void UpdateLoadcellJudgement()
        {
            if (!chkTestLc.Checked)
            {
                lblPassFail.Text = "검사 제외";
                lblPassFail.BackColor = Color.DimGray;
                lblPassFail.ForeColor = Color.White;
                lblDeltaVal.Text = "가압량 (차이) : 검사 제외됨";
                return;
            }

            if (!_isOffsetCalibrated)
            {
                lblPassFail.Text = "WAIT OFFSET";
                lblPassFail.BackColor = Color.Goldenrod;
                lblPassFail.ForeColor = Color.White;
                lblDeltaVal.Text = "가압량 (차이) : 영점 필요";
                return;
            }

            long delta = _currentRawValue - _pcOffsetValue;
            lblDeltaVal.Text = $"가압량 (차이) : {delta:+0;-0;0}";

            if (delta >= PASS_THRESHOLD)
            {
                _lcDisplayStatus = "PASS";
            }
            else if (delta <= FAIL_THRESHOLD)
            {
                _lcDisplayStatus = "FAIL";
            }

            if (_lcDisplayStatus == "PASS")
            {
                lblPassFail.Text = "PASS";
                lblPassFail.BackColor = Color.DeepSkyBlue;
                lblPassFail.ForeColor = Color.White;
            }
            else if (_lcDisplayStatus == "FAIL")
            {
                lblPassFail.Text = "FAIL";
                lblPassFail.BackColor = Color.Crimson;
                lblPassFail.ForeColor = Color.White;
            }
            else
            {
                lblPassFail.Text = "READY";
                lblPassFail.BackColor = Color.LightGray;
                lblPassFail.ForeColor = Color.Black;
            }
        }

        private void UpdateBadge(Label lbl, string text, Color backColor, Color foreColor)
        {
            lbl.Text = text;
            lbl.BackColor = backColor;
            lbl.ForeColor = foreColor;
        }

        private void CloseSerialPort()
        {
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= SerialPort_DataReceived;
                    _serialPort.Close();
                }
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSerialPort();
        }
    }
}