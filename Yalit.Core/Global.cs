using System;
using System.Collections.Generic;
using System.Text;

namespace Yalit.Core
{
    using System;
    using System.Net.NetworkInformation;
    using System.Globalization;
    using System.Reflection;
    using System.Collections.Generic;

    namespace Yalit
    {
        /// <summary>
        /// کلاس عمومی
        /// </summary>
        public static class Global
        {
            ///<summary>
            /// تبدیل هر شی در صورت امکان به نوع عددی
            /// </summary>
            /// <param name="str">شی برا تبدیل به داده عددی</param>
            /// <returns>در صورت تبدیل پذیری شی به عدد، مقدار آن و در غیر اینصورت مقدار صفر برگردانده میشود</returns>
            public static int ToInt(this object str)
            {
                if (str == null || str == DBNull.Value)
                {
                    return 0;
                }
                try
                {
                    return Convert.ToInt32(str);
                }
                catch
                {
                    return 0;
                }
            }

            /// <summary>
            /// تبدیل انواع مختلف به Double
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            public static double ToDouble(this object val)
            {
                if (double.TryParse(val.ToString(), out var number))
                {
                    return number;
                }
                else
                {
                    return 0;
                }
            }
            public static decimal ToDecimal(this object val)
            {
                if (decimal.TryParse(val.ToString(), out var res))
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
            /// <summary>
            /// تبدیل هر شی در صورت امکان به نوع بولین
            /// </summary>
            /// <param name="str">شی برا تبدیل به داده عددی</param>
            /// <returns>در صورت تبدیل پذیری شی به بولین، مقدار آن و در غیر اینصورت مقدار False برگردانده میشود</returns>
            public static Boolean ToBoolean(this object str)
            {
                if (bool.TryParse(str?.ToString(), out bool res))
                {
                    return res;
                }
                else
                {
                    return false;
                }
            }
            /// <summary>
            /// تبدیل یک عدد به تعداد ارقام کمتر
            /// </summary>
            /// <param name="str">The string.</param>
            /// <param name="len">The length.</param>
            /// <returns>System.String.</returns>
            public static string ToLowLengh(this object str, int len)
            {
                if (str == null)
                {
                    string se = "";
                    for (int i = se.Length; i < len; i++)
                    {
                        se = "0" + se;
                    }
                    return se;
                }
                try
                {
                    string s = str.ToString();
                    if (s.Length > len)
                    {
                        s = s.Substring((s.Length - len), len);
                    }
                    return s;
                }
                catch
                {
                    string se = "";
                    for (int i = se.Length; i < len; i++)
                    {
                        se = "0" + se;
                    }
                    return se;
                }
            }
            /// <summary>
            /// To the length.
            /// </summary>
            /// <param name="str">The string.</param>
            /// <param name="len">The length.</param>
            /// <returns>System.String.</returns>
            public static string ToLengh(this object str, int len)
            {
                try
                {
                    int a = str.ToInt();
                    string s = a.ToString();
                    for (int i = s.Length; i < len; i++)
                    {
                        s = "0" + s;
                    }
                    //if (s.Length > len)
                    //{
                    //    s = s.Substring(0, len);
                    //}
                    return s;
                }
                catch
                {
                    string se = "";
                    for (int i = se.Length; i < len; i++)
                    {
                        se = "0" + se;
                    }
                    return se;
                }
            }
            /// <summary>
            /// To the Specific length.
            /// </summary>
            /// <param name="str">The string.</param>
            /// <param name="len">The length.</param>
            /// <param name="nullValue">The null value.</param>
            /// <returns>System.String.</returns>
            public static string ToLengh(this object str, int len, char nullValue)
            {
                try
                {
                    int a = Convert.ToInt32(str);
                    string s = a.ToString();
                    for (int i = s.Length; i < len; i++)
                    {
                        s = "0" + s;
                    }
                    //if (s.Length > len)
                    //{
                    //    s = s.Substring(0, len);
                    //}
                    return s;
                }
                catch
                {
                    string se = "";
                    for (int i = se.Length; i < len; i++)
                    {
                        se = nullValue + se;
                    }
                    return se;
                    //Yalit.Properties.Resources.
                }
            }
            /// <summary>
            /// Replace Arabic char with Farsi Char
            /// </summary>
            /// <param name="str">The string.</param>
            /// <returns>System.String.</returns>
            public static string FixFaChar(this object str)
            {
                try
                {
                    if (str == null || str == DBNull.Value)
                    {
                        return string.Empty;
                    }
                    string s = str.ToString().Trim();
                    s = s.Replace("ك", "ک");
                    return s.Replace("ي", "ی");
                }
                catch
                {
                    return string.Empty;
                }
            }
            /// <summary>
            /// تبدیل همه چی به استرینگ
            /// </summary>
            /// <param name="str">The string.</param>
            /// <param name="returnValue">مقدار برگشتی در صورت ناموفق بودن کانورت یا خالی بودن رشته</param>
            /// <returns>System.String.</returns>
            public static string FixFaChar(this object str, string returnValue)
            {
                try
                {
                    if (str == null)
                    {
                        return returnValue;
                    }
                    string s = str.ToString().Trim();
                    if (string.IsNullOrEmpty(s))
                    {
                        return returnValue;
                    }
                    s = s.Replace("ك", "ک");
                    return s.Replace("ي", "ی");
                }
                catch
                {
                    return returnValue;
                }
            }
            /// <summary>
            /// Fixes the ye.
            /// </summary>
            /// <param name="str">The string.</param>
            /// <param name="returnValue">The return value.</param>
            /// <returns>System.Object.</returns>
            public static object FixFaChar(this object str, object returnValue)
            {
                try
                {
                    if (str == null)
                    {
                        return returnValue;
                    }
                    string s = str.ToString().Trim();
                    if (string.IsNullOrEmpty(s))
                    {
                        return returnValue;
                    }
                    s = s.Replace("ك", "ک");
                    return s.Replace("ي", "ی");
                }
                catch
                {
                    return returnValue;
                }
            }
            /// <summary>
            /// چک کردن برابر بودن مقدار ورودی با مقداری مشخص . برگرداندن مقدار دلخواه در صورت برقراری شرط
            /// </summary>
            /// <param name="str">مقدار ورودی</param>
            /// <param name="returnValue">مقدار برگشتی در صورت برقرار بودن شرط</param>
            /// <param name="condition">مقداری که ورودی با آن چک میشود</param>
            /// <returns>System.String.</returns>
            public static string FixFaChar(this object str, string returnValue, string condition)
            {
                try
                {
                    if (str == null)
                    {
                        return returnValue;
                    }
                    string s = str.ToString().Trim();
                    s = s.Replace("ك", "ک");
                    s = s.Replace("ي", "ی");
                    if (s == condition || s == string.Empty)
                    {
                        return returnValue;
                    }
                    return s;
                }
                catch
                {
                    return returnValue;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="strSource">متن مورد بررسی</param>
            /// <param name="strStart">بخش اولیه تگ</param>
            /// <param name="strEnd">بخش انتهای تگ</param>
            /// <returns>در صورت وجود مقدار تگ در غیر این صورت مقدار خالی</returns>
            public static string GetTagValue(this string strSource, string strStart, string strEnd)
            {
                int Start, End;
                if (strSource.Contains(strStart) && strSource.Contains(strEnd))
                {
                    Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    return strSource.Substring(Start, End - Start);
                }
                else
                {
                    return string.Empty;
                }
            }
            /// <summary>
            /// تبدیل اعداد انگلیسی به فارسی.
            /// </summary>
            /// <param name="str">The string.</param>
            /// <returns>System.String.</returns>
            public static string FixFaNumber(this object str)
            {
                try
                {
                    string s = str.ToString();
                    s = s.Trim().Replace("0", "۰");
                    s = s.Trim().Replace("1", "۱");
                    s = s.Trim().Replace("2", "۲");
                    s = s.Trim().Replace("3", "۳");
                    s = s.Trim().Replace("4", "۴");
                    s = s.Trim().Replace("5", "۵");
                    s = s.Trim().Replace("6", "۶");
                    s = s.Trim().Replace("7", "۷");
                    s = s.Trim().Replace("8", "۸");
                    return s.Trim().Replace("9", "۹");

                }
                catch
                {
                    return string.Empty;
                }
            }

            /// <summary>
            /// تابع تبدیل ماه عددی به معادل متنی فارسی آن
            /// </summary>
            /// <example>
            /// این کد ماهی که در آن هستیم را به صورت متنی برمیگرداند
            /// <code>
            /// string persianMonth = DateTime.Now.ToFaDate("M").toFaMonth(); 
            /// </code></example>
            /// <param name="month">اعدادی بین ۱ تا ۱۲</param>
            /// <returns>معادل متنی ماه مورد نظر</returns>
            /// <seealso cref="ToFaDate(DateTime, string)"/>
            public static string ToFaMonth(this int month)
            {
                switch (month)
                {
                    case 1:
                        return "فروردین";
                    case 2:
                        return "اردیبهشت";
                    case 3:
                        return "خرداد";
                    case 4:
                        return "تیر";
                    case 5:
                        return "مرداد";
                    case 6:
                        return "شهریور";
                    case 7:
                        return "مهر";
                    case 8:
                        return "آبان";
                    case 9:
                        return "آذر";
                    case 10:
                        return "دی";
                    case 11:
                        return "بهمن";
                    case 12:
                        return "اسفند";
                    default:
                        return string.Empty;
                }
            }
            /// <summary>
            /// چک کردن ارتباط با اینترنت
            /// </summary>
            /// <param name="url">The URL to Check.</param>
            /// <returns><c>true</c> if Internet connection is established, <c>false</c> otherwise.</returns>
            public static bool CheckInternetConnection(string url = "www.google.com")
            {
                try
                {
                    System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry(url);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            /// <summary>
            /// Convert Persian Date To Gregorian Date
            /// </summary>
            /// <param name="str">the string</param>
            /// <example>"1391/01/01".ToGergoian()</example>
            /// <returns> Gregorian Date </returns>
            /// <exception cref="FormatException"></exception>
            public static DateTime ToGregorian(this string persianDate)
            {
                string obj = persianDate.Replace("/", "");

                if (obj.Length == 8)
                {
                    DateTime dt = new DateTime(obj.Substring(0, 4).ToInt(), obj.Substring(4, 2).ToInt(), obj.Substring(6, 2).ToInt(), new PersianCalendar());
                    return dt;
                }
                else if (obj.Length == 6)
                {
                    DateTime dt = new DateTime(("13" + obj.Substring(0, 2)).ToInt(), obj.Substring(2, 2).ToInt(), obj.Substring(4, 2).ToInt(), new PersianCalendar());
                    return dt;
                }
                else
                {
                     throw new FormatException("Bad Date String");
                }
            }

            private static CultureInfo _Culture;
            /// <summary>
            /// Persian Calcure
            /// </summary>
            /// <returns>Persian Fixed Culture</returns>
            public static CultureInfo GetPersianCulture()
            {
                if (_Culture == null)
                {
                    _Culture = new CultureInfo("fa-IR");
                    DateTimeFormatInfo formatInfo = _Culture.DateTimeFormat;
                    formatInfo.AbbreviatedDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
                    formatInfo.DayNames = new[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنجشنبه", "جمعه", "شنبه" };
                    var monthNames = new[]
                    {
                    "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن",
                    "اسفند",
                    ""
                };
                    formatInfo.AbbreviatedMonthNames =
                        formatInfo.MonthNames =
                        formatInfo.MonthGenitiveNames = formatInfo.AbbreviatedMonthGenitiveNames = monthNames;
                    formatInfo.AMDesignator = "ق.ظ";
                    formatInfo.PMDesignator = "ب.ظ";
                    formatInfo.ShortDatePattern = "yyyy/MM/dd";
                    formatInfo.LongDatePattern = "dddd, dd MMMM,yyyy";
                    formatInfo.FirstDayOfWeek = DayOfWeek.Saturday;
                    System.Globalization.Calendar cal = new PersianCalendar();

                    FieldInfo fieldInfo = _Culture.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (fieldInfo != null)
                        fieldInfo.SetValue(_Culture, cal);

                    FieldInfo info = formatInfo.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (info != null)
                        info.SetValue(formatInfo, cal);

                    _Culture.NumberFormat.NumberDecimalSeparator = "/";
                    _Culture.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
                    _Culture.NumberFormat.NumberNegativePattern = 0;
                }
                return _Culture;
            }

            /// <summary>
            /// تبدیل تاریخ میلادی به تاریخ خورشیدی
            /// </summary>
            /// <param name="date">تاریخ ورودی میلادی</param>
            /// <param name="format">فرمت خروجی</param>
            /// <example><code>DateTime.Now.ToPeString("yy/MM/dd HH:mm:ss");</code></example>
            /// <returns>System.String.</returns>
            public static string ToPersianDate(this DateTime date, string format = "yyyy/MM/dd")
            {
                return date.ToString(format, GetPersianCulture());
            }
        }

    }
}
