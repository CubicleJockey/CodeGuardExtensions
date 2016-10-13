using System;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        #region IEnumerable IsNotEmpty

        [TestMethod]
        public void EnumerableIsNotEmpty_NoError()
        {
            var items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty("Shouldn't get to me.");
        }

        [TestMethod]
        public void EnumerableIsNotEmpty_IListIsNull()
        {
            const string CUSTOMMESSAGE = "Custom Message";

            try
            {
                string[] items = null;
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
        public void EnumerableIsNotEmpty_IListIsEmpty()
        {
            const string CUSTOMMESSAGE = "Custom Message";

            try
            {
                var items = new string[0];
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
        public void EnumerableIsNotEmpty_CustomMessageIsNull()
        {
            var items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void EnumerableIsNotEmpty_CustomMessageIsEmptyString()
        {
            var items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void EnumerableIsNotEmpty_CustomMessageIsWhitespace()
        {
            var items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty("      ");
        }

        #endregion IEnumerable IsNotEmpty
    }
}
