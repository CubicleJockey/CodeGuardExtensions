using System;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        #region IsNotNullOrWhiteSpace

        [TestMethod]
        public void IsNotNullOrWhiteSpace_MessageIsNull()
        {
            const string SOMEMESSAGE = null;
            const string CUSTOMMESSAGE = "I be custom.";

            try
            {
                Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);
            }
            catch (Exception x)
            {
                x.Message.Should().BeEquivalentTo(CUSTOMMESSAGE);
                return;
            }
            Assert.Fail("Expected to get an exception.");
        }

        [TestMethod]
        public void IsNotNullOrWhiteSpace_MessageIsEmptyString()
        {
            const string SOMEMESSAGE = "";
            const string CUSTOMMESSAGE = "I be custom.";

            try
            {
                Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);
            }
            catch (Exception x)
            {
                x.Message.Should().BeEquivalentTo(CUSTOMMESSAGE);
                return;
            }
            Assert.Fail("Expected to get an exception.");
        }

        [TestMethod]
        public void IsNotNullOrWhiteSpace_MessageIsWhitespace()
        {
            const string SOMEMESSAGE = "";
            const string CUSTOMMESSAGE = "I be custom.";

            try
            {
                Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);
            }
            catch (Exception x)
            {
                x.Message.Should().BeEquivalentTo(CUSTOMMESSAGE);
                return;
            }
            Assert.Fail("Expected to get an exception.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void IsNotNullOrWhiteSpace_CustomMessageIsNull()
        {
            const string SOMEMESSAGE = null;
            const string CUSTOMMESSAGE = null;
            Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void IsNotNullOrWhiteSpace_CustomMessageIsEmptyString()
        {
            const string SOMEMESSAGE = null;
            var CUSTOMMESSAGE = string.Empty;
            Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot pass Null, Empty or Whitespace as message for IsNotNullOrWhiteSpace extension.")]
        public void IsNotNullOrWhiteSpace_CustomMessageIsWhitespace()
        {
            const string SOMEMESSAGE = null;
            const string CUSTOMMESSAGE = "     ";
            Guard.That(SOMEMESSAGE).IsNotNullOrWhiteSpace(CUSTOMMESSAGE);
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
    }
}
