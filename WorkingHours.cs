using System;
namespace StoreManager
{
    public class WorkingHours
    {
        private int openingHour;
        private int closingHour;

        // the store manager creates a WorkingHours object to represent his store's opening and closing hours 
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
    }
}
