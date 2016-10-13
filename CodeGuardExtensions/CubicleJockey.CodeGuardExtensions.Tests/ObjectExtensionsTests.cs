using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void IsNotNull_Valid()
        {
            const string VALUE = "TheValue";
            object thingy = new
            {
                SomeProperty = VALUE
            };

            var guardedValue = Guard.That(thingy).IsNotNull().Value;
            guardedValue.Should().NotBeNull();
            guardedValue.Should().BeAssignableTo<object>();

            var guardedType = guardedValue.GetType();
            IList<PropertyInfo> properties = new List<PropertyInfo>(guardedType.GetProperties());

            var somePropertyInfo = properties.Single(prop => prop.Name == "SomeProperty");
            var somePropertyValue = (string)somePropertyInfo.GetValue(thingy);

            somePropertyValue.Should().NotBeNullOrWhiteSpace();
            somePropertyValue.Should().BeEquivalentTo(VALUE);
        }

        [TestMethod]
        public void IsNotNull_Fail()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNotNull("I'm Custom");
            check.ShouldThrow<ArgumentException>()
                .WithMessage("I'm Custom");
        }

        [TestMethod]
        public void IsNotNull_CustomMessageIsNull()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNotNull(null);
            check.ShouldThrow<ArgumentException>()
                .WithMessage($"Cannot pass Null, Empty or Whitespace as customMessage for IsNotNull extension.");
        }

        [TestMethod]
        public void IsNotNull_CustomMessageIsEmptyString()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNotNull(string.Empty);
            check.ShouldThrow<ArgumentException>()
                .WithMessage($"Cannot pass Null, Empty or Whitespace as customMessage for IsNotNull extension.");
        }

        [TestMethod]
        public void IsNotNull_CustomMessageIsWhitespace()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNotNull("    ");
            check.ShouldThrow<ArgumentException>()
                .WithMessage($"Cannot pass Null, Empty or Whitespace as customMessage for IsNotNull extension.");
        }
    }
}
