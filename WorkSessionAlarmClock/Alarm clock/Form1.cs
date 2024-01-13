using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Configuration;

namespace Alarm_clock
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        readonly SoundPlayer soundPlayer = new SoundPlayer();

        private int sessionTotalTime = 45;
        private int minSessionBrake = 5;

        private int riskDangerTotalSessionTime = 3;
        private int riskDangerNonBreakSessionTime = 20;
        private int riskDangerTotalDaySpent = 6;

        private List<Session> todaySessions { get; set; }

        private bool isSessionStarted = false;
        private int totalElapses = 0;

        private DateTime NonBreakStartTime { get; set; }
        private DateTime LastSessionEndTime { get; set; }
        public int elapsedTime { get; set; }

        private DateTime tempSessionStartedDateTime;

        private DateTime dayStartedTime;

        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.TimeAlarm2;
            this.toolTip1.SetToolTip(this.btnIncludeBreakSession, "Include Break in New Session");
            this.toolTip2.SetToolTip(this.btnSetNextLargeSessionBreak, "Refresh Next Large Session Break");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set actual session
            bool resultSession = int.TryParse(ConfigurationManager.AppSettings["SessionTotalTime"], out sessionTotalTime);

            if (!resultSession)
            {
                sessionTotalTime = 45;
            }
            txtboxSessionTime.Text = sessionTotalTime.ToString();


            // default for one minute
            int minutesMilliSeconds = 60000;
            int timerElapseTime = 1;
            bool isSuccess = int.TryParse(ConfigurationManager.AppSettings["TimerElapseTime"], out timerElapseTime);
            if (!isSuccess)
            {
                timerElapseTime = 1;
                textBoxTimerElapsedTime.Text = timerElapseTime.ToString();

                elapsedTime = timerElapseTime;

                timerElapseTime = timerElapseTime * minutesMilliSeconds;
            }
            else
            {
                elapsedTime = timerElapseTime;

                textBoxTimerElapsedTime.Text = timerElapseTime.ToString();
                // we read in minutes
                timerElapseTime = timerElapseTime*minutesMilliSeconds;
            }            

            todaySessions = new List<Session>();
            timer = new System.Timers.Timer();

            // checks elapsed event for each interval
            //timer.Interval = 1000;
            timer.Interval = timerElapseTime;
            timer.Elapsed += Timer_Elapsed;

            if(!int.TryParse(txtboxSessionTime.Text, out sessionTotalTime))
            {
                sessionTotalTime = 45;
                txtboxSessionTime.Text = sessionTotalTime.ToString();
            }

            dateTimePickerTimerEnds.Value = dateTimePicker1.Value.AddMinutes(sessionTotalTime);

            //dataGridView1.DataSource = todaySessions;

           var result1=int.TryParse(ConfigurationManager.AppSettings["RiskDangerNonBreakSessionTime"], out riskDangerNonBreakSessionTime);

            if(!result1)
            {
                riskDangerNonBreakSessionTime = 20;
            }
        
           var result2=int.TryParse(ConfigurationManager.AppSettings["RiskDangerTotalSessionTime"], out riskDangerTotalSessionTime);
            if(!result2)
            {
                riskDangerTotalSessionTime = 3;
            }

            bool result3 = int.TryParse(ConfigurationManager.AppSettings["MinimumSessionBrakeTime"], out minSessionBrake);
            if (!result3)
            {
                // for calculating non contineous session break time
                minSessionBrake = 5;
            }

            bool result4 = int.TryParse(ConfigurationManager.AppSettings["RiskDangerTotalDaySpent"], out riskDangerTotalDaySpent);
            if (!result4)
            {
                // for calculating non contineous session break time
                riskDangerTotalDaySpent = 6;
            }

            dayStartedTime = DateTime.Now;
            UpdateDayDetails();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(isSessionStarted)
            {
                MessageBox.Show("A session already in progress. Please wait or stop session",
                        "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                return;
            }

            buttonRefresh_Click(sender, e);

            if(elapsedTime > sessionTotalTime)
            {
                MessageBox.Show("Total Session Time should be greater than or Equal to Timer Elapsed Time",
                        "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                return;
            }

            timer.Start();
            //MessageBox.Show("Your timer is started","Starting...");
            lblStatus.Text = "Session is started";

            isSessionStarted = true;

            if(todaySessions.Count == 0)
            {
                // if first session
                btnSetNextLargeSessionBreak_Click(sender, e);
            }

            if (isSessionStarted && todaySessions.Count >= 1)
            {
                UpdateLastSessionBreak(todaySessions[todaySessions.Count - 1].SessionEnd, DateTime.Now);
            }

            tempSessionStartedDateTime = DateTime.Now;

            // if user took minimum break
            if (doesUserHadMinimumSessionBrakeTime(tempSessionStartedDateTime))
            {
                ResetRiskDetails();
            }

        }

        public bool doesUserHadMinimumSessionBrakeTime(DateTime presentTime)
        {
            try
            {
                bool result = false;

                // if it is first session
                if (todaySessions.Count == 0)
                {
                    result = true;
                }

                if (todaySessions.Count > 0)
                {
                    var lastSession = todaySessions[todaySessions.Count - 1];

                    TimeSpan twoSessionGap = presentTime - lastSession.SessionEnd;

                    int gapHours = Math.Abs(twoSessionGap.Hours);
                    int gapMinutes = Math.Abs(twoSessionGap.Minutes);

                    if ((gapHours == 0) && (gapMinutes >= minSessionBrake))
                    {

                        result = true;
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            totalElapses++;
            this.Invoke(new Action(() =>
            {
                labelTotalElapses.Text = totalElapses.ToString();
            }));

            DateTime currentTime = DateTime.Now;

            //DateTime userTime = dateTimePicker1.Value;
            DateTime userTime = dateTimePickerTimerEnds.Value;

            var diffTime = currentTime - userTime;
            var diffMinutes = diffTime.Minutes;

            //if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            if (diffMinutes >= 0)
            {
                timer.Stop();

                TimeSpan tspan = dateTimePickerTimerEnds.Value - dateTimePicker1.Value;

                Session session = new Session
                {
                    SessionStart = dateTimePicker1.Value,
                    SessionEnd = dateTimePickerTimerEnds.Value,
                    TotalSession = (dateTimePickerTimerEnds.Value - dateTimePicker1.Value).ToString(@"hh\:mm\:ss")
                };

                addSession(session);
                isSessionStarted = false;

                LastSessionEndTime = session.SessionEnd;
                

                this.Invoke(new Action(() =>
                {
                    lblStatus.Text = "Session is ended. Take Break";

                    TimeSpan totalSpan = new TimeSpan(0);
                    foreach (var item in todaySessions)
                    {
                        totalSpan = totalSpan + (item.SessionEnd - item.SessionStart);
                    }

                    labelTotal.Text = totalSpan.ToString(@"hh\:mm\:ss");
                    labelTotalElapses.Text = totalElapses.ToString();

                    //TimeSpan riskTime = getRiskTime();
                    //labelRiskTime.Text = riskTime.ToString(@"hh\:mm\:ss");
                    //lblSinceTxt.Text = NonBreakStartTime.ToString("hh:mm:ss tt");
                    //lblLastSessionEndTime.Text = LastSessionEndTime.ToString("hh:mm:ss tt");
                    updateRiskDetails();

                    //UpdateDayDetails();
                    btnAllSessions_Click(sender, e);
                }));

                try
                {
                    //lblStatus.Text = "Session is ended. Take Break"; 

                    var soundLocation = ConfigurationManager.AppSettings["SoundLocationPath"];
                    if (string.IsNullOrEmpty(soundLocation))
                    {
                        soundLocation = "Alarm Clock Sound.wav";
                    }

                    int milliSeconds = 1000;
                    int palyLength = 2;
                    bool isSuccess = int.TryParse(ConfigurationManager.AppSettings["SoundPlayLength"], out palyLength);
                    if (!isSuccess)
                    {
                        palyLength = 2;
                    }
                    palyLength = palyLength * milliSeconds;

                    bool playAlarm = false;
                    bool isSuccess2 = bool.TryParse(ConfigurationManager.AppSettings["PlayAlarm"], out playAlarm);
                    if (!isSuccess2)
                    {
                        playAlarm = false;
                    }

                    soundPlayer.SoundLocation = soundLocation;

                    if (playAlarm)
                    {
                        soundPlayer.PlayLooping();
                        //soundPlayer.Play();

                        System.Threading.Thread.Sleep(palyLength);
                        soundPlayer.Stop();
                    }

                    //TimeSpan riskTime = getRiskTime();
                    //lblSinceTxt.Text = NonBreakStartTime.ToString("hh:mm:ss tt");
                    //lblLastSessionEndTime.Text = LastSessionEndTime.ToString("hh:mm:ss tt");

                    TimeSpan riskTime=updateRiskDetails();

                    //this.WindowState = FormWindowState.Maximized;
                    //MessageBox.Show("Session is ended. Take Break");
                    MessageBox.Show("Session is ended.\n" 
                        +"Previous contineous Non-Break Session : "+ riskTime.ToString(@"hh\:mm\:ss")
                    + "\nTake Break. Drink Water. Eat Food. Standup",
                        "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    timer.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured: " + ex.Message);
                    //lblStatus.Text = "Error : Session is finished!!";
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            dateTimePickerTimerEnds.Value = DateTime.Now;

            Session session = new Session
            {
                SessionStart = dateTimePicker1.Value,
                SessionEnd = dateTimePickerTimerEnds.Value,
                TotalSession = (dateTimePickerTimerEnds.Value - dateTimePicker1.Value).ToString(@"hh\:mm\:ss")
            };

            addSession(session);
            isSessionStarted = false;

            timer.Stop();
            soundPlayer.Stop();
            //MessageBox.Show("Your timer is stopped", "Stopping...");
            lblStatus.Text = "Session is ended. Take Break";

            LastSessionEndTime = session.SessionEnd;

            TimeSpan totalSpan = new TimeSpan(0);
            foreach (var item in todaySessions)
            {
                totalSpan = totalSpan + (item.SessionEnd - item.SessionStart);
            }

            labelTotal.Text = totalSpan.ToString(@"hh\:mm\:ss");
            labelTotalElapses.Text = totalElapses.ToString();

            //TimeSpan riskTime = getRiskTime();
            //labelRiskTime.Text = riskTime.ToString(@"hh\:mm\:ss");
            //lblSinceTxt.Text = NonBreakStartTime.ToString("hh:mm:ss tt");
            //lblLastSessionEndTime.Text= LastSessionEndTime.ToString("hh:mm:ss tt");
            updateRiskDetails();

            //UpdateDayDetails();
            btnAllSessions_Click(sender, e);
        }

        private void txtboxSessionTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if(isSessionStarted)
            {
                MessageBox.Show("Session is in progress. Unable to refresh Times. Please wait or stop session",
                        "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                return;
            }

            dateTimePicker1.Value = DateTime.Now;

            if (!int.TryParse(txtboxSessionTime.Text, out sessionTotalTime))
            {
                sessionTotalTime = 45;
                txtboxSessionTime.Text = sessionTotalTime.ToString();
            }

            dateTimePickerTimerEnds.Value = dateTimePicker1.Value.AddMinutes(sessionTotalTime);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAllSessions_Click(object sender, EventArgs e)
        {
            List<SessionFormatted> listSessionFormatted = new List<SessionFormatted>();            

            TimeSpan totalSpan = new TimeSpan(0);

            foreach (var item in todaySessions)
            {
                totalSpan = totalSpan + (item.SessionEnd - item.SessionStart);

                SessionFormatted sessionFormatted = new SessionFormatted()
                {
                    SessionStart = item.SessionStart.ToString("hh:mm:ss tt"),
                    SessionEnd = item.SessionEnd.ToString("hh:mm:ss tt"),
                    TotalSession = item.TotalSession
                };

                listSessionFormatted.Add(sessionFormatted);
            }


            dataGridView1.DataSource = listSessionFormatted;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listSessionFormatted;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            var hours = totalSpan.TotalHours;

            // if more than 3hrs mins make red
            if (hours >= riskDangerTotalSessionTime)
            {
                labelTotal.ForeColor = System.Drawing.Color.OrangeRed;
            }
            else
            {
                // normal
                labelTotal.ForeColor = System.Drawing.SystemColors.Highlight;
            }

            labelTotal.Text = totalSpan.ToString(@"hh\:mm\:ss");

            labelTotalElapses.Text = totalElapses.ToString();

            //TimeSpan riskTime = getRiskTime();
            //labelRiskTime.Text= riskTime.ToString(@"hh\:mm\:ss");
            //lblSinceTxt.Text = NonBreakStartTime.ToString("hh:mm:ss tt");
            //lblLastSessionEndTime.Text = LastSessionEndTime.ToString("hh:mm:ss tt");
            updateRiskDetails();

            UpdateDayDetails();

            if(!isSessionStarted && todaySessions.Count >=1)
            {
                UpdateLastSessionBreak(todaySessions[todaySessions.Count - 1].SessionEnd, DateTime.Now);
            }
        }


        private void addSession(Session session)
        {
            try
            {
                if (isSessionStarted)
                {

                    Boolean isSessionAdded = false;

                    foreach (var item in todaySessions)
                    {
                        if (item.SessionStart.Hour == session.SessionStart.Hour &&
                            item.SessionStart.Minute == session.SessionStart.Minute &&
                            item.SessionStart.Second == session.SessionStart.Second)
                        {
                            isSessionAdded = true;
                            break;
                        }
                    }

                    if (!isSessionAdded)
                    {
                        todaySessions.Add(session);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private TimeSpan getRiskTime()
        {            

            TimeSpan riskTime = new TimeSpan(0);

            int count = 0;            

            Session lastSession = new Session();

            TimeSpan firstTimeSpan = new TimeSpan(0);

            int i = todaySessions.Count;

            if (todaySessions.Count > 0)
            {
                DateTime nonBreakEndTime = DateTime.Now;

                for (int j = i - 1; j >= 0; j--)
                {
                    var item = todaySessions[j];

                    count++;
                    if (count == 1)
                    {
                        lastSession = item;
                        firstTimeSpan = lastSession.SessionEnd - lastSession.SessionStart;
                        //riskTime = riskTime + firstTimeSpan;

                        NonBreakStartTime = lastSession.SessionStart;
                        nonBreakEndTime = lastSession.SessionEnd;
                        continue;
                    }

                    TimeSpan twoSessionGap = lastSession.SessionStart - item.SessionEnd;

                    int gapHours = Math.Abs(twoSessionGap.Hours);
                    int gapMinutes = Math.Abs(twoSessionGap.Minutes);

                    // we only add if gap between two sessions is less than 15 minutes
                    if ((gapHours == 0) && (gapMinutes < minSessionBrake))
                    {
                        //TimeSpan currentDifference = item.SessionEnd - item.SessionStart;
                        //riskTime = riskTime + currentDifference;

                        NonBreakStartTime = item.SessionStart;
                    }
                    else
                    {
                        break;
                    }

                    lastSession = item;
                }

                //foreach (var item in todaySessions)
                //{

                //}

                // you need not to caluculate each session gap and sum it
                riskTime = nonBreakEndTime - NonBreakStartTime;
            }
            return riskTime;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Code

            timer.Stop();
            soundPlayer.Stop();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void labelTotal_Click(object sender, EventArgs e)
        {

        }

        private void labelDayEndTime_Click(object sender, EventArgs e)
        {

        }

        private void UpdateDayDetails()
        {
            labelDayStartTime.Text = dayStartedTime.ToString("hh:mm:ss tt");

            var currentTimeNow = DateTime.Now;
            labelDayEndTime.Text = currentTimeNow.ToString("hh:mm:ss tt");
            
            var dayEndTime = currentTimeNow;
            var totalTimeSpent = dayEndTime - dayStartedTime;

            var hours = totalTimeSpent.TotalHours;

            if(hours >= riskDangerTotalDaySpent)
            {
                labelTotalTimeSpent.ForeColor = System.Drawing.Color.OrangeRed;
            }

            labelTotalTimeSpent.Text = totalTimeSpent.ToString(@"hh\:mm\:ss");
        }

        private void UpdateLastSessionBreak(DateTime initialTime,DateTime endTime)
        {
            var timeDifference = initialTime - endTime;

            lablePreviousSessionBreak.Text= timeDifference.ToString(@"hh\:mm\:ss");
        }

        private void btnSetNextLargeSessionBreak_Click(object sender, EventArgs e)
        {
            int defaultLargeBreakElapsedTime = 60;
            bool isSuccess = int.TryParse(ConfigurationManager.AppSettings["NextLargeBreakElapsedTime"], out defaultLargeBreakElapsedTime);

            DateTime resultDateTime = DateTime.Now.AddMinutes(defaultLargeBreakElapsedTime);

            lblNextLargeBreak.Text = resultDateTime.ToString(@"hh\:mm\:ss tt");
        }

        private void btn10Minutes_Click(object sender, EventArgs e)
        {
            txtboxSessionTime.Text = "10";
            startButton_Click(sender, e);
        }

        private void btn5Minutes_Click(object sender, EventArgs e)
        {
            txtboxSessionTime.Text = "5";
            startButton_Click(sender, e);
        }

        private void btnIncludeBreakSession_Click(object sender, EventArgs e)
        {
            if(isSessionStarted)
            {
                if (isSessionStarted)
                {
                    MessageBox.Show("A session already in progress. Please wait or stop session",
                            "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    return;
                }
            }

            if(!isSessionStarted)
            {
                if (todaySessions.Count >= 1)
                {
                    isSessionStarted = true;

                    var lastSessEndTime = todaySessions[todaySessions.Count - 1].SessionEnd;
                    var presentTime = DateTime.Now;

                    Session session = new Session
                    {
                        SessionStart = lastSessEndTime,
                        SessionEnd = presentTime,
                        TotalSession = (presentTime - lastSessEndTime).ToString(@"hh\:mm\:ss")
                    };

                    LastSessionEndTime = session.SessionEnd;

                    addSession(session);
                    isSessionStarted = false;

                    btnAllSessions_Click(sender, e);
                    buttonRefresh_Click(sender, e);
                }
            }            
        }

        public void ResetRiskDetails()
        {
            TimeSpan riskTime = new TimeSpan(0);
            //00:00:00 00

            labelRiskTime.ForeColor = System.Drawing.SystemColors.Highlight;
            labelStar.ForeColor = System.Drawing.SystemColors.Highlight;

            labelRiskTime.Text = riskTime.ToString(@"hh\:mm\:ss");

            if(isSessionStarted)
            {
                lblSinceTxt.Text = tempSessionStartedDateTime.ToString("hh:mm:ss tt");
            }
            else
            {
                lblSinceTxt.Text = "00:00:00 00";
            }
            
            lblLastSessionEndTime.Text = "00:00:00 00";
        }

        public TimeSpan updateRiskDetails()
        {
            if(isSessionStarted)
            {
                return new TimeSpan(0);
            }

            TimeSpan riskTime = getRiskTime();

            var hours = riskTime.TotalHours;
            var minutes = riskTime.TotalMinutes;

            // if more than 20 mins or more than hour make red
            if (minutes >= riskDangerNonBreakSessionTime || hours >= 1)
            {
                labelRiskTime.ForeColor = System.Drawing.Color.OrangeRed;
                labelStar.ForeColor = System.Drawing.Color.OrangeRed;
            }
            else
            {
                // normal
                labelRiskTime.ForeColor = System.Drawing.SystemColors.Highlight;
                labelStar.ForeColor = System.Drawing.SystemColors.Highlight;
            }

            if(todaySessions.Count == 0)
            {
                // for no sessions
                ResetRiskDetails();
            }
            else
            {
                labelRiskTime.Text = riskTime.ToString(@"hh\:mm\:ss");
                lblSinceTxt.Text = NonBreakStartTime.ToString("hh:mm:ss tt");
                lblLastSessionEndTime.Text = LastSessionEndTime.ToString("hh:mm:ss tt");
            }

            return riskTime;
        }
    }
}
