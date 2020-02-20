
    /// <summary>
    /// Indicates that there are four quarters in a calendar year
    /// </summary>
    public enum Quarter
    {
        /// <summary>
        /// Indicates January 1 to March 31
        /// </summary>
        First = 1,
        /// <summary>
        /// Indicates April 1 to June 30
        /// </summary>
        Second = 2,
        /// <summary>
        /// Indicates July 1 to September 30
        /// </summary>
        Third = 3,
        /// <summary>
        /// Indicates October 1 to December 31 
        /// </summary>
        Fourth = 4
    }

    /// <summary>
    /// Specifies the months of the year.
    /// </summary>
    public enum Month
    {
        /// <summary>
        /// Indicates January.
        /// </summary>
        January = 1,
        /// <summary>
        /// Indicates February
        /// </summary>
        February = 2,
        /// <summary>
        /// Indicates March
        /// </summary>
        March = 3,
        /// <summary>
        /// Indicates April
        /// </summary>
        April = 4,
        /// <summary>
        /// Indicates May
        /// </summary>
        May = 5,
        /// <summary>
        /// Indicates June
        /// </summary>
        June = 6,
        /// <summary>
        /// Indicates July
        /// </summary>
        July = 7,
        /// <summary>
        /// Indicates August
        /// </summary>
        August = 8,
        /// <summary>
        /// Indicates September
        /// </summary>
        September = 9,
        /// <summary>
        /// Indicates October
        /// </summary>
        October = 10,
        /// <summary>
        /// Indicates November
        /// </summary>
        November = 11,
        /// <summary>
        /// Indicates December
        /// </summary>
        December = 12,
    }

    public class DateUtility
    {
        /// <summary>
        /// Get the start of a quarter
        /// </summary>
        /// <param name="Year">The year (1 through 9999).</param>
        /// <param name="Qtr">This is a <see cref="Quarter"/> (First through Fourth).</param>
        /// <returns>An object that is equivalent to the System.DateTime object. The DateTime object will denote the start of a <see cref="Quarter"/>.</returns>
        public static DateTime GetStartOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)
                return new DateTime(Year, 1, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Second)
                return new DateTime(Year, 4, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Third)
                return new DateTime(Year, 7, 1, 0, 0, 0, 0);
            else
                return new DateTime(Year, 10, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get the end of a quarter
        /// </summary>
        /// <param name="Year">The year (1 through 9999).</param>
        /// <param name="Qtr">This is a <see cref="Quarter"/> (First through Fourth).</param>
        /// <returns>An object that is equivalent to the System.DateTime object. The DateTime object will denote the end of a <see cref="Quarter"/>.</returns>
        public static DateTime GetEndOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)
                return new DateTime(Year, 3, DateTime.DaysInMonth(Year, 3), 23, 59, 59, 999);
            else if (Qtr == Quarter.Second)
                return new DateTime(Year, 6, DateTime.DaysInMonth(Year, 6), 23, 59, 59, 999);
            else if (Qtr == Quarter.Third)
                return new DateTime(Year, 9, DateTime.DaysInMonth(Year, 9), 23, 59, 59, 999);
            else
                return new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        /// <summary>
        /// Indicate the Quarter
        /// </summary>
        /// <param name="Month"> One of the enumeration values that indicates whether month specify a calendar month (January to December).</param>
        /// <returns>An enumeration value of one of the four quarters in a calendar year <see cref="Month"/></returns>
        public static Quarter GetQuarter(Month Month)
        {
            if (Month <= Month.March)
                return Quarter.First;
            else if ((Month >= Month.April) && (Month <= Month.June))
                return Quarter.Second;
            else if ((Month >= Month.July) && (Month <= Month.September))
                return Quarter.Third;
            else
                return Quarter.Fourth;
        }

        /// <summary>
        /// Get the end of last quarter
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetEndOfLastQuarter()
        {
            if ((Month)DateTime.Now.Month <= Month.March)
                return GetEndOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else
                return GetEndOfQuarter(DateTime.Now.Year,
                    GetQuarter((Month)DateTime.Now.Month));
        }

        /// <summary>
        /// Get the start of last quarter
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetStartOfLastQuarter()
        {
            if ((Month)DateTime.Now.Month <= Month.March)
                return GetStartOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else
                return GetStartOfQuarter(DateTime.Now.Year,
                    GetQuarter((Month)DateTime.Now.Month));
        }

        /// <summary>
        /// Get the start of the current quarter
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetStartOfCurrentQuarter()
        {
            return GetStartOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        /// <summary>
        /// Get the end of the current quarter
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetEndOfCurrentQuarter()
        {
            return GetEndOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        /// <summary>
        /// Get the start of last week
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetStartOfLastWeek()
        {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek + 7;
            DateTime dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));

            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get the end of last week
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetEndOfLastWeek()
        {
            DateTime dt = GetStartOfLastWeek().AddDays(6);

            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Get the start of the current week
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetStartOfCurrentWeek()
        {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek;
            DateTime dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));

            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get the end of the current week
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetEndOfCurrentWeek()
        {
            DateTime dt = GetStartOfCurrentWeek().AddDays(6);

            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Get the start of a month
        /// </summary>
        /// <param name="Month">One of the enumeration values that indicates whether month specify a calendar <see cref="Month"/> (January to December).</param>
        /// <param name="Year">The year (1 through 9999).</param>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetStartOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get the end of a month
        /// </summary>
        /// <param name="Month">One of the enumeration values that indicates whether month specify a calendar <see cref="Month"/> (January to December).</param>
        /// <param name="Year">The year (1 through 9999).</param>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetEndOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month, DateTime.DaysInMonth(Year, (int)Month), 23, 59, 59, 999);
        }


        /// <summary>
        /// Get the start of the last month
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetStartOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetStartOfMonth(Month.December, DateTime.Now.Year - 1);
            else
                return GetStartOfMonth((Month)(DateTime.Now.Month - 1), DateTime.Now.Year);
        }

        /// <summary>
        /// Get the end of the last month
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetEndOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetEndOfMonth(Month.December, DateTime.Now.Year - 1);
            else
                return GetEndOfMonth((Month)(DateTime.Now.Month - 1), DateTime.Now.Year);
        }

        /// <summary>
        /// Get the start of the current month
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth((Month)DateTime.Now.Month, DateTime.Now.Year);
        }

        /// <summary>
        /// Get the end of the current month
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object.</returns>
        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth((Month)DateTime.Now.Month, DateTime.Now.Year);
        }

        /// <summary>
        /// Get the start of the year specified.
        /// </summary>
        /// <param name="Year">The year (1 through 9999).</param>
        /// <returns>An object that is equivalent to the System.DateTime object</returns>
        public static DateTime GetStartOfYear(int Year)
        {
            return new DateTime(Year, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get the end of the year specified
        /// </summary>
        /// <param name="Year">The year (1 through 9999).</param>
        /// <returns>An object that is equivalent to the System.DateTime object</returns>
        public static DateTime GetEndOfYear(int Year)
        {
            return new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        /// <summary>
        /// Get the start of last year.
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object</returns>
        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        /// <summary>
        /// Get the end of last year.
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object</returns>
        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        /// <summary>
        /// Get the start of the current year.
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object</returns>
        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(DateTime.Now.Year);
        }

        /// <summary>
        /// Get the end of the current year.
        /// </summary>
        /// <returns>An object that is equivalent to the System.DateTime object</returns>
        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(DateTime.Now.Year);
        }

        /// <summary>
        /// Get the start of the day.
        /// </summary>
        /// <param name="date">A DateTime object</param>
        /// <returns>An object that is equivalent to the System.DateTime object</returns>
        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get the end of the day.
        /// </summary>
        /// <param name="date">A DateTime object</param>
        /// <returns>An object that is equivalent to the System.DateTime object</returns>
        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Get the week number of a year
        /// </summary>
        /// <param name="date">A DateTime object</param>
        /// <returns>An integer that indicates week (1 through 53).</returns>
        public static int GetAnnualWeekNumber(DateTime date)
        {
            var _culture = CultureInfo.CurrentCulture;

            return _culture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    }
