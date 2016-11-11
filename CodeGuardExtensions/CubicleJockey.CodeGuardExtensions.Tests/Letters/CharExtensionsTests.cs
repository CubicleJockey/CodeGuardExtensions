using System;
using System.ComponentModel;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests.Letters
{
    [TestClass]
    public class CharExtensionsTests : BaseTest
    {
        #region IsEqual

        [TestMethod]
        public void IsEqualCustomMessage()
        {
            const char VALUE = 'E';
            var result = Guard.That(VALUE).IsEqual('E', "Should not see me.").Value;
            result.ShouldBeEquivalentTo(VALUE);
        }

        [TestMethod]
        public void IsEqualCustomMessageFail()
        {
            const string MESSAGE = "Not Equal and shit.";
            Action check = () => Guard.That('z').IsEqual('Z', MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsEqualCustomMessageIsNull()
        {
            Action check = () => Guard.That('A').IsEqual('C', null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That('A').IsEqual('C', string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That('A').IsEqual('C', "  ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        #endregion IsEqual

        #region IsNotEqual

        [TestMethod]
        public void IsNotEqualCustomMessage()
        {
            const char VALUE = 'E';
            var result = Guard.That(VALUE).IsNotEqual('Z', "Should not see me.").Value;
            result.ShouldBeEquivalentTo(VALUE);
        }

        [TestMethod]
        public void IsNotEqualCustomMessageFail()
        {
            const string MESSAGE = "Equal and shit.";
            Action check = () => Guard.That('Z').IsNotEqual('Z', MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsNotEqualCustomMessageIsNull()
        {
            Action check = () => Guard.That('A').IsNotEqual('C', null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That('A').IsNotEqual('C', string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That('A').IsNotEqual('C', "  ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        #endregion IsNotEqual

        #region IsGreaterThan

        [TestMethod]
        public void IsGreaterThanCustomMessage()
        {
            const char LHS = 'B';
            const char RHS = 'A';

            var result = Guard.That(LHS).IsGreaterThan(RHS, "Shouldn't see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageFailed()
        {
            const string MESSAGE = "Characters can be greater than, dafauc.";

            const char LHS = 'A';
            const char RHS = 'B';

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsNull()
        {
            const char LHS = 'A';
            const char RHS = 'B';

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsEmptyString()
        {
            const char LHS = 'A';
            const char RHS = 'B';

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsWhitespace()
        {
            const char LHS = 'A';
            const char RHS = 'B';

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageFunc()
        {
            const char LHS = 'B';
            Func<char> RHS = () => 'A';

            var result = Guard.That(LHS).IsGreaterThan(RHS, "Shouldn't see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageFailedFunc()
        {
            const string MESSAGE = "Characters can be greater than, dafauc.";

            const char LHS = 'A';
            Func<char> RHS = () => 'B';

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsNullFunc()
        {
            const char LHS = 'A';
            Func<char> RHS = () => 'B';

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsEmptyStringFunc()
        {
            const char LHS = 'A';
            Func<char> RHS = () => 'B';

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsWhitespaceFunc()
        {
            const char LHS = 'A';
            Func<char> RHS = () => 'B';

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        #endregion IsGreaterThan

        #region IsLessThan

        [TestMethod]
        public void IsLessThanThanCustomMessage()
        {
            const char LHS = 'Y';
            const char RHS = 'Z';

            var result = Guard.That(LHS).IsLessThan(RHS, "Shouldn't see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsLessThanCustomMessageFailed()
        {
            const string MESSAGE = "Characters can be less than, dafauc.";

            const char LHS = 'Z';
            const char RHS = 'Y';

            Action check = () => Guard.That(LHS).IsLessThan(RHS, MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsNull()
        {
            const char LHS = 'Y';
            const char RHS = 'Z';

            Action check = () => Guard.That(LHS).IsLessThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsEmptyString()
        {
            const char LHS = 'Y';
            const char RHS = 'Z';

            Action check = () => Guard.That(LHS).IsLessThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsWhitespace()
        {
            const char LHS = 'Y';
            const char RHS = 'Z';

            Action check = () => Guard.That(LHS).IsLessThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageFunc()
        {
            const char LHS = 'Y';
            Func<char> RHS = () => 'Z';

            var result = Guard.That(LHS).IsLessThan(RHS, "Shouldn't see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsLessThanCustomMessageFailedFunc()
        {
            const string MESSAGE = "Characters can be greater than, dafauc.";

            const char LHS = 'Z';
            Func<char> RHS = () => 'Y';

            Action check = () => Guard.That(LHS).IsLessThan(RHS, MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsNullFunc()
        {
            const char LHS = 'Y';
            Func<char> RHS = () => 'Z';

            Action check = () => Guard.That(LHS).IsLessThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsEmptyStringFunc()
        {
            const char LHS = 'Y';
            Func<char> RHS = () => 'Z';

            Action check = () => Guard.That(LHS).IsLessThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsWhitespaceFunc()
        {
            const char LHS = 'Y';
            Func<char> RHS = () => 'Z';

            Action check = () => Guard.That(LHS).IsLessThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        #endregion IsLessThan

        #region IsInRange

        [TestMethod]
        public void IsInRangeWithCustomMessage()
        {
            const char VALUE = 'f';
            var result = Guard.That(VALUE).IsInRange('a', 'g', "Shouldn't see me").Value;

            result.Should().NotBeNull();
            result.ShouldBeEquivalentTo(VALUE);
        }

        [TestMethod]
        public void IsInRangeWithCustomeMessageFailed()
        {
            const string MESSAGE = "Letters and stuff.";
            Action check = () => Guard.That('c').IsInRange('d', 'e', MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsInRangeIsLessThanCustomMessageIsNull()
        {
            Action check = () => Guard.That('C').IsInRange('b', 'e', null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        [TestMethod]
        public void IsInRangeIsLessThanCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That('C').IsInRange('b', 'e', string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        [TestMethod]
        public void IsInRangeIsLessThanCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That('C').IsInRange('b', 'e', "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        #endregion IsInRange
    }
}
