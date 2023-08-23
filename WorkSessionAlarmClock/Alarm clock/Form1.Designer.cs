namespace Alarm_clock
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxSessionTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTimerEnds = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.btnAllSessions = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotalElapses = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTimerElapsedTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRiskTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSinceTxt = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblLastSessionEndTime = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelDayStartTime = new System.Windows.Forms.Label();
            this.labelDayEndTime = new System.Windows.Forms.Label();
            this.labelTotalTimeSpent = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lablePreviousSessionBreak = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "hh:mm:ss tt";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(241, 13);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(450, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(400, 205);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(143, 37);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start Session";
            this.startButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(548, 205);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(181, 37);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop Session";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Session Starting Time";
            // 
            // txtboxSessionTime
            // 
            this.txtboxSessionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxSessionTime.Location = new System.Drawing.Point(241, 53);
            this.txtboxSessionTime.Name = "txtboxSessionTime";
            this.txtboxSessionTime.Size = new System.Drawing.Size(450, 26);
            this.txtboxSessionTime.TabIndex = 5;
            this.txtboxSessionTime.Text = "45";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Session End Time";
            // 
            // dateTimePickerTimerEnds
            // 
            this.dateTimePickerTimerEnds.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTimerEnds.CustomFormat = "hh:mm:ss tt";
            this.dateTimePickerTimerEnds.Enabled = false;
            this.dateTimePickerTimerEnds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTimerEnds.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTimerEnds.Location = new System.Drawing.Point(241, 90);
            this.dateTimePickerTimerEnds.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerTimerEnds.Name = "dateTimePickerTimerEnds";
            this.dateTimePickerTimerEnds.Size = new System.Drawing.Size(450, 26);
            this.dateTimePickerTimerEnds.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblStatus.Location = new System.Drawing.Point(237, 172);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(83, 20);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Lets begin";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(241, 205);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(144, 37);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "RefreshTimes";
            this.buttonRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // btnAllSessions
            // 
            this.btnAllSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllSessions.Location = new System.Drawing.Point(742, 205);
            this.btnAllSessions.Margin = new System.Windows.Forms.Padding(2);
            this.btnAllSessions.Name = "btnAllSessions";
            this.btnAllSessions.Size = new System.Drawing.Size(231, 37);
            this.btnAllSessions.TabIndex = 12;
            this.btnAllSessions.Text = "Show All Sessions";
            this.btnAllSessions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllSessions.UseVisualStyleBackColor = true;
            this.btnAllSessions.Click += new System.EventHandler(this.btnAllSessions_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(241, 306);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(488, 293);
            this.dataGridView1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(237, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total Timer Elapses";
            // 
            // labelTotalElapses
            // 
            this.labelTotalElapses.AutoSize = true;
            this.labelTotalElapses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalElapses.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelTotalElapses.Location = new System.Drawing.Point(237, 274);
            this.labelTotalElapses.Name = "labelTotalElapses";
            this.labelTotalElapses.Size = new System.Drawing.Size(18, 20);
            this.labelTotalElapses.TabIndex = 17;
            this.labelTotalElapses.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total Session Time(Minutes)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Timer Elapsed Time (Minutes)";
            // 
            // textBoxTimerElapsedTime
            // 
            this.textBoxTimerElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTimerElapsedTime.Location = new System.Drawing.Point(241, 129);
            this.textBoxTimerElapsedTime.Name = "textBoxTimerElapsedTime";
            this.textBoxTimerElapsedTime.ReadOnly = true;
            this.textBoxTimerElapsedTime.Size = new System.Drawing.Size(450, 26);
            this.textBoxTimerElapsedTime.TabIndex = 20;
            this.textBoxTimerElapsedTime.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(238, 602);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(327, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "(You can change all configurationsit in config file)";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(544, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Non-Break Working Time";
            // 
            // labelRiskTime
            // 
            this.labelRiskTime.AutoSize = true;
            this.labelRiskTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRiskTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelRiskTime.Location = new System.Drawing.Point(544, 274);
            this.labelRiskTime.Name = "labelRiskTime";
            this.labelRiskTime.Size = new System.Drawing.Size(79, 20);
            this.labelRiskTime.TabIndex = 23;
            this.labelRiskTime.Text = "00:00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(738, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Max Session Time: 45mins";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(738, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Min Session Break: 5mins";
            // 
            // lblSinceTxt
            // 
            this.lblSinceTxt.AutoSize = true;
            this.lblSinceTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinceTxt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSinceTxt.Location = new System.Drawing.Point(738, 274);
            this.lblSinceTxt.Name = "lblSinceTxt";
            this.lblSinceTxt.Size = new System.Drawing.Size(104, 20);
            this.lblSinceTxt.TabIndex = 27;
            this.lblSinceTxt.Text = "00:00:00 00";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelTotal.Location = new System.Drawing.Point(396, 274);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(79, 20);
            this.labelTotal.TabIndex = 15;
            this.labelTotal.Text = "00:00:00";
            this.labelTotal.Click += new System.EventHandler(this.labelTotal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(396, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Total Session Time";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(738, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Non-Break To Time";
            // 
            // lblLastSessionEndTime
            // 
            this.lblLastSessionEndTime.AutoSize = true;
            this.lblLastSessionEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSessionEndTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLastSessionEndTime.Location = new System.Drawing.Point(738, 326);
            this.lblLastSessionEndTime.Name = "lblLastSessionEndTime";
            this.lblLastSessionEndTime.Size = new System.Drawing.Size(93, 20);
            this.lblLastSessionEndTime.TabIndex = 29;
            this.lblLastSessionEndTime.Text = "00:00:00 00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(738, 496);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "Day Started Time:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(738, 522);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 20);
            this.label13.TabIndex = 31;
            this.label13.Text = "Day Ended Time:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(738, 552);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "Total Time Spent:";
            // 
            // labelDayStartTime
            // 
            this.labelDayStartTime.AutoSize = true;
            this.labelDayStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDayStartTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelDayStartTime.Location = new System.Drawing.Point(880, 496);
            this.labelDayStartTime.Name = "labelDayStartTime";
            this.labelDayStartTime.Size = new System.Drawing.Size(93, 20);
            this.labelDayStartTime.TabIndex = 33;
            this.labelDayStartTime.Text = "00:00:00 00";
            // 
            // labelDayEndTime
            // 
            this.labelDayEndTime.AutoSize = true;
            this.labelDayEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDayEndTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelDayEndTime.Location = new System.Drawing.Point(880, 522);
            this.labelDayEndTime.Name = "labelDayEndTime";
            this.labelDayEndTime.Size = new System.Drawing.Size(93, 20);
            this.labelDayEndTime.TabIndex = 34;
            this.labelDayEndTime.Text = "00:00:00 00";
            this.labelDayEndTime.Click += new System.EventHandler(this.labelDayEndTime_Click);
            // 
            // labelTotalTimeSpent
            // 
            this.labelTotalTimeSpent.AutoSize = true;
            this.labelTotalTimeSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTimeSpent.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelTotalTimeSpent.Location = new System.Drawing.Point(880, 552);
            this.labelTotalTimeSpent.Name = "labelTotalTimeSpent";
            this.labelTotalTimeSpent.Size = new System.Drawing.Size(79, 20);
            this.labelTotalTimeSpent.TabIndex = 35;
            this.labelTotalTimeSpent.Text = "00:00:00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(738, 380);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(185, 20);
            this.label15.TabIndex = 36;
            this.label15.Text = "Last Session Break Time";
            // 
            // lablePreviousSessionBreak
            // 
            this.lablePreviousSessionBreak.AutoSize = true;
            this.lablePreviousSessionBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablePreviousSessionBreak.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lablePreviousSessionBreak.Location = new System.Drawing.Point(738, 400);
            this.lablePreviousSessionBreak.Name = "lablePreviousSessionBreak";
            this.lablePreviousSessionBreak.Size = new System.Drawing.Size(79, 20);
            this.lablePreviousSessionBreak.TabIndex = 37;
            this.lablePreviousSessionBreak.Text = "00:00:00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(738, 254);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 20);
            this.label16.TabIndex = 38;
            this.label16.Text = "Non-Break From Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 629);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lablePreviousSessionBreak);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.labelTotalTimeSpent);
            this.Controls.Add(this.labelDayEndTime);
            this.Controls.Add(this.labelDayStartTime);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblLastSessionEndTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelTotalElapses);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSinceTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelRiskTime);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxTimerElapsedTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAllSessions);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dateTimePickerTimerEnds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxSessionTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work Session Notification";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;        
        private System.Windows.Forms.TextBox txtboxSessionTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimerEnds;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button btnAllSessions;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotalElapses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTimerElapsedTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRiskTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSinceTxt;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblLastSessionEndTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelDayStartTime;
        private System.Windows.Forms.Label labelDayEndTime;
        private System.Windows.Forms.Label labelTotalTimeSpent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lablePreviousSessionBreak;
        private System.Windows.Forms.Label label16;
    }
}

