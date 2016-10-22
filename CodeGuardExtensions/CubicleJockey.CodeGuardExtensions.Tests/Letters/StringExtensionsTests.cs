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
        public void ContainsCustomeMessage_Failed()
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
    }
}
