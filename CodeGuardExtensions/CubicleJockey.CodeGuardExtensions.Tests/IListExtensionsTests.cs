using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;
using CubicleJockey.CodeGuardExtensions;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class IListExtensionsTests
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

            try
            {
                IList<string> items = null;
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
        public void IListIsNotEmpty_IListIsEmpty()
        {
            const string CUSTOMMESSAGE = "Custom Message";

            try
            {
                IList<string> items = new List<string>(0);
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
        public void IListIsNotEmpty_CustomMessageIsNull()
        {
            IList<string> items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void IListIsNotEmpty_CustomMessageIsEmptyString()
        {
            IList<string> items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void IListIsNotEmpty_CustomMessageIsWhitespace()
        {
            IList<string> items = new[] { "A", "B" };
            Guard.That(items).IsNotEmpty("      ");
        }

        #endregion IList IsNotEmpty
    }
}
