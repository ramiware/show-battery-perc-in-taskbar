using System;
using System.Windows.Forms;

namespace ShowBatteryPercentageInTaskbar
{
    class Power
    {
        private PowerStatus pwr = SystemInformation.PowerStatus;

        /// <summary>
        /// Returns the current percentage of the battery charge
        /// </summary>
        /// <returns></returns>
        internal string getPercentageValue()
        {
            String strBatterylife;
            strBatterylife = (Convert.ToInt32(pwr.BatteryLifePercent * 100)).ToString() + "%";

            return strBatterylife;
        }

        /// <summary>
        /// Returns a value indicating the current charging status of the battery
        /// </summary>
        /// <returns></returns>
        internal string getChargeStatus()
        {
            PowerLineStatus powerLineStatus;
            powerLineStatus = pwr.PowerLineStatus;

            if (powerLineStatus.Equals(PowerLineStatus.Offline))
                return PowerStatusOptions.NOT_CHARGING;
            else if (powerLineStatus.Equals(PowerLineStatus.Online))
                return PowerStatusOptions.CHARGING;
            else
                return PowerStatusOptions.CHARGING_STATUS_UNKNOWN;
        }

        /// <summary>
        /// Returns a boolean indiciting if the battery is currenty charging or not
        /// </summary>
        /// <returns></returns>
        internal bool isCharging()
        {
            PowerLineStatus powerLineStatus;
            powerLineStatus = pwr.PowerLineStatus;

            if (powerLineStatus.Equals(PowerLineStatus.Online))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns the time remaining of the battery power
        /// </summary>
        /// <returns></returns>
        internal string getBatteryLifeRemainingAsTime()
        {
            //if (isCharging())
            //    return "";

            int timeRemaining = pwr.BatteryLifeRemaining;

            TimeSpan time = TimeSpan.FromSeconds(pwr.BatteryLifeRemaining);
            int hourVal = int.Parse(time.ToString(@"hh"));
            int minVal = int.Parse(time.ToString(@"mm"));

            String lifeVal = "";
            // handle hours
            if (hourVal == 1)
                lifeVal += hourVal + " hour";
            else if (hourVal > 1)
                lifeVal += hourVal + " hours";
            // handle 'and'
            if (hourVal>0)
                lifeVal += " and ";
            // hand minutes
            if (minVal == 1)
                lifeVal += minVal + " minute";
            else if (minVal > 1)
                lifeVal += minVal + " minutes";

            // text
            if (lifeVal.Length>0)
                lifeVal += " remaining";

            return lifeVal;
        }
    }
}
