using System;
namespace Library
{
    public class WorkingHours
    {
        /* This class represents a set of operating hours. 
         * It has an opening hours and a closing hour.
         */

        private int openingHour;
        private int closingHour; 

        // constructor -- input the opening and closing hour 
        public WorkingHours(int openingHour, int closingHour)
        {
            this.openingHour = openingHour;
            this.closingHour = closingHour; 
        }

    }
}
