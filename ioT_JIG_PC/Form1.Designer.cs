namespace ioT_JIG_PC
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.grpConn = new System.Windows.Forms.GroupBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpLoadcell = new System.Windows.Forms.GroupBox();
            this.chkTestLc = new System.Windows.Forms.CheckBox();
            this.lblPassFail = new System.Windows.Forms.Label();
            this.lblLoadcellVal = new System.Windows.Forms.Label();
            this.lblDeltaVal = new System.Windows.Forms.Label();
            this.lblOffsetVal = new System.Windows.Forms.Label();
            this.lblBtnState = new System.Windows.Forms.Label();
            this.grpAdc = new System.Windows.Forms.GroupBox();
            this.chkTestMotor = new System.Windows.Forms.CheckBox();
            this.chkTestLeftIr = new System.Windows.Forms.CheckBox();
            this.chkTestRightIr = new System.Windows.Forms.CheckBox();
            this.lblMotorAdc = new System.Windows.Forms.Label();
            this.lblMotorStatus = new System.Windows.Forms.Label();
            this.lblLeftIrAdc = new System.Windows.Forms.Label();
            this.lblLeftIrStatus = new System.Windows.Forms.Label();
            this.lblRightIrAdc = new System.Windows.Forms.Label();
            this.lblRightIrStatus = new System.Windows.Forms.Label();
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.btnClearAllStats = new System.Windows.Forms.Button();
            this.grpStatLoadcell = new System.Windows.Forms.GroupBox();
            this.lblLcStats = new System.Windows.Forms.Label();
            this.btnClearLcStats = new System.Windows.Forms.Button();
            this.grpStatMotor = new System.Windows.Forms.GroupBox();
            this.lblMotorStats = new System.Windows.Forms.Label();
            this.btnClearMotorStats = new System.Windows.Forms.Button();
            this.grpStatLeftIr = new System.Windows.Forms.GroupBox();
            this.lblLeftIrStats = new System.Windows.Forms.Label();
            this.btnClearLeftIrStats = new System.Windows.Forms.Button();
            this.grpStatRightIr = new System.Windows.Forms.GroupBox();
            this.lblRightIrStats = new System.Windows.Forms.Label();
            this.btnClearRightIrStats = new System.Windows.Forms.Button();
            this.grpGuide = new System.Windows.Forms.GroupBox();
            this.txtCriteria = new System.Windows.Forms.TextBox();
            this.txtGuide = new System.Windows.Forms.TextBox();
            this.btnResetTest = new System.Windows.Forms.Button();
            this.grpConn.SuspendLayout();
            this.grpLoadcell.SuspendLayout();
            this.grpAdc.SuspendLayout();
            this.grpStats.SuspendLayout();
            this.grpStatLoadcell.SuspendLayout();
            this.grpStatMotor.SuspendLayout();
            this.grpStatLeftIr.SuspendLayout();
            this.grpStatRightIr.SuspendLayout();
            this.grpGuide.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpConn
            // 
            this.grpConn.Controls.Add(this.cmbPort);
            this.grpConn.Controls.Add(this.btnConnect);
            this.grpConn.Controls.Add(this.lblStatus);
            this.grpConn.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.grpConn.Location = new System.Drawing.Point(16, 12);
            this.grpConn.Name = "grpConn";
            this.grpConn.Size = new System.Drawing.Size(640, 85);
            this.grpConn.TabIndex = 0;
            this.grpConn.TabStop = false;
            this.grpConn.Text = "시리얼 통신 설정 (115200 bps)";

            // 
            // cmbPort
            // 
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.Font = new System.Drawing.Font("맑은 고딕", 13.5F);
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(18, 33);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(160, 33);
            this.cmbPort.TabIndex = 0;

            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnConnect.Location = new System.Drawing.Point(195, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 38);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lblStatus.Location = new System.Drawing.Point(335, 37);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(130, 25);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "상태: 연결 끊김";

            // 
            // grpLoadcell
            // 
            this.grpLoadcell.Controls.Add(this.chkTestLc);
            this.grpLoadcell.Controls.Add(this.lblPassFail);
            this.grpLoadcell.Controls.Add(this.lblLoadcellVal);
            this.grpLoadcell.Controls.Add(this.lblDeltaVal);
            this.grpLoadcell.Controls.Add(this.lblOffsetVal);
            this.grpLoadcell.Controls.Add(this.lblBtnState);
            this.grpLoadcell.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.grpLoadcell.Location = new System.Drawing.Point(16, 108);
            this.grpLoadcell.Name = "grpLoadcell";
            this.grpLoadcell.Size = new System.Drawing.Size(640, 305);
            this.grpLoadcell.TabIndex = 1;
            this.grpLoadcell.TabStop = false;
            this.grpLoadcell.Text = "LOADCELL 단품 검사";

            // 
            // chkTestLc
            // 
            this.chkTestLc.AutoSize = true;
            this.chkTestLc.Checked = true;
            this.chkTestLc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestLc.Font = new System.Drawing.Font("맑은 고딕", 11.5F, System.Drawing.FontStyle.Bold);
            this.chkTestLc.ForeColor = System.Drawing.Color.Navy;
            this.chkTestLc.Location = new System.Drawing.Point(460, 0);
            this.chkTestLc.Name = "chkTestLc";
            this.chkTestLc.Size = new System.Drawing.Size(163, 25);
            this.chkTestLc.TabIndex = 6;
            this.chkTestLc.Text = "[✓] 로드셀 검사 적용";
            this.chkTestLc.UseVisualStyleBackColor = true;

            // 
            // lblPassFail
            // 
            this.lblPassFail.BackColor = System.Drawing.Color.Goldenrod;
            this.lblPassFail.Font = new System.Drawing.Font("맑은 고딕", 27F, System.Drawing.FontStyle.Bold);
            this.lblPassFail.ForeColor = System.Drawing.Color.White;
            this.lblPassFail.Location = new System.Drawing.Point(18, 35);
            this.lblPassFail.Name = "lblPassFail";
            this.lblPassFail.Size = new System.Drawing.Size(270, 245);
            this.lblPassFail.TabIndex = 0;
            this.lblPassFail.Text = "WAIT OFFSET";
            this.lblPassFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblLoadcellVal
            // 
            this.lblLoadcellVal.AutoSize = true;
            this.lblLoadcellVal.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lblLoadcellVal.Location = new System.Drawing.Point(305, 45);
            this.lblLoadcellVal.Name = "lblLoadcellVal";
            this.lblLoadcellVal.Size = new System.Drawing.Size(147, 28);
            this.lblLoadcellVal.TabIndex = 1;
            this.lblLoadcellVal.Text = "현재 RAW : -";

            // 
            // lblOffsetVal
            // 
            this.lblOffsetVal.AutoSize = true;
            this.lblOffsetVal.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lblOffsetVal.Location = new System.Drawing.Point(305, 105);
            this.lblOffsetVal.Name = "lblOffsetVal";
            this.lblOffsetVal.Size = new System.Drawing.Size(235, 28);
            this.lblOffsetVal.TabIndex = 2;
            this.lblOffsetVal.Text = "OFFSET : 없음 (리셋됨)";

            // 
            // lblDeltaVal
            // 
            this.lblDeltaVal.AutoSize = true;
            this.lblDeltaVal.Font = new System.Drawing.Font("맑은 고딕", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblDeltaVal.Location = new System.Drawing.Point(305, 165);
            this.lblDeltaVal.Name = "lblDeltaVal";
            this.lblDeltaVal.Size = new System.Drawing.Size(188, 30);
            this.lblDeltaVal.TabIndex = 4;
            this.lblDeltaVal.Text = "가압량 (차이) : -";

            // 
            // lblBtnState
            // 
            this.lblBtnState.AutoSize = true;
            this.lblBtnState.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lblBtnState.Location = new System.Drawing.Point(305, 225);
            this.lblBtnState.Name = "lblBtnState";
            this.lblBtnState.Size = new System.Drawing.Size(201, 28);
            this.lblBtnState.TabIndex = 3;
            this.lblBtnState.Text = "버튼 입력 : 미입력";

            // 
            // grpAdc
            // 
            this.grpAdc.Controls.Add(this.chkTestMotor);
            this.grpAdc.Controls.Add(this.chkTestLeftIr);
            this.grpAdc.Controls.Add(this.chkTestRightIr);
            this.grpAdc.Controls.Add(this.lblMotorAdc);
            this.grpAdc.Controls.Add(this.lblMotorStatus);
            this.grpAdc.Controls.Add(this.lblLeftIrAdc);
            this.grpAdc.Controls.Add(this.lblLeftIrStatus);
            this.grpAdc.Controls.Add(this.lblRightIrAdc);
            this.grpAdc.Controls.Add(this.lblRightIrStatus);
            this.grpAdc.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.grpAdc.Location = new System.Drawing.Point(16, 425);
            this.grpAdc.Name = "grpAdc";
            this.grpAdc.Size = new System.Drawing.Size(640, 165);
            this.grpAdc.TabIndex = 2;
            this.grpAdc.TabStop = false;
            this.grpAdc.Text = "센서 ADC 및 연결/판정 상태";

            // 
            // chkTestMotor
            // 
            this.chkTestMotor.AutoSize = true;
            this.chkTestMotor.Checked = true;
            this.chkTestMotor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestMotor.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.chkTestMotor.ForeColor = System.Drawing.Color.Navy;
            this.chkTestMotor.Location = new System.Drawing.Point(18, 28);
            this.chkTestMotor.Name = "chkTestMotor";
            this.chkTestMotor.Size = new System.Drawing.Size(124, 23);
            this.chkTestMotor.TabIndex = 6;
            this.chkTestMotor.Text = "[✓] 모터 검사";
            this.chkTestMotor.UseVisualStyleBackColor = true;

            // 
            // chkTestLeftIr
            // 
            this.chkTestLeftIr.AutoSize = true;
            this.chkTestLeftIr.Checked = true;
            this.chkTestLeftIr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestLeftIr.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.chkTestLeftIr.ForeColor = System.Drawing.Color.Navy;
            this.chkTestLeftIr.Location = new System.Drawing.Point(225, 28);
            this.chkTestLeftIr.Name = "chkTestLeftIr";
            this.chkTestLeftIr.Size = new System.Drawing.Size(133, 23);
            this.chkTestLeftIr.TabIndex = 7;
            this.chkTestLeftIr.Text = "[✓] LEFT IR 검사";
            this.chkTestLeftIr.UseVisualStyleBackColor = true;

            // 
            // chkTestRightIr
            // 
            this.chkTestRightIr.AutoSize = true;
            this.chkTestRightIr.Checked = true;
            this.chkTestRightIr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestRightIr.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.chkTestRightIr.ForeColor = System.Drawing.Color.Navy;
            this.chkTestRightIr.Location = new System.Drawing.Point(432, 28);
            this.chkTestRightIr.Name = "chkTestRightIr";
            this.chkTestRightIr.Size = new System.Drawing.Size(146, 23);
            this.chkTestRightIr.TabIndex = 8;
            this.chkTestRightIr.Text = "[✓] RIGHT IR 검사";
            this.chkTestRightIr.UseVisualStyleBackColor = true;

            // 
            // lblMotorAdc
            // 
            this.lblMotorAdc.Font = new System.Drawing.Font("맑은 고딕", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblMotorAdc.Location = new System.Drawing.Point(18, 55);
            this.lblMotorAdc.Name = "lblMotorAdc";
            this.lblMotorAdc.Size = new System.Drawing.Size(190, 28);
            this.lblMotorAdc.TabIndex = 0;
            this.lblMotorAdc.Text = "MOTOR : -";

            // 
            // lblMotorStatus
            // 
            this.lblMotorStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblMotorStatus.Font = new System.Drawing.Font("맑은 고딕", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblMotorStatus.ForeColor = System.Drawing.Color.Black;
            this.lblMotorStatus.Location = new System.Drawing.Point(18, 88);
            this.lblMotorStatus.Name = "lblMotorStatus";
            this.lblMotorStatus.Size = new System.Drawing.Size(190, 55);
            this.lblMotorStatus.TabIndex = 1;
            this.lblMotorStatus.Text = "대기";
            this.lblMotorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblLeftIrAdc
            // 
            this.lblLeftIrAdc.Font = new System.Drawing.Font("맑은 고딕", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblLeftIrAdc.Location = new System.Drawing.Point(225, 55);
            this.lblLeftIrAdc.Name = "lblLeftIrAdc";
            this.lblLeftIrAdc.Size = new System.Drawing.Size(190, 28);
            this.lblLeftIrAdc.TabIndex = 2;
            this.lblLeftIrAdc.Text = "LEFT IR : -";

            // 
            // lblLeftIrStatus
            // 
            this.lblLeftIrStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblLeftIrStatus.Font = new System.Drawing.Font("맑은 고딕", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblLeftIrStatus.ForeColor = System.Drawing.Color.Black;
            this.lblLeftIrStatus.Location = new System.Drawing.Point(225, 88);
            this.lblLeftIrStatus.Name = "lblLeftIrStatus";
            this.lblLeftIrStatus.Size = new System.Drawing.Size(190, 55);
            this.lblLeftIrStatus.TabIndex = 3;
            this.lblLeftIrStatus.Text = "대기";
            this.lblLeftIrStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblRightIrAdc
            // 
            this.lblRightIrAdc.Font = new System.Drawing.Font("맑은 고딕", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblRightIrAdc.Location = new System.Drawing.Point(432, 55);
            this.lblRightIrAdc.Name = "lblRightIrAdc";
            this.lblRightIrAdc.Size = new System.Drawing.Size(190, 28);
            this.lblRightIrAdc.TabIndex = 4;
            this.lblRightIrAdc.Text = "RIGHT IR : -";

            // 
            // lblRightIrStatus
            // 
            this.lblRightIrStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblRightIrStatus.Font = new System.Drawing.Font("맑은 고딕", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblRightIrStatus.ForeColor = System.Drawing.Color.Black;
            this.lblRightIrStatus.Location = new System.Drawing.Point(432, 88);
            this.lblRightIrStatus.Name = "lblRightIrStatus";
            this.lblRightIrStatus.Size = new System.Drawing.Size(190, 55);
            this.lblRightIrStatus.TabIndex = 5;
            this.lblRightIrStatus.Text = "대기";
            this.lblRightIrStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // grpStats
            // 
            this.grpStats.Controls.Add(this.btnExportCsv);
            this.grpStats.Controls.Add(this.btnClearAllStats);
            this.grpStats.Controls.Add(this.grpStatLoadcell);
            this.grpStats.Controls.Add(this.grpStatMotor);
            this.grpStats.Controls.Add(this.grpStatLeftIr);
            this.grpStats.Controls.Add(this.grpStatRightIr);
            this.grpStats.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.grpStats.Location = new System.Drawing.Point(672, 12);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(530, 275);
            this.grpStats.TabIndex = 3;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "선택 품목 검사 통계 현황";

            // 
            // btnExportCsv
            // 
            this.btnExportCsv.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportCsv.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportCsv.ForeColor = System.Drawing.Color.White;
            this.btnExportCsv.Location = new System.Drawing.Point(235, 18);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(140, 32);
            this.btnExportCsv.TabIndex = 5;
            this.btnExportCsv.Text = "통계 저장 (CSV)";
            this.btnExportCsv.UseVisualStyleBackColor = false;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);

            // 
            // btnClearAllStats
            // 
            this.btnClearAllStats.BackColor = System.Drawing.Color.LightCoral;
            this.btnClearAllStats.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearAllStats.ForeColor = System.Drawing.Color.White;
            this.btnClearAllStats.Location = new System.Drawing.Point(385, 18);
            this.btnClearAllStats.Name = "btnClearAllStats";
            this.btnClearAllStats.Size = new System.Drawing.Size(130, 32);
            this.btnClearAllStats.TabIndex = 4;
            this.btnClearAllStats.Text = "전체 초기화";
            this.btnClearAllStats.UseVisualStyleBackColor = false;
            this.btnClearAllStats.Click += new System.EventHandler(this.btnClearAllStats_Click);

            // 
            // grpStatLoadcell
            // 
            this.grpStatLoadcell.Controls.Add(this.lblLcStats);
            this.grpStatLoadcell.Controls.Add(this.btnClearLcStats);
            this.grpStatLoadcell.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.grpStatLoadcell.Location = new System.Drawing.Point(12, 50);
            this.grpStatLoadcell.Name = "grpStatLoadcell";
            this.grpStatLoadcell.Size = new System.Drawing.Size(245, 105);
            this.grpStatLoadcell.TabIndex = 0;
            this.grpStatLoadcell.TabStop = false;
            this.grpStatLoadcell.Text = "■ 로드셀 통계";

            // 
            // lblLcStats
            // 
            this.lblLcStats.Font = new System.Drawing.Font("맑은 고딕", 9.5F);
            this.lblLcStats.Location = new System.Drawing.Point(8, 22);
            this.lblLcStats.Name = "lblLcStats";
            this.lblLcStats.Size = new System.Drawing.Size(155, 75);
            this.lblLcStats.TabIndex = 0;
            this.lblLcStats.Text = "총: 0회 | 불량: 0.0%\r\nPASS: 0회\r\nFAIL: 0회";

            // 
            // btnClearLcStats
            // 
            this.btnClearLcStats.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.btnClearLcStats.Location = new System.Drawing.Point(168, 42);
            this.btnClearLcStats.Name = "btnClearLcStats";
            this.btnClearLcStats.Size = new System.Drawing.Size(70, 30);
            this.btnClearLcStats.TabIndex = 1;
            this.btnClearLcStats.Text = "초기화";
            this.btnClearLcStats.UseVisualStyleBackColor = true;
            this.btnClearLcStats.Click += new System.EventHandler(this.btnClearLcStats_Click);

            // 
            // grpStatMotor
            // 
            this.grpStatMotor.Controls.Add(this.lblMotorStats);
            this.grpStatMotor.Controls.Add(this.btnClearMotorStats);
            this.grpStatMotor.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.grpStatMotor.Location = new System.Drawing.Point(270, 50);
            this.grpStatMotor.Name = "grpStatMotor";
            this.grpStatMotor.Size = new System.Drawing.Size(245, 105);
            this.grpStatMotor.TabIndex = 1;
            this.grpStatMotor.TabStop = false;
            this.grpStatMotor.Text = "■ MOTOR 통계";

            // 
            // lblMotorStats
            // 
            this.lblMotorStats.Font = new System.Drawing.Font("맑은 고딕", 9.5F);
            this.lblMotorStats.Location = new System.Drawing.Point(8, 22);
            this.lblMotorStats.Name = "lblMotorStats";
            this.lblMotorStats.Size = new System.Drawing.Size(155, 75);
            this.lblMotorStats.TabIndex = 0;
            this.lblMotorStats.Text = "총: 0회 | 불량: 0.0%\r\nPASS: 0회\r\nFAIL: 0회";

            // 
            // btnClearMotorStats
            // 
            this.btnClearMotorStats.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.btnClearMotorStats.Location = new System.Drawing.Point(168, 42);
            this.btnClearMotorStats.Name = "btnClearMotorStats";
            this.btnClearMotorStats.Size = new System.Drawing.Size(70, 30);
            this.btnClearMotorStats.TabIndex = 1;
            this.btnClearMotorStats.Text = "초기화";
            this.btnClearMotorStats.UseVisualStyleBackColor = true;
            this.btnClearMotorStats.Click += new System.EventHandler(this.btnClearMotorStats_Click);

            // 
            // grpStatLeftIr
            // 
            this.grpStatLeftIr.Controls.Add(this.lblLeftIrStats);
            this.grpStatLeftIr.Controls.Add(this.btnClearLeftIrStats);
            this.grpStatLeftIr.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.grpStatLeftIr.Location = new System.Drawing.Point(12, 160);
            this.grpStatLeftIr.Name = "grpStatLeftIr";
            this.grpStatLeftIr.Size = new System.Drawing.Size(245, 105);
            this.grpStatLeftIr.TabIndex = 2;
            this.grpStatLeftIr.TabStop = false;
            this.grpStatLeftIr.Text = "■ LEFT IR 통계";

            // 
            // lblLeftIrStats
            // 
            this.lblLeftIrStats.Font = new System.Drawing.Font("맑은 고딕", 9.5F);
            this.lblLeftIrStats.Location = new System.Drawing.Point(8, 22);
            this.lblLeftIrStats.Name = "lblLeftIrStats";
            this.lblLeftIrStats.Size = new System.Drawing.Size(155, 75);
            this.lblLeftIrStats.TabIndex = 0;
            this.lblLeftIrStats.Text = "총: 0회 | 불량: 0.0%\r\nPASS: 0회\r\nFAIL: 0회";

            // 
            // btnClearLeftIrStats
            // 
            this.btnClearLeftIrStats.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.btnClearLeftIrStats.Location = new System.Drawing.Point(168, 42);
            this.btnClearLeftIrStats.Name = "btnClearLeftIrStats";
            this.btnClearLeftIrStats.Size = new System.Drawing.Size(70, 30);
            this.btnClearLeftIrStats.TabIndex = 1;
            this.btnClearLeftIrStats.Text = "초기화";
            this.btnClearLeftIrStats.UseVisualStyleBackColor = true;
            this.btnClearLeftIrStats.Click += new System.EventHandler(this.btnClearLeftIrStats_Click);

            // 
            // grpStatRightIr
            // 
            this.grpStatRightIr.Controls.Add(this.lblRightIrStats);
            this.grpStatRightIr.Controls.Add(this.btnClearRightIrStats);
            this.grpStatRightIr.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.grpStatRightIr.Location = new System.Drawing.Point(270, 160);
            this.grpStatRightIr.Name = "grpStatRightIr";
            this.grpStatRightIr.Size = new System.Drawing.Size(245, 105);
            this.grpStatRightIr.TabIndex = 3;
            this.grpStatRightIr.TabStop = false;
            this.grpStatRightIr.Text = "■ RIGHT IR 통계";

            // 
            // lblRightIrStats
            // 
            this.lblRightIrStats.Font = new System.Drawing.Font("맑은 고딕", 9.5F);
            this.lblRightIrStats.Location = new System.Drawing.Point(8, 22);
            this.lblRightIrStats.Name = "lblRightIrStats";
            this.lblRightIrStats.Size = new System.Drawing.Size(155, 75);
            this.lblRightIrStats.TabIndex = 0;
            this.lblRightIrStats.Text = "총: 0회 | 불량: 0.0%\r\nPASS: 0회\r\nFAIL: 0회";

            // 
            // btnClearRightIrStats
            // 
            this.btnClearRightIrStats.Font = new System.Drawing.Font("맑은 고딕", 8.5F);
            this.btnClearRightIrStats.Location = new System.Drawing.Point(168, 42);
            this.btnClearRightIrStats.Name = "btnClearRightIrStats";
            this.btnClearRightIrStats.Size = new System.Drawing.Size(70, 30);
            this.btnClearRightIrStats.TabIndex = 1;
            this.btnClearRightIrStats.Text = "초기화";
            this.btnClearRightIrStats.UseVisualStyleBackColor = true;
            this.btnClearRightIrStats.Click += new System.EventHandler(this.btnClearRightIrStats_Click);

            // 
            // grpGuide
            // 
            this.grpGuide.Controls.Add(this.txtGuide);
            this.grpGuide.Controls.Add(this.txtCriteria);
            this.grpGuide.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.grpGuide.Location = new System.Drawing.Point(672, 295);
            this.grpGuide.Name = "grpGuide";
            this.grpGuide.Size = new System.Drawing.Size(530, 235);
            this.grpGuide.TabIndex = 4;
            this.grpGuide.TabStop = false;
            this.grpGuide.Text = "측정 기준값 및 사용 설명서";

            // 
            // txtCriteria
            // 
            this.txtCriteria.BackColor = System.Drawing.SystemColors.Info;
            this.txtCriteria.Font = new System.Drawing.Font("맑은 고딕", 10.5F);
            this.txtCriteria.Location = new System.Drawing.Point(12, 25);
            this.txtCriteria.Multiline = true;
            this.txtCriteria.Name = "txtCriteria";
            this.txtCriteria.ReadOnly = true;
            this.txtCriteria.Size = new System.Drawing.Size(505, 95);
            this.txtCriteria.TabIndex = 0;
            this.txtCriteria.Text = "[판정 기준값 안내]\r\n■ LOADCELL : 편차 ≥ +50,000 (PASS) / ≤ -50,000 (FAIL) / 그 외 (READY)\r\n■ MOTOR ADC: ≤ 10 (미연결) / 220 ~ 260 (PASS) / 그 외 (FAIL)\r\n■ IR 센서 ADC : ≤ 10 (미연결) / 11 ~ 2000 (READY) / ≥ 3000 (PASS)";

            // 
            // txtGuide
            // 
            this.txtGuide.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGuide.Font = new System.Drawing.Font("맑은 고딕", 10.5F);
            this.txtGuide.Location = new System.Drawing.Point(12, 126);
            this.txtGuide.Multiline = true;
            this.txtGuide.Name = "txtGuide";
            this.txtGuide.ReadOnly = true;
            this.txtGuide.Size = new System.Drawing.Size(505, 95);
            this.txtGuide.TabIndex = 1;
            this.txtGuide.Text = "[작업 순서]\r\n1. 검사할 센서 항목([✓] 체크박스) 선택 후 지그 영점 버튼을 누릅니다.\r\n2. 가압 및 센서 동작을 확인합니다.\r\n3. 하단의 [다음 검사] 버튼 클릭 시 선택 품목만 통계에 자동 기록됩니다.";

            // 
            // btnResetTest
            // 
            this.btnResetTest.BackColor = System.Drawing.Color.SteelBlue;
            this.btnResetTest.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnResetTest.ForeColor = System.Drawing.Color.White;
            this.btnResetTest.Location = new System.Drawing.Point(672, 536);
            this.btnResetTest.Name = "btnResetTest";
            this.btnResetTest.Size = new System.Drawing.Size(530, 54);
            this.btnResetTest.TabIndex = 5;
            this.btnResetTest.Text = "다음 검사 (기록 및 초기화)  ➔";
            this.btnResetTest.UseVisualStyleBackColor = false;
            this.btnResetTest.Click += new System.EventHandler(this.btnResetTest_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 605);
            this.Controls.Add(this.btnResetTest);
            this.Controls.Add(this.grpGuide);
            this.Controls.Add(this.grpStats);
            this.Controls.Add(this.grpAdc);
            this.Controls.Add(this.grpLoadcell);
            this.Controls.Add(this.grpConn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JIG Test Monitor (선택 품목 검사 & CSV 저장)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpConn.ResumeLayout(false);
            this.grpConn.PerformLayout();
            this.grpLoadcell.ResumeLayout(false);
            this.grpLoadcell.PerformLayout();
            this.grpAdc.ResumeLayout(false);
            this.grpAdc.PerformLayout();
            this.grpStats.ResumeLayout(false);
            this.grpStatLoadcell.ResumeLayout(false);
            this.grpStatMotor.ResumeLayout(false);
            this.grpStatLeftIr.ResumeLayout(false);
            this.grpStatRightIr.ResumeLayout(false);
            this.grpGuide.ResumeLayout(false);
            this.grpGuide.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConn;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpLoadcell;
        private System.Windows.Forms.CheckBox chkTestLc;
        private System.Windows.Forms.Label lblPassFail;
        private System.Windows.Forms.Label lblLoadcellVal;
        private System.Windows.Forms.Label lblDeltaVal;
        private System.Windows.Forms.Label lblOffsetVal;
        private System.Windows.Forms.Label lblBtnState;
        private System.Windows.Forms.GroupBox grpAdc;
        private System.Windows.Forms.CheckBox chkTestMotor;
        private System.Windows.Forms.CheckBox chkTestLeftIr;
        private System.Windows.Forms.CheckBox chkTestRightIr;
        private System.Windows.Forms.Label lblMotorAdc;
        private System.Windows.Forms.Label lblMotorStatus;
        private System.Windows.Forms.Label lblLeftIrAdc;
        private System.Windows.Forms.Label lblLeftIrStatus;
        private System.Windows.Forms.Label lblRightIrAdc;
        private System.Windows.Forms.Label lblRightIrStatus;
        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnClearAllStats;
        private System.Windows.Forms.GroupBox grpStatLoadcell;
        private System.Windows.Forms.Label lblLcStats;
        private System.Windows.Forms.Button btnClearLcStats;
        private System.Windows.Forms.GroupBox grpStatMotor;
        private System.Windows.Forms.Label lblMotorStats;
        private System.Windows.Forms.Button btnClearMotorStats;
        private System.Windows.Forms.GroupBox grpStatLeftIr;
        private System.Windows.Forms.Label lblLeftIrStats;
        private System.Windows.Forms.Button btnClearLeftIrStats;
        private System.Windows.Forms.GroupBox grpStatRightIr;
        private System.Windows.Forms.Label lblRightIrStats;
        private System.Windows.Forms.Button btnClearRightIrStats;
        private System.Windows.Forms.GroupBox grpGuide;
        private System.Windows.Forms.TextBox txtCriteria;
        private System.Windows.Forms.TextBox txtGuide;
        private System.Windows.Forms.Button btnResetTest;
    }
}