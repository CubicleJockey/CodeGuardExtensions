using System;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class EnumerableExtensionsTests : BaseTest
    {
        #region IEnumerable IsNotEmpty

        [TestMethod]
        public void EnumerableIsNotEmpty_NoError()
        {
            var items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty("Shouldn't get to me.");
        }

        [TestMethod]
        public void EnumerableIsNotEmpty_EnumerableIsNull()
        {
            const string CUSTOMMESSAGE = "Custom Message";
            string[] items = null;

            Action check = () => Guard.That(items).IsNotEmpty(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void EnumerableIsNotEmpty_EnumerableIsEmpty()
        {
            const string CUSTOMMESSAGE = "Custom Message";

            var items = new string[0];
            Action check = () => Guard.That(items).IsNotEmpty(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void EnumerableIsNotEmpty_CustomMessageIsNull()
        {
            var items = new[] { "A", "B" };
            Action check = () => Guard.That(items).IsNotEmpty(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void EnumerableIsNotEmpty_CustomMessageIsEmptyString()
        {
            var items = new[] { "A", "B" };
            Action check = () => Guard.That(items).IsNotEmpty(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void EnumerableIsNotEmpty_CustomMessageIsWhitespace()
        {
            var items = new[] { "A", "B" };
            Action check = () => Guard.That(items).IsNotEmpty("    ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        #endregion IEnumerable IsNotEmpty
    }
}
