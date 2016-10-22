using System;
using System.Collections.Generic;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests.Collections
{
    [TestClass]
    public class IListExtensionsTests : BaseTest
    {
        #region IList IsNotEmpty

        [TestMethod]
        public void IListIsNotEmpty_NoError()
        {
            IList<string> items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty("Shouldn't get to me.");
        }

        [TestMethod]
        public void IListIsNotEmpty_IListIsNull()
        {
            const string CUSTOMMESSAGE = "Custom Message";
            IList<string> items = null;
            Action check = () => Guard.That(items).IsNotEmpty(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IListIsNotEmpty_IListIsEmpty()
        {
            const string CUSTOMMESSAGE = "Custom Message";
            IList<string> items = new List<string>(0);
            Action check = () => Guard.That(items).IsNotEmpty(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IListIsNotEmpty_CustomMessageIsNull()
        {
            IList<string> items = new[] { "A", "B" };
            Action check =() => Guard.That(items).IsNotEmpty(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void IListIsNotEmpty_CustomMessageIsEmptyString()
        {
            IList<string> items = new[] { "A", "B" };
            Action check = () => Guard.That(items).IsNotEmpty(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void IListIsNotEmpty_CustomMessageIsWhitespace()
        {
            IList<string> items = new[] { "A", "B" };
            Action check = () => Guard.That(items).IsNotEmpty("   ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        #endregion IList IsNotEmpty

        #region IsEmpty

        [TestMethod]
        public void IListIsEmpty()
        {
            IList<char> list = new char[0];
            var result = Guard.That(list).IsEmpty("You shouldn't see me").Value;

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void IListIsEmpty_Fail()
        {
            const string MESSAGE = "Da Message";
            IList<char> list = new [] {'A', 'B', 'C'};
            Action check = () => Guard.That(list).IsEmpty(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IList_CustomMessageIsNull()
        {
            IList<double> list = new List<double>(0);

            Action check = () => Guard.That(list).IsEmpty(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        [TestMethod]
        public void IList_CustomMessageIsEmptyString()
        {
            IList<double> list = new List<double>(0);

            Action check = () => Guard.That(list).IsEmpty(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        [TestMethod]
        public void IList_CustomMessageIsWhitespace()
        {
            IList<double> list = new List<double>(0);

            Action check = () => Guard.That(list).IsEmpty("    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        #endregion IsEmpty

        #region IsNotEmpty

        [TestMethod]
        public void IsNotEmpty()
        {
            IList<float> list = new[] { 2f, 5f, 8f };

            var result = Guard.That(list).IsNotEmpty().Value;

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public void IsNotEmpty_Failed()
        {
            IList<float> list = new float[0];

            Action check = () => Guard.That(list).IsNotEmpty();

            check.ShouldThrow<ArgumentException>()
                 .WithMessage("IList<Single> should be empty.");
        }

        #endregion IsNotEmpty

        #region IsNotEmptyCustomMessage

        [TestMethod]
        public void IsNotEmptyCustomMessage()
        {
            IList<int> list = new [] { 1, 2, 3 };
            var result = Guard.That(list).IsNotEmpty("You shouldn't see me").Value;

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public void IsNotEmptyCustomMessage_Failed()
        {
            const string CUSTOMMESSAGE = "Eldritch";
            IList<int> list = new int[0];

            Action check = () => Guard.That(list).IsNotEmpty(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotEmptyCustomeMessageIsNull()
        {
            IList<int> list = new int[0];

            Action check = () => Guard.That(list).IsNotEmpty(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void IsNotEmptyCustomeMessageIsEmptyString()
        {
            IList<int> list = new int[0];

            Action check = () => Guard.That(list).IsNotEmpty(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }

        [TestMethod]
        public void IsNotEmptyCustomeMessageIsWhitespace()
        {
            IList<int> list = new int[0];

            Action check = () => Guard.That(list).IsNotEmpty("    ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEmpty"));
        }


        #endregion IsNotEmptyCustomMessage
    }
}