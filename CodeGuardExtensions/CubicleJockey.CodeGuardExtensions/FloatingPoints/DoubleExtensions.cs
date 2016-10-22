using System;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class DoubleExtensions
    {

        /// <summary>
        /// Extensions method to add IsPositive
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<double> IsPositive(this IArg<double> arg)
        {
            if(arg.Value < 0.0)
            {
                throw new ArgumentException("Value must be positive.");
            }
            return arg;
        }

        /// <summary>
        /// Extensions method to add a Custom Message to IsPositive
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<double> IsPositive(this IArg<double> arg, string message)
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
        public static IArg<double> IsNegative(this IArg<double> arg)
        {
            if(arg.Value >= 0.0)
            {
                throw new ArgumentException("Value must be negative.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsNegative
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<double> IsNegative(this IArg<double> arg, string message)
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
        /// Extension method to add a Custom Message to IsGreaterThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<double> IsGreaterThan(this IArg<double> arg, double param, string message)
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
        public static IArg<double> IsGreaterThan(this IArg<double> arg, Func<double> param, string message)
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
        public static IArg<double> IsLessThan(this IArg<double> arg, double param, string message)
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
        public static IArg<double> IsLessThan(this IArg<double> arg, Func<double> param, string message)
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
        public static IArg<double> IsEqual(this IArg<double> arg, double param, string message)
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
        public static IArg<double> IsEqual(this IArg<double> arg, Func<double> param, string message)
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
        public static IArg<double> IsNotEqual(this IArg<double> arg, double param, string message)
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
        public static IArg<double> IsNotEqual(this IArg<double> arg, Func<double> param, string message)
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
        public static IArg<double> IsInRange(this IArg<double> arg, double start, double end, string message)
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
    }
}
