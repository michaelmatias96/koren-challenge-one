using System;
namespace StoreManager
{
    public class WorkingHours
    {
        private int openingHour;
        private int closingHour;

        public WorkingHours(int openingHour, int closingHour)
        {
            this.openingHour = openingHour;
            this.closingHour = closingHour;
        }

        public int GetOpeningHour()
        {
            return openingHour;
        }

        public int GetClosingHour()
        {
            return closingHour;
        }

        public string toString()
        {
            return "Opening hour: " + openingHour + ". Closing Hour: " + closingHour;
        }

        public string GetStringWorkingHours()
        {
            return "Opening hour: " + openingHour + ". Closing Hour: " + closingHour;
        }
    }
}
