﻿using TST.CORE.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TST.CORE.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ElapsedTime(this DateTime dateTime)
        {
            var dateTimeSubstract = DateTime.UtcNow.Subtract(dateTime);
            var dayDifference = (int)dateTimeSubstract.TotalDays;
            var secondsDifference = (int)dateTimeSubstract.TotalSeconds;

            if (dayDifference < 0 || dayDifference >= 31)
            {
                return null;
            }

            if (dayDifference == 0)
            {
                if (secondsDifference < 10)
                {
                    return "ahora";
                }

                if (secondsDifference < 60)
                {
                    return $"{secondsDifference} segundos";
                }

                if (secondsDifference < 120)
                {
                    return "1 minuto";
                }

                if (secondsDifference < 3600)
                {
                    return $"{ Math.Floor((double)secondsDifference / 60) } minutos";
                }
                if (secondsDifference < 7200)
                {
                    return "1 hora";
                }

                if (secondsDifference < 86400)
                {
                    return $"{ Math.Floor((double)secondsDifference / 3600) } horas";
                }
            }

            if (dayDifference == 1)
            {
                return "ayer";
            }

            if (dayDifference < 7)
            {
                return $"{ dayDifference } días";
            }

            if (dayDifference < 31)
            {
                return $"{ Math.Ceiling((double)dayDifference / 7) } semanas";
            }

            return null;
        }

        public static string ElapsedTime(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ElapsedTime();
            }

            return null;
        }
        public static DateTime ToDefaultTimeZone(this DateTime dateTime)
        {
            var destinationTimeZone = new TimeSpan(ConstantHelpers.TIMEZONEINFO.Gmt, 00, 00).ToCustomTimeZone();
            var result = TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
            return result;
        }

        public static DateTime? ToDefaultTimeZone(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToDefaultTimeZone();
            }

            return null;
        }

        public static string ToLocalDateFormat(this DateTime dateTime)
        {
            return dateTime.ToDefaultTimeZone().ToString(ConstantHelpers.FORMATS.DATE, CultureInfo.InvariantCulture);
        }

        public static string ToLocalDateFormat(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToLocalDateFormat();
            }

            return null;
        }

        public static string ToLocalDateTimeFormat(this DateTime dateTime)
        {
            return dateTime.ToDefaultTimeZone().ToString(ConstantHelpers.FORMATS.DATETIME, CultureInfo.InvariantCulture);
        }

        public static string ToLocalDateTimeFormat(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToLocalDateTimeFormat();
            }

            return null;
        }
        public static DateTime ToUtcDateTime(this DateTime dateTime)
        {
            var result = TimeZoneInfo.ConvertTimeToUtc(dateTime, ConvertHelpers.FindOperatingSystemTimeZoneById(ConstantHelpers.TIMEZONEINFO.LINUX_TIMEZONE_ID, ConstantHelpers.TIMEZONEINFO.OSX_TIMEZONE_ID, ConstantHelpers.TIMEZONEINFO.WINDOWS_TIMEZONE_ID));
            return result;
        }
    }
}
