using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class BoolExtensionsTests : BaseTest
    {
        #region IsTrue

        [TestMethod]
        public void IsTrueCustomMessage()
        {
            var result = Guard.That(true).IsTrue("Shouldn't see me.").Value;

            result.ShouldBeEquivalentTo(true);
        }

        [TestMethod]
        public void IsTrueCustomMessageFailed()
        {
            const string MESSAGE = "Failed Message";

            Action check = () => Guard.That(false).IsTrue(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsTrueCustomMessageIsNull()
        {
            Action check = () => Guard.That(false).IsTrue(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsTrue"));
        }

        [TestMethod]
        public void IsTrueCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(false).IsTrue(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsTrue"));
        }

        [TestMethod]
        public void IsTrueCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(false).IsTrue("     ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsTrue"));
        }

        #endregion IsTrue

        #region IsFalse

        [TestMethod]
        public void IsFalseCustomMessage()
        {
            var result = Guard.That(false).IsFalse("Shouldn't see me.").Value;
            result.ShouldBeEquivalentTo(false);
        }

        [TestMethod]
        public void IsFalseCustomMessageFailed()
        {
            const string MESSAGE = "Failed Message";

            Action check = () => Guard.That(true).IsFalse(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsFalseCustomMessageIsNull()
        {
            Action check = () => Guard.That(true).IsFalse(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsFalse"));
        }

        [TestMethod]
        public void IsFalseCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(true).IsFalse(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsFalse"));
        }

        [TestMethod]
        public void IsFalseCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(true).IsFalse("     ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsFalse"));
        }

        #endregion IsFalse
    }
}
