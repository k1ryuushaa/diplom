using System;
using System.Collections.Generic;
using System.Text;

namespace ArtRoyalDetailing.Domain.Extensions
{
    public static class ModelValidation
    {
        public static DateTime? TryGetDate(this string date)
        {
            try
            {
                DateTime _date  = DateTime.Parse(date);
                return _date;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static TimeSpan? TryGetTime(this string time)
        {
            try
            {
                TimeSpan _time = TimeSpan.Parse(time);
                return _time;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
