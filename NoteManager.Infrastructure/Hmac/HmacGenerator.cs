﻿using System;

namespace NoteManager.Infrastructure.Hmac
{
    public static class HmacGenerator
    {
        public static string PublicKey()
        {
            return Guid.NewGuid().ToString();
        }

        public static string Timespan()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}