using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ShowBatteryPercentageInTaskbar
{
    public partial class BatteryPercentage : Form
    {
        private Power power;
        private Timer powerCheckTimer;

        private bool warningShown = false;
        private bool numberShown = false;

        private int cleanupMemoryCount = 0;
        private int CLEANUP_MEMORY_MAX = 10;

        // TESTING
        //private int counter = 0;
        //private int counter_max = 2147483647;

        /// <summary>
        /// Constructor
        /// </summary>
        public BatteryPercentage()
        {
            InitializeComponent();

            power = new Power();
            updatePowerStatus();
            StartPowerCheckTimer();
        }

        /// <summary>
        /// Create Timer
        /// </summary>
        public void StartPowerCheckTimer()
        {
            powerCheckTimer = new Timer();
            powerCheckTimer.Tick += new EventHandler(powerCheckTimer_Tick);
            powerCheckTimer.Interval = 2000; // in miliseconds
            powerCheckTimer.Start();
        }

        /// <summary>
        /// What happens on every tick of the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void powerCheckTimer_Tick(object sender, EventArgs e)
        {
            updatePowerStatus();

            if (cleanupMemoryCount == CLEANUP_MEMORY_MAX)
            {
                cleanupMemoryCount = 0;
                checkMemoryUsage();
            }
            else
                cleanupMemoryCount++;
        }

        private void checkMemoryUsage()
        {
            GC.Collect();
            //long mem1 = GC.GetTotalMemory(false);
            //{
            //    // Allocate an array and make it unreachable.
            //    int[] values = new int[50000];
            //    values = null;
            //}
            //long mem2 = GC.GetTotalMemory(false);
            //{
            //    // Collect garbage.
            //    GC.Collect();
            //}
            //long mem3 = GC.GetTotalMemory(false);
            //{
            //    Debug.WriteLine(mem1);
            //    Debug.WriteLine(mem2);
            //    Debug.WriteLine(mem3);
            //}
        }

        /// <summary>
        /// Update the power values across the application
        /// </summary>
        private void updatePowerStatus()
        {
            string chargeStatus = power.getChargeStatus();
            string percAsString = power.getPercentageValue();
            bool isCharging = power.isCharging();

            string status = chargeStatus + ": " + percAsString;
            notifyIconBatteryPercentage.Text = status + "";
            notifyIconBatteryPercentage.BalloonTipText = status + "";

            //if (!isCharging)
            //{
                String timeRemaining = power.getBatteryLifeRemainingAsTime();
                Debug.WriteLine(timeRemaining);
                notifyIconBatteryPercentage.Text += "\n" + timeRemaining;
                notifyIconBatteryPercentage.BalloonTipText += "\n" + timeRemaining;
            //}

            int percAsInt = Convert.ToInt32(percAsString.Substring(0,percAsString.Length-1));

            if (numberShown && isCharging)
            {
                showBattery(percAsInt);
                numberShown = false;
            }
            else
            {
                showNumber(percAsInt, isCharging);
                numberShown = true;
            }

            // TESTING
            //if (counter == counter_max)
            //    counter = 0;

            //counter++;
            //Debug.WriteLine(counter + ": " + status);
        }

        /// <summary>
        ///  display battery icon (charging)
        /// </summary>
        /// <param name="percAsInt"></param>
        private void showBattery(int percAsInt)
        {
            if (percAsInt>0 && percAsInt<=10)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_0_10;
            else if (percAsInt>10 && percAsInt<=20)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_10_20;
            else if (percAsInt > 20 && percAsInt <= 30)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_20_30;
            else if (percAsInt > 30 && percAsInt <= 40)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_30_40;
            else if (percAsInt > 40 && percAsInt <= 50)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_40_50;
            else if (percAsInt > 50 && percAsInt <= 60)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_50_60;
            else if (percAsInt > 60 && percAsInt <= 70)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_60_70;
            else if (percAsInt > 70 && percAsInt <= 80)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_70_80;
            else if (percAsInt > 80 && percAsInt <= 90)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_80_90;
            else if (percAsInt > 90 && percAsInt < 100)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_90_100;
            else if (percAsInt == 100)
                notifyIconBatteryPercentage.Icon = Properties.Resources.charging_100;

        }

        /// <summary>
        /// display current battery percentage value
        /// </summary>
        /// <param name="percAsInt"></param>
        /// <param name="isCharging"></param>
        private void showNumber(int percAsInt, bool isCharging)
        {
            switch(percAsInt)
            {
                case 1: 
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_01;
                    break;
                case 2:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_02;
                    break;
                case 3:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_03;
                    break;
                case 4:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_04;
                    warningShown = false;
                    break;
                case 5:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_05;
                    if (!warningShown && !isCharging)
                    {
                        notifyIconBatteryPercentage.ShowBalloonTip(10);
                        warningShown = true;
                    }
                    break;
                case 6:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_06;
                    warningShown = false;
                    break;
                case 7:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_07;
                    break;
                case 8:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_08;
                    break;
                case 9:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_09;
                    warningShown = false;
                    break;
                case 10:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_10;
                    if (!warningShown && !isCharging)
                    {
                        notifyIconBatteryPercentage.ShowBalloonTip(10);
                        warningShown = true;
                    }
                    break;
                case 11:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_11;
                    warningShown = false;
                    break;
                case 12:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_12;
                    break;
                case 13:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_13;
                    break;
                case 14:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_14;
                    break;
                case 15:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_15;
                    break;
                case 16:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_16;
                    break;
                case 17:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_17;
                    break;
                case 18:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_18;
                    break;
                case 19:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_19;
                    warningShown = false;
                    break;
                case 20:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_20;
                    if (!warningShown && !isCharging)
                    {
                        notifyIconBatteryPercentage.ShowBalloonTip(10);
                        warningShown = true;
                    }
                    break;
                case 21:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_21;
                    warningShown = false;
                    break;
                case 22:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_22;
                    break;
                case 23:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_23;
                    break;
                case 24:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_24;
                    break;
                case 25:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_25;
                    break;
                case 26:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_26;
                    break;
                case 27:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_27;
                    break;
                case 28:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_28;
                    break;
                case 29:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_29;
                    break;
                case 30:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_30;
                    break;
                case 31:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_31;
                    break;
                case 32:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_32;
                    break;
                case 33:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_33;
                    break;
                case 34:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_34;
                    break;
                case 35:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_35;
                    break;
                case 36:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_36;
                    break;
                case 37:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_37;
                    break;
                case 38:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_38;
                    break;
                case 39:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_39;
                    break;
                case 40:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_40;
                    break;
                case 41:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_41;
                    break;
                case 42:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_42;
                    break;
                case 43:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_43;
                    break;
                case 44:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_44;
                    break;
                case 45:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_45;
                    break;
                case 46:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_46;
                    break;
                case 47:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_47;
                    break;
                case 48:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_48;
                    break;
                case 49:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_49;
                    break;
                case 50:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_50;
                    break;
                case 51:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_51;
                    break;
                case 52:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_52;
                    break;
                case 53:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_53;
                    break;
                case 54:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_54;
                    break;
                case 55:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_55;
                    break;
                case 56:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_56;
                    break;
                case 57:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_57;
                    break;
                case 58:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_58;
                    break;
                case 59:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_59;
                    break;
                case 60:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_60;
                    break;
                case 61:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_61;
                    break;
                case 62:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_62;
                    break;
                case 63:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_63;
                    break;
                case 64:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_64;
                    break;
                case 65:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_65;
                    break;
                case 66:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_66;
                    break;
                case 67:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_67;
                    break;
                case 68:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_68;
                    break;
                case 69:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_69;
                    break;
                case 70:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_70;
                    break;
                case 71:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_71;
                    break;
                case 72:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_72;
                    break;
                case 73:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_73;
                    break;
                case 74:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_74;
                    break;
                case 75:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_75;
                    break;
                case 76:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_76;
                    break;
                case 77:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_77;
                    break;
                case 78:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_78;
                    break;
                case 79:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_79;
                    break;
                case 80:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_80;
                    break;
                case 81:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_81;
                    break;
                case 82:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_82;
                    break;
                case 83:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_83;
                    break;
                case 84:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_84;
                    break;
                case 85:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_85;
                    break;
                case 86:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_86;
                    break;
                case 87:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_87;
                    break;
                case 88:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_88;
                    break;
                case 89:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_89;
                    break;
                case 90:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_90;
                    break;
                case 91:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_91;
                    break;
                case 92:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_92;
                    break;
                case 93:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_93;
                    break;
                case 94:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_94;
                    break;
                case 95:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_95;
                    break;
                case 96:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_96;
                    break;
                case 97:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_97;
                    break;
                case 98:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_98;
                    break;
                case 99:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_99;
                    warningShown = false;
                    break;
                case 100:
                    notifyIconBatteryPercentage.Icon = Properties.Resources.battery_100;
                    if (!warningShown && isCharging)
                    {
                        notifyIconBatteryPercentage.Text = "Fully Charged. Unplug your power supply.";
                        notifyIconBatteryPercentage.BalloonTipText = "Fully Charged. Unplug your power supply.";
                        notifyIconBatteryPercentage.ShowBalloonTip(10);
                        warningShown = true;
                    }
                    break;

            }
        }

        /// <summary>
        /// LEFT MOUSE CLICK SHOWS BALLOON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconBatteryPercentage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIconBatteryPercentage.ShowBalloonTip(10);
            }
        }




        #region context menu
        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            powerCheckTimer.Stop();
            powerCheckTimer.Dispose();
            notifyIconBatteryPercentage.Dispose();
            //this.Dispose();
            Application.Exit();

        }

        #endregion

        #region form

 
        private void pictureBoxX_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion


    }
}
