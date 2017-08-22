﻿using System;
using System.Globalization;
using NoteManager.Infrastructure.Dates.Enums;
using NoteManager.Infrastructure.Enums;
using NoteManager.Infrastructure.Objects;

namespace NoteManager.Infrastructure.Dates
{
    public static class DateConvert
    {
        public static string ToDateStringDb(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy");
        }

        public static string ToDateTimeStringDb(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy HH:mm:ss");
        }
        
        public static DateTime DateStringToDateTimeDb(this string date)
        {
            return DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        public static DateTime DateTimeStringToDateTimeDb(this string dateTime)
        {
            return DateTime.ParseExact(dateTime, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss");
        }

        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }

        public static string ToDateString(this DateTime? dateTime)
        {
            if (dateTime.IsNull())
                return null;

            return dateTime.Value.ToString("dd/MM/yyyy");
        }

        public static string ToDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm:ss");
        }
        
        public static DateTime DateStringToDateTime(this string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static DateTime DateTimeStringToDateTime(this string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static bool IsValidDayOfWeek()
        {
            var dayOfWeek = (int)DateTime.Now.DayOfWeek;
            var monday = EDayWeek.Monday.GetValue();
            var friday = EDayWeek.Friday.GetValue();
            return monday <= dayOfWeek && friday >= dayOfWeek;
        }

        public static bool IsValidHour()
        {
            var hourStart = DateTime.ParseExact("01:00:00", "HH:mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
            var hourEnd = DateTime.ParseExact("09:10:00", "HH:mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
            var hourToday = DateTime.ParseExact(DateTime.Now.ToTimeString(), "HH:mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
            return hourStart <= hourToday && hourEnd >= hourToday;
        }
    }
}