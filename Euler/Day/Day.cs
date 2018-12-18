using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Day
{
    
    interface IDay
    {
        string GetDayName(DateTime today);
        bool IsNabor();
        bool IsJashn();
    }
    public class Day : IDay
    {
        private PersianCalendar _pc;
        public Day(PersianCalendar pc)
        {
            _pc = pc;
        }
        public string[] DayNames =
            new string[30]
            {
                "اورمزد", "وهمن", "اردیبهشت", "شهریور", "سپندارمذ", "خرداد", "امرداد", "دی به آذر", "آذر", "آبان", "خور",
                "ماه", "تیر", "گوش", "دی به مهر", "مهر", "سروش", "رشن", "فروردین", "ورهرام", "رام", "باد", "دی به دین",
                "دین", "ارد", "اشتاد", "آسمان", "زامیاد", "مانتره سپند", "انا رام"
            };

        public string[] ExtraDayNames = new string[6] {"اهنود","اشتود","سپندمد","وهوخشتر","وهیشتوایش","اورداد"}; 
        public string GetDayName(DateTime today)
        {
            var dayOfYear = _pc.GetDayOfYear(today);
            if (dayOfYear > 365)
            {
                return ExtraDayNames[(dayOfYear%30) - 1];
            }
            else
            {
                return DayNames[(dayOfYear%30) -1];

            }

        }

        public bool IsJashn()
        {
            throw new NotImplementedException();
        }

        public bool IsNabor()
        {
            throw new NotImplementedException();
        }
    }
}
