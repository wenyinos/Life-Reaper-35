namespace Life_Reaper
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            btnMinimize = new Button();
            btnClose = new Button();
            panelContent = new Panel();
            lblWarning = new Label();
            lblQuestion1 = new Label();
            lblDescription1 = new Label();
            lblQuestion2 = new Label();
            lblDescription2 = new Label();
            lblCountdownLabel = new Label();
            lblCountdown = new Label();
            lblInstructions = new Label();
            lblBtcAddress = new Label();
            lblBtcAmount = new Label();
            btnDecrypt = new Button();
            btnPay = new Button();
            btnCheckPayment = new Button();
            lblTimer = new Label();
            timerCountdown = new System.Windows.Forms.Timer(components);
            panelTitleBar.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(192, 0, 0);
            panelTitleBar.Controls.Add(btnClose);
            panelTitleBar.Controls.Add(btnMinimize);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(780, 40);
            panelTitleBar.TabIndex = 0;
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 6);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "续命 26.08.17";
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(192, 0, 0);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(698, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(36, 32);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "─";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += BtnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(192, 0, 0);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(740, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(36, 32);
            btnClose.TabIndex = 2;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(245, 245, 245);
            panelContent.Controls.Add(lblWarning);
            panelContent.Controls.Add(lblQuestion1);
            panelContent.Controls.Add(lblDescription1);
            panelContent.Controls.Add(lblQuestion2);
            panelContent.Controls.Add(lblDescription2);
            panelContent.Controls.Add(lblCountdownLabel);
            panelContent.Controls.Add(lblCountdown);
            panelContent.Controls.Add(lblInstructions);
            panelContent.Controls.Add(lblBtcAddress);
            panelContent.Controls.Add(lblBtcAmount);
            panelContent.Controls.Add(btnDecrypt);
            panelContent.Controls.Add(btnPay);
            panelContent.Controls.Add(btnCheckPayment);
            panelContent.Controls.Add(lblTimer);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 40);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(780, 520);
            panelContent.TabIndex = 1;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblWarning.ForeColor = Color.FromArgb(192, 0, 0);
            lblWarning.Location = new Point(30, 20);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(440, 36);
            lblWarning.TabIndex = 0;
            lblWarning.Text = "哎呀，你的寿命正在快速消失！";
            // 
            // lblQuestion1
            // 
            lblQuestion1.AutoSize = true;
            lblQuestion1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblQuestion1.ForeColor = Color.FromArgb(192, 0, 0);
            lblQuestion1.Location = new Point(30, 70);
            lblQuestion1.Name = "lblQuestion1";
            lblQuestion1.TabIndex = 1;
            lblQuestion1.Text = "你的寿命怎么了？";
            // 
            // lblDescription1
            // 
            lblDescription1.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription1.ForeColor = Color.FromArgb(50, 50, 50);
            lblDescription1.Location = new Point(30, 100);
            lblDescription1.Name = "lblDescription1";
            lblDescription1.Size = new Size(720, 30);
            lblDescription1.TabIndex = 2;
            lblDescription1.Text = "有一位老领导正在进行时间众筹。你暂时不会被续掉，但寿命正在快速减少。";
            // 
            // lblQuestion2
            // 
            lblQuestion2.AutoSize = true;
            lblQuestion2.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblQuestion2.ForeColor = Color.FromArgb(192, 0, 0);
            lblQuestion2.Location = new Point(30, 135);
            lblQuestion2.Name = "lblQuestion2";
            lblQuestion2.TabIndex = 3;
            lblQuestion2.Text = "我应该怎么做？";
            // 
            // lblDescription2
            // 
            lblDescription2.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription2.ForeColor = Color.FromArgb(50, 50, 50);
            lblDescription2.Location = new Point(30, 165);
            lblDescription2.Name = "lblDescription2";
            lblDescription2.Size = new Size(720, 30);
            lblDescription2.TabIndex = 4;
            lblDescription2.Text = "你应该背诵三个代表全篇，或者学习老三篇，也可以念两句诗。";
            // 
            // lblCountdownLabel
            // 
            lblCountdownLabel.AutoSize = true;
            lblCountdownLabel.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblCountdownLabel.ForeColor = Color.FromArgb(192, 0, 0);
            lblCountdownLabel.Location = new Point(30, 220);
            lblCountdownLabel.Name = "lblCountdownLabel";
            lblCountdownLabel.Size = new Size(200, 26);
            lblCountdownLabel.TabIndex = 5;
            lblCountdownLabel.Text = "你的命将在以下时间续给长者：";
            // 
            // lblCountdown
            // 
            lblCountdown.AutoSize = true;
            lblCountdown.Font = new Font("Consolas", 32F, FontStyle.Bold, GraphicsUnit.Point);
            lblCountdown.ForeColor = Color.FromArgb(192, 0, 0);
            lblCountdown.Location = new Point(30, 255);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new Size(210, 51);
            lblCountdown.TabIndex = 6;
            lblCountdown.Text = "07:00:00";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblInstructions.ForeColor = Color.FromArgb(50, 50, 50);
            lblInstructions.Location = new Point(30, 325);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(160, 22);
            lblInstructions.TabIndex = 7;
            lblInstructions.Text = "三个代表重要思想内容是：";
            // 
            // lblBtcAddress
            // 
            lblBtcAddress.AutoSize = false;
            lblBtcAddress.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblBtcAddress.ForeColor = Color.FromArgb(0, 100, 200);
            lblBtcAddress.Location = new Point(30, 355);
            lblBtcAddress.Name = "lblBtcAddress";
            lblBtcAddress.Size = new Size(720, 38);
            lblBtcAddress.TabIndex = 8;
            lblBtcAddress.Text = "中国共产党要始终代表中国先进社会生产力的发展要求，代表中国先进文化的前进方向，代表中国最广大人民的根本利益";
            // 
            // lblBtcAmount
            // 
            lblBtcAmount.AutoSize = true;
            lblBtcAmount.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblBtcAmount.ForeColor = Color.FromArgb(192, 0, 0);
            lblBtcAmount.Location = new Point(30, 390);
            lblBtcAmount.Name = "lblBtcAmount";
            lblBtcAmount.Size = new Size(110, 26);
            lblBtcAmount.TabIndex = 9;
            lblBtcAmount.Text = "+1S";
            // 
            // btnDecrypt
            // 
            btnDecrypt.BackColor = Color.FromArgb(192, 0, 0);
            btnDecrypt.FlatAppearance.BorderSize = 0;
            btnDecrypt.FlatStyle = FlatStyle.Flat;
            btnDecrypt.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDecrypt.ForeColor = Color.White;
            btnDecrypt.Location = new Point(30, 440);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(200, 45);
            btnDecrypt.TabIndex = 10;
            btnDecrypt.Text = "背诵三个代表";
            btnDecrypt.UseVisualStyleBackColor = false;
            btnDecrypt.Click += BtnDecrypt_Click;
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.FromArgb(0, 100, 200);
            btnPay.FlatAppearance.BorderSize = 0;
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(260, 440);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(200, 45);
            btnPay.TabIndex = 11;
            btnPay.Text = "学习老三篇";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += BtnPay_Click;
            // 
            // btnCheckPayment
            // 
            btnCheckPayment.BackColor = Color.FromArgb(80, 80, 80);
            btnCheckPayment.FlatAppearance.BorderSize = 0;
            btnCheckPayment.FlatStyle = FlatStyle.Flat;
            btnCheckPayment.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCheckPayment.ForeColor = Color.White;
            btnCheckPayment.Location = new Point(490, 440);
            btnCheckPayment.Name = "btnCheckPayment";
            btnCheckPayment.Size = new Size(200, 45);
            btnCheckPayment.TabIndex = 12;
            btnCheckPayment.Text = "念两句诗";
            btnCheckPayment.UseVisualStyleBackColor = false;
            btnCheckPayment.Click += BtnCheckPayment_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTimer.ForeColor = Color.FromArgb(100, 100, 100);
            lblTimer.Location = new Point(30, 505);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(280, 19);
            lblTimer.TabIndex = 13;
            lblTimer.Text = "你的寿命剩余时间：";
            // 
            // timerCountdown
            // 
            timerCountdown.Enabled = true;
            timerCountdown.Interval = 1000;
            timerCountdown.Tick += TimerCountdown_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 560);
            Controls.Add(panelContent);
            Controls.Add(panelTitleBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "续命 26.08.17";
            TopMost = true;
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTitleBar;
        private Label lblTitle;
        private Button btnMinimize;
        private Button btnClose;
        private Panel panelContent;
        private Label lblWarning;
        private Label lblQuestion1;
        private Label lblDescription1;
        private Label lblQuestion2;
        private Label lblDescription2;
        private Label lblCountdownLabel;
        private Label lblCountdown;
        private Label lblInstructions;
        private Label lblBtcAddress;
        private Label lblBtcAmount;
        private Button btnDecrypt;
        private Button btnPay;
        private Button btnCheckPayment;
        private Label lblTimer;
        private System.Windows.Forms.Timer timerCountdown;
    }
}
