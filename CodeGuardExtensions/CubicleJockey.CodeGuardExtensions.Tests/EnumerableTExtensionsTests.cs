using System;
using System.Collections.Generic;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class EnumerableTExtensionsTests
    {
        private const string CUSTOMMESSAGE_ERROR = "Cannot pass Null, Empty or Whitespace as customMessage for IsNotEmpty extension.";

        #region IEnumerable<T> IsNotEmpty

        [TestMethod]
        public void EnumerableTIsNotEmpty_NoError()
        {
            IEnumerable<string> items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty("Shouldn't get to me.");
        }

        [TestMethod]
        public void EnumerableTIsNotEmpty_IListIsNull()
        {
            const string CUSTOMMESSAGE = "Custom Message";
            IEnumerable<string> items = null;

            Action check = () => Guard.That(items).IsNotEmpty(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void EnumerableTIsNotEmpty_IListIsEmpty()
        {
            const string CUSTOMMESSAGE = "Custom Message";
            
            IEnumerable<string> items = new List<string>(0);

            Action check = () => Guard.That(items).IsNotEmpty(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void EnumerableTIsNotEmpty_CustomMessageIsNull()
        {
            IEnumerable<string> items = new[] { "A", "B" };

            Action check = () => Guard.That(items).IsNotEmpty(null);
            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE_ERROR);
        }

        [TestMethod]
        public void EnumerableTIsNotEmpty_CustomMessageIsEmptyString()
        {
            IEnumerable<string> items = new[] { "A", "B" };

            Action check = () => Guard.That(items).IsNotEmpty(string.Empty);
            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE_ERROR);
        }

        [TestMethod]
        public void EnumerableTIsNotEmpty_CustomMessageIsWhitespace()
        {
            IEnumerable<string> items = new[] { "A", "B" };
            Action check = () => Guard.That(items).IsNotEmpty("     ");
            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE_ERROR);
        }

        #endregion IEnumerable<T> IsNotEmpty
    }
}
