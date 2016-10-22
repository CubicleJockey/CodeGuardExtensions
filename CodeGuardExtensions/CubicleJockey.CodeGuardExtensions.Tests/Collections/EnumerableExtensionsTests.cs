using System;
using System.Collections.Generic;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests.Collections
{
    [TestClass]
    public class EnumerableExtensionsTests : BaseTest
    {
        #region IEnumerable IsEmpty

        [TestMethod]
        public void IsEmpty()
        {
            var list = new int[0];
            var result = Guard.That(list).IsEmpty().Value;

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void IsEmpty_Fail()
        {
            var list = new[] { 1, 2, 3 };

            Action check = () => Guard.That(list).IsEmpty();

            check.ShouldThrow<ArgumentException>()
                 .WithMessage("Int32[] should not be empty.");
        }

        #endregion IEnumerable IsEmpty

        #region IEnumerable IsEmptyCustomMessage

        [TestMethod]
        public void IsEmpytCustomMessage()
        {
            var list = new string[0];

            var result = Guard.That(list).IsEmpty("Shouldn't get me.").Value;

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void IsEmpytCustomMessage_Failed()
        {
            const string CUSTOMMESSAGE = "MTG";

            var list = new [] { 1.0, 2.0 };
            Action check = () => Guard.That(list).IsEmpty(CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsEmptyCustomMessageIsNull()
        {
            var list = new string[0];
            Action check = () => Guard.That(list).IsEmpty(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        [TestMethod]
        public void IsEmptyCustomMessageIsEmptyString()
        {
            var list = new string[0];
            Action check = () => Guard.That(list).IsEmpty(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        [TestMethod]
        public void IsEmptyCustomMessageIsWhitespace()
        {
            var list = new string[0];
            Action check = () => Guard.That(list).IsEmpty("    ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEmpty"));
        }

        #endregion IEnumerable IsEmptyCustomMessage

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
