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
        private List<Session> todaySessions { get; set; }

        private bool isSessionStarted = false;
        private int totalElapses = 0;

        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.TimeAlarm2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // default for one minute
            int minutesMilliSeconds = 60000;
            int timerElapseTime = 1;
            bool isSuccess = int.TryParse(ConfigurationManager.AppSettings["TimerElapseTime"], out timerElapseTime);
            if (!isSuccess)
            {
                timerElapseTime = 1;
                textBoxTimerElapsedTime.Text = timerElapseTime.ToString();
                timerElapseTime = timerElapseTime * minutesMilliSeconds;
            }
            else
            {
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

            timer.Start();
            //MessageBox.Show("Your timer is started","Starting...");
            lblStatus.Text = "Session is started";

            isSessionStarted = true;
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

            var diffTime=currentTime - userTime;
            var diffMinutes = diffTime.Minutes;

            //if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            if(diffMinutes >= 0)
            {
                timer.Stop();

                TimeSpan tspan = dateTimePickerTimerEnds.Value - dateTimePicker1.Value;

                Session session = new Session
                {
                    SessionStart=dateTimePicker1.Value,
                    SessionEnd=dateTimePickerTimerEnds.Value,
                    TotalSession=(dateTimePickerTimerEnds.Value - dateTimePicker1.Value).ToString(@"hh\:mm\:ss")
            };

                addSession(session);
                isSessionStarted = false;

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

                    TimeSpan riskTime = getRiskTime();
                    labelRiskTime.Text = riskTime.ToString(@"hh\:mm\:ss");

                }));

                try
                {
                    //lblStatus.Text = "Session is ended. Take Break"; 

                    var soundLocation=ConfigurationManager.AppSettings["SoundLocationPath"];
                    if(string.IsNullOrEmpty(soundLocation))
                    {
                        soundLocation = "Alarm Clock Sound.wav";
                    }

                    int milliSeconds = 1000;
                    int palyLength = 2;
                    bool isSuccess=int.TryParse(ConfigurationManager.AppSettings["SoundPlayLength"],out palyLength);
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

                    if(playAlarm)
                    {
                        soundPlayer.PlayLooping();
                        //soundPlayer.Play();

                        System.Threading.Thread.Sleep(palyLength);
                        soundPlayer.Stop();
                    }

                    TimeSpan riskTime = getRiskTime();                    

                    //this.WindowState = FormWindowState.Maximized;
                    //MessageBox.Show("Session is ended. Take Break");
                    MessageBox.Show("Session is ended."
                        +"\nPrevious Non-Break Contineous Session Time : "+ riskTime.ToString(@"hh\:mm\:ss")
                        + "\nTake Break. Drink Water. Eat Food. Standup", 
                        "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    timer.Stop();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error Occured: "+ex.Message);
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


            TimeSpan totalSpan = new TimeSpan(0);
            foreach (var item in todaySessions)
            {
                totalSpan = totalSpan + (item.SessionEnd - item.SessionStart);
            }

            labelTotal.Text = totalSpan.ToString(@"hh\:mm\:ss");
            labelTotalElapses.Text = totalElapses.ToString();

            TimeSpan riskTime = getRiskTime();
            labelRiskTime.Text = riskTime.ToString(@"hh\:mm\:ss");
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


            labelTotal.Text = totalSpan.ToString(@"hh\:mm\:ss");
            labelTotalElapses.Text = totalElapses.ToString();

            TimeSpan riskTime = getRiskTime();
            labelRiskTime.Text= riskTime.ToString(@"hh\:mm\:ss");
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
            Session previousSession = new Session();

            TimeSpan firstTimeSpan = new TimeSpan(0);

            int i = todaySessions.Count;

            for(int j=i-1; j>=0;j--)
            {
                var item = todaySessions[j];

                count++;
                if (count == 1)
                {
                    previousSession = item;                    
                    firstTimeSpan = previousSession.SessionEnd - previousSession.SessionStart;
                    riskTime = riskTime + firstTimeSpan;                                            
                    continue;
                }

                TimeSpan twoSessionGap = item.SessionStart - previousSession.SessionEnd;

                // we only add if gap between two sessions is less than 15 minutes
                if ((twoSessionGap.Hours == 0) && (twoSessionGap.Minutes <= 15))
                {
                    TimeSpan currentDifference = item.SessionEnd - item.SessionStart;
                    riskTime = riskTime + currentDifference;
                }
                else
                {
                    break;
                }

                previousSession = item;
            }

            //foreach (var item in todaySessions)
            //{
                
            //}

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
    }
}
