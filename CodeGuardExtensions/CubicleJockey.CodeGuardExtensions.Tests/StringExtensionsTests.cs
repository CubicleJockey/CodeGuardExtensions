using System;
using System.Collections.Generic;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class StringExtensionsTests : BaseTest
    {
        #region IsNotNullOrWhiteSpace

        [TestMethod]
        public void IsNotNullOrWhiteSpace_MessageIsNull()
        {
            const string SOMEMESSAGE = null;
            const string CUSTOMMESSAGE = "I be custom.";

            Action check = () => Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotNullOrWhiteSpace_MessageIsEmptyString()
        {
            const string SOMEMESSAGE = "";
            const string CUSTOMMESSAGE = "I be custom.";

            Action check = () => Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotNullOrWhiteSpace_MessageIsWhitespace()
        {
            const string SOMEMESSAGE = "";
            const string CUSTOMMESSAGE = "I be custom.";

            Action check = () => Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotNullOrWhiteSpace_CustomMessageIsNull()
        {
            const string SOMEMESSAGE = null;
            const string CUSTOMMESSAGE = null;

            Action check = () => Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNullOrWhiteSpace"));
        }

        [TestMethod]
        public void IsNotNullOrWhiteSpace_CustomMessageIsEmptyString()
        {
            const string SOMEMESSAGE = null;
            var CUSTOMMESSAGE = string.Empty;

            Action check = () => Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNullOrWhiteSpace"));
        }

        [TestMethod]
        public void IsNotNullOrWhiteSpace_CustomMessageIsWhitespace()
        {
            const string SOMEMESSAGE = null;
            const string CUSTOMMESSAGE = "     ";

            Action check = () => Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNullOrWhiteSpace"));
        }

        [TestMethod]
        public void IsNotNullOrWhiteSpace_NoError()
        {
            const string SOMEMESSAGE = "I'm a message, so no error.";

            Guard.That(SOMEMESSAGE)
                .IsNotNullOrWhiteSpace("Shouldn't get to me.")
                .Value
                .Should()
                .BeEquivalentTo(SOMEMESSAGE);
        }

        #endregion IsNotNullOrWhiteSpace
    }
}
