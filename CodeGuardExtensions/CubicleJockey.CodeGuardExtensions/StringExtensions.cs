﻿using System;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method to IsNotNullOrWhiteSpace which allows a custom message
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<string> IsNotNullOrWhiteSpace(this IArg<string> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotNullOrWhiteSpace));
            try
            {
                Guard.That(arg.Value).IsNotNullOrWhiteSpace();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}
