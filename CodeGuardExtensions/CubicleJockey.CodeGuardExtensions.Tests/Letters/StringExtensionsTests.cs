using System;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests.Letters
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

        #region IsNotEmpty

        [TestMethod]
        public void IsNotEmpty()
        {
            const string value = "The Value";
            var result = Guard.That(value).IsNotEmpty("Should not see me!.").Value;

            result.Should().BeEquivalentTo(value);
        }

        [TestMethod]
        public void IsNotEmptyFailed()
        {
            const string MESSAGE = "Failure and such.";
            Action check = () => Guard.That(string.Empty).IsNotEmpty(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsNotEmptyCustomMessageIsNull()
        {
            Action check = () => Guard.That("Something").IsNotEmpty(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void IsNotEmptyCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That("Something").IsNotEmpty(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void IsNotEmptyCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That("Something").IsNotEmpty("      ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        #endregion IsNotEmpty

        #region Contains

        [TestMethod]
        public void ContainsCustomMessage()
        {
            const string MAIN = "I am a string.";
            const string CHECKVALUE = "am";
            var result = Guard.That(MAIN).Contains(CHECKVALUE, "Shouldn't get this message").Value;

            result.Should().BeEquivalentTo(MAIN);
        }

        [TestMethod]
        public void ContainsCustomeMessageFailed()
        {
            const string MESSAGE = "Dat message and all.";
            const string MAIN = "I am a string.";
            const string CHECKVALUE = "NOT FOUND!";

            Action check = ()=> Guard.That(MAIN).Contains(CHECKVALUE, MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void ContainsCustomMessageIsNull()
        {
            Action check = () => Guard.That("SomeString").Contains("CheckValue", null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("Contains"));
        }

        [TestMethod]
        public void ContainsCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That("SomeString").Contains("CheckValue", string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("Contains"));
        }

        [TestMethod]
        public void ContainsCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That("SomeString").Contains("CheckValue", "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("Contains"));
        }

        #endregion Contains

        #region EndsWith

        [TestMethod]
        public void EndsWith()
        {
            const string value = "Blood Oil";
            var result = Guard.That(value).EndsWith("Oil", "Should not get me.").Value;

            result.Should().BeEquivalentTo(value);
        }

        [TestMethod]
        public void EndsWithFailed()
        {
            const string MESSAGE = "Breaking us! Killing us!";
            Action check = () => Guard.That("Failed").EndsWith("Not This", MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void EndsWithCustomMessageIsNull()
        {
            Action check = () => Guard.That("Failed").EndsWith("Not This", null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("EndsWith"));
        }

        [TestMethod]
        public void EndsWithCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That("Failed").EndsWith("Not This", string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("EndsWith"));
        }

        [TestMethod]
        public void EndsWithCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That("Failed").EndsWith("Not This", "       ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("EndsWith"));
        }

        #endregion EndsWith

        #region IsMatch

        [TestMethod]
        public void IsMatch()
        {
            const string PATTERN = "[0-9A-Z]";
            const string VALUE = "ABC190";

            var result = Guard.That(VALUE).IsMatch(PATTERN, "Shouldn't get me").Value;

            result.Should().BeEquivalentTo(VALUE);
        }

        [TestMethod]
        public void IsMatchFailed()
        {
            const string PATTERN = "[0-9A-Z]";
            const string MESSAGE = "Get this message!!!!";

            Action check = () => Guard.That("lowercasefail").IsMatch(PATTERN, MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsMatchCustomMessageIsNull()
        {
            const string PATTERN = "[0-9A-Z]";
            
            Action check = () => Guard.That("lowercasefail").IsMatch(PATTERN, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsMatch"));
        }

        [TestMethod]
        public void IsMatchCustomMessageIsEmptyString()
        {
            const string PATTERN = "[0-9A-Z]";

            Action check = () => Guard.That("lowercasefail").IsMatch(PATTERN, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsMatch"));
        }

        [TestMethod]
        public void IsMatchCustomMessageIsWhihtespace()
        {
            const string PATTERN = "[0-9A-Z]";

            Action check = () => Guard.That("lowercasefail").IsMatch(PATTERN, "       ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsMatch"));
        }

        #endregion IsMatch
    }
}
