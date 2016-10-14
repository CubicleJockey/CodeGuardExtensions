using System;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class IntExtensionsTests : BaseTest
    {
        #region IsPositive

        [TestMethod]
        public void IsPositive()
        {
            const int value = 10;

            var result = Guard.That(value).IsPositive("Shouldn't get me.").Value;

            result.Should().BePositive();
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsPositive_Failed()
        {
            const string MESSAGE = "Math Message";

            Action check = () => Guard.That(-1).IsPositive(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsPositiveCustomMessageIsNull()
        {
            Action check = () => Guard.That(-1).IsPositive(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPositive"));
        }

        [TestMethod]
        public void IsPositiveCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(-1).IsPositive(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPositive"));
        }

        [TestMethod]
        public void IsPositiveCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(-1).IsPositive("      ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPositive"));
        }

        #endregion IsPositive

        #region IsNegative

        [TestMethod]
        public void IsNegative()
        {
            const int value = -10;

            var result = Guard.That(value).IsNegative("Shouldn't get me.").Value;

            result.Should().BeNegative();
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsNegative_Failed()
        {
            const string MESSAGE = "Math Message";

            Action check = () => Guard.That(1).IsNegative(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsNegativeCustomMessageIsNull()
        {
            Action check = () => Guard.That(1).IsNegative(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNegative"));
        }

        [TestMethod]
        public void IsNegativeCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(1).IsNegative(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNegative"));
        }

        [TestMethod]
        public void IsNegativeCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(1).IsNegative("      ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNegative"));
        }

        #endregion IsNegative
    }
}
