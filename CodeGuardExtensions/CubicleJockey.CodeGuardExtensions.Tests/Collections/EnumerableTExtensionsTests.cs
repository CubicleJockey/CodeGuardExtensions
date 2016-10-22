using System;
using System.Collections.Generic;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests.Collections
{
    [TestClass]
    public class EnumerableTExtensionsTests : BaseTest
    {
        #region IEnumerable<T> IsEmpty

        [TestMethod]
        public void IsEmpty()
        {
            IEnumerable<float> list = new List<float>(0);

            var result = Guard.That(list).IsEmpty().Value;

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void IsEmpty_Fail()
        {
            IEnumerable<float> list = new List<float>(1) { 14.5f };

            Action check = () => Guard.That(list).IsEmpty();

            check.ShouldThrow<ArgumentException>()
                 .WithMessage("IEnumberable<T> should be empty.");
        }

        #endregion IEnumerable<T> IsEmpty

        #region IEnumerable<T> IsEmptyCustomMessage

        [TestMethod]
        public void IsEmptyCustomMessage()
        {
            IEnumerable<float> list = new List<float>(0);

            var result = Guard.That(list).IsEmpty("I shouldn't come up.").Value;

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void IsEmptyCustomMessage_Fail()
        {
            const string CUSTOMEMESSAGE = "Your stuff is aslpoding!";
            IEnumerable<float> list = new List<float>(1) { 43.5f };

            Action check = () => Guard.That(list).IsEmpty(CUSTOMEMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMEMESSAGE);
        }

        [TestMethod]
        public void IsEmptyCustomeMessageIsNull()
        {
            IEnumerable<float> list = new List<float>(1) { 43.5f };

            Action check = () => Guard.That(list).IsEmpty(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        [TestMethod]
        public void IsEmptyCustomeMessageIsEmptyString()
        {
            IEnumerable<float> list = new List<float>(1) { 43.5f };

            Action check = () => Guard.That(list).IsEmpty(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        [TestMethod]
        public void IsEmptyCustomeMessageIsWhitespace()
        {
            IEnumerable<float> list = new List<float>(1) { 43.5f };

            Action check = () => Guard.That(list).IsEmpty("   ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        #endregion IEnumerable<T> IsEmptyCustomMessage

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
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void EnumerableTIsNotEmpty_CustomMessageIsEmptyString()
        {
            IEnumerable<string> items = new[] { "A", "B" };

            Action check = () => Guard.That(items).IsNotEmpty(string.Empty);
            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void EnumerableTIsNotEmpty_CustomMessageIsWhitespace()
        {
            IEnumerable<string> items = new[] { "A", "B" };
            Action check = () => Guard.That(items).IsNotEmpty("     ");
            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        #endregion IEnumerable<T> IsNotEmpty
    }
}
