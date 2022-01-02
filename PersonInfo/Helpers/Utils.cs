using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonInfo.Helpers
{
    public static class Utils
    {
        public static short CalculateAge(DateTime dob)
        {
            short years = (short)(DateTime.Now.Year - dob.Year);

            if ((dob.Month > DateTime.Now.Month) || (dob.Month == DateTime.Now.Month && dob.Day > DateTime.Now.Day))
                years--;

            return years;
        }
    }
}
