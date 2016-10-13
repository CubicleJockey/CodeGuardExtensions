using System;
using System.Collections.Generic;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class EnumerableTExtensionsTests
    {

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

            try
            {
                IEnumerable<string> items = null;
                Guard.That(items).IsNotEmpty(CUSTOMMESSAGE);
            }
            catch (Exception x)
            {
                x.Message.Should().BeEquivalentTo(CUSTOMMESSAGE);
                return;
            }
            Assert.Fail("Expected an exception");
        }

        [TestMethod]
        public void EnumerableTIsNotEmpty_IListIsEmpty()
        {
            const string CUSTOMMESSAGE = "Custom Message";

            try
            {
                IEnumerable<string> items = new List<string>(0);
                Guard.That(items).IsNotEmpty(CUSTOMMESSAGE);
            }
            catch (Exception x)
            {
                x.Message.Should().BeEquivalentTo(CUSTOMMESSAGE);
                return;
            }
            Assert.Fail("Expected an exception");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void EnumerableTIsNotEmpty_CustomMessageIsNull()
        {
            IEnumerable<string> items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void EnumerableTIsNotEmpty_CustomMessageIsEmptyString()
        {
            IEnumerable<string> items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void EnumerableTIsNotEmpty_CustomMessageIsWhitespace()
        {
            IEnumerable<string> items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty("      ");
        }

        #endregion IEnumerable<T> IsNotEmpty
    }
}
