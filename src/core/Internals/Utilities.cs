﻿using System;
using System.Text;

namespace TurtleRoute
{
    internal static class Utilities
    {
        /// <summary>
        /// Converts the string into a Base64 string
        /// </summary>
        /// <param name="plainText">The text to encode</param>
        /// <returns>The same string but encoded</returns>
        internal static string Base64Encode(this string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}