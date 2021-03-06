﻿using System;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class Int16Extensions
    {

        /// <summary>
        /// Extensions method to add IsPositive
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<short> IsPositive(this IArg<short> arg)
        {
            if (arg.Value < 0)
            {
                throw new ArgumentException("Value cannot be negative.");
            }
            return arg;
        }

        /// <summary>
        /// Extensions method to add a Custom Message to IsPositive
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsPositive(this IArg<short> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsPositive));
            try
            {
                Guard.That(arg.Value).IsPositive();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add IsNegative
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<short> IsNegative(this IArg<short> arg)
        {
            if (arg.Value >= 0)
            {
                throw new ArgumentException("Value cannot be positive.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsNegative
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsNegative(this IArg<short> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNegative));
            try
            {
                Guard.That(arg.Value).IsNegative();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add IsEven
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<short> IsEven(this IArg<short> arg)
        {
            if(arg.Value % 2 != 0)
            {
                throw new ArgumentException("Value must be even.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsEven
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsEven(this IArg<short> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEven));
            try
            {
                Guard.That(arg.Value).IsEven();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a IsOdd
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<short> IsOdd(this IArg<short> arg)
        {
            if(arg.Value % 2 == 0)
            {
                throw new ArgumentException("Value must be odd.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsOdd
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsOdd(this IArg<short> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsOdd));
            try
            {
                Guard.That(arg.Value).IsOdd();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsGreaterThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsGreaterThan(this IArg<short> arg, short param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsGreaterThan));
            try
            {
                Guard.That(arg.Value).IsGreaterThan(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }


        /// <summary>
        /// Extension method to add a Custom Message to IsGreaterThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Function to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsGreaterThan(this IArg<short> arg, Func<short> param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsGreaterThan));
            try
            {
                Guard.That(arg.Value).IsGreaterThan(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsLessThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsLessThan(this IArg<short> arg, short param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsLessThan));
            try
            {
                Guard.That(arg.Value).IsLessThan(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsLessThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Action to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsLessThan(this IArg<short> arg, Func<short> param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsLessThan));
            try
            {
                Guard.That(arg.Value).IsLessThan(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsEqual(this IArg<short> arg, short param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEqual));
            try
            {
                Guard.That(arg.Value).IsEqual(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Function to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsEqual(this IArg<short> arg, Func<short> param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEqual));
            try
            {
                Guard.That(arg.Value).IsEqual(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsNotEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsNotEqual(this IArg<short> arg, short param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotEqual));
            try
            {
                Guard.That(arg.Value).IsNotEqual(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsNotEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Action to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsNotEqual(this IArg<short> arg, Func<short> param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotEqual));
            try
            {
                Guard.That(arg.Value).IsNotEqual(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsInRange
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="start">Starting Number of Range</param>
        /// <param name="end">Ending Number of Range</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsInRange(this IArg<short> arg, short start, short end, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsInRange));
            try
            {
                Guard.That(arg.Value).IsInRange(start, end);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custome Message to IsPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<short> IsPrime(this IArg<short> arg)
        {
            if(!InternalHelpers.IsPrime(arg.Value))
            {
                throw new ArgumentException("Value cannot be Non-Prime.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custome Message to IsPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsPrime(this IArg<short> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsPrime));
            try
            {
                Guard.That(arg.Value).IsPrime();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custome Message to IsNotPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<short> IsNotPrime(this IArg<short> arg)
        {
            if (InternalHelpers.IsPrime(arg.Value))
            {
                throw new ArgumentException("Value cannot be Prime.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custome Message to IsNotPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<short> IsNotPrime(this IArg<short> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotPrime));
            try
            {
                Guard.That(arg.Value).IsNotPrime();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}