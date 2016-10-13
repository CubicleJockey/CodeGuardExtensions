using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        #region IsNotNull

        [TestMethod]
        public void IsNotNull_Valid()
        {
            const string VALUE = "TheValue";
            object thingy = new
            {
                SomeProperty = VALUE
            };

            var guardedValue = Guard.That(thingy).IsNotNull("I shouldn't be seen").Value;
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
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotNull extension.");
        }

        [TestMethod]
        public void IsNotNull_CustomMessageIsEmptyString()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNotNull(string.Empty);
            check.ShouldThrow<ArgumentException>()
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotNull extension.");
        }

        [TestMethod]
        public void IsNotNull_CustomMessageIsWhitespace()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNotNull("    ");
            check.ShouldThrow<ArgumentException>()
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotNull extension.");
        }

        #endregion IsNotNull

        #region IsNotDefault

        [TestMethod]
        public void IsNotDefault()
        {
            const string CUSTOMMESSAGE = "Should not be activated.";
            const int number = 15;
            var result = Guard.That(number).IsNotDefault(CUSTOMMESSAGE).Value;

            result.ShouldBeEquivalentTo(15);

            const string aString = "NotDefault";
            var result2 = Guard.That(aString).IsNotDefault(CUSTOMMESSAGE).Value;

            result2.Should().BeEquivalentTo(aString);
        }

        [TestMethod]
        public void IsNotDefault_Failed()
        {
            const string CUSTOMMESSAGE = "HansZimmer";
            const int number = default(int);
            Action guard = () => Guard.That(number).IsNotDefault(CUSTOMMESSAGE);

            guard.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotDefault_CustomMessageIsNull()
        {
            const int number = 15;
            Action guard = () => Guard.That(number).IsNotDefault(null);
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotDefault extension.");
        }

        [TestMethod]
        public void IsNotDefault_CustomMessageIsEmptyString()
        {
            const int number = 15;
            Action guard = () => Guard.That(number).IsNotDefault(string.Empty);
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotDefault extension.");
        }

        [TestMethod]
        public void IsNotDefault_CustomMessageIsWhitespace()
        {
            const int number = 15;
            Action guard = () => Guard.That(number).IsNotDefault("    ");
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotDefault extension.");
        }

        #endregion IsNotDefault

        #region IsDefault

        [TestMethod]
        public void IsDefault()
        {
            const string CUSTOMMESSAGE = "Should not be activated.";
            const double number = default(double);
            var result = Guard.That(number).IsDefault(CUSTOMMESSAGE).Value;

            result.ShouldBeEquivalentTo(number);

            const char aChar = default(char);
            var result2 = Guard.That(aChar).IsDefault(CUSTOMMESSAGE).Value;

            result2.ShouldBeEquivalentTo(aChar);
        }

        [TestMethod]
        public void IsDefault_Failed()
        {
            const string CUSTOMMESSAGE = "ToeJam and Earl";
            const int number = 42;
            Action guard = () => Guard.That(number).IsDefault(CUSTOMMESSAGE);

            guard.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsDefault_CustomMessageIsNull()
        {
            const int number = default(int);
            Action guard = () => Guard.That(number).IsDefault(null);
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsDefault extension.");
        }

        [TestMethod]
        public void IsDefault_CustomMessageIsEmptyString()
        {
            const int number = default(int);
            Action guard = () => Guard.That(number).IsDefault(string.Empty);
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsDefault extension.");
        }

        [TestMethod]
        public void IsDefault_CustomMessageIsWhitespace()
        {
            const int number = default(int);
            Action guard = () => Guard.That(number).IsDefault("    ");
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsDefault extension.");
        }


        #endregion IsDefault

        #region IsNullOrDefault

        [TestMethod]
        public void IsNullOrDefault()
        {
            const string MESSAGE = "TheMensRoom";

            object item = null;
            var nullResult = Guard.That(item).IsNullOrDefault(MESSAGE).Value;

            nullResult.Should().BeNull();

            var sb = default(StringBuilder);
            var defaultResult = Guard.That(sb).IsNullOrDefault(MESSAGE).Value;

            defaultResult.Should().BeNull();
        }

        [TestMethod]
        public void IsNullOrDefault_Fail()
        {
            const string MESSAGE = "TheMensRoom";

            object item = new { AintNull = true };
            Action nullActionFail = () => Guard.That(item).IsNullOrDefault(MESSAGE);
            nullActionFail
                .ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);

            var sb = new StringBuilder("Aint' Default");
            Action defaultActionFail = () =>  Guard.That(sb).IsNullOrDefault(MESSAGE);

            defaultActionFail
                .ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsNullOrDefault_CustomMessageIsNull()
        {
            const string MESSAGE = null;

            object item = null;
            Action nullResult = () => Guard.That(item).IsNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNullOrDefault extension.");
        }

        [TestMethod]
        public void IsNullOrDefault_CustomMessageIsEmptyString()
        {
            const string MESSAGE = "";

            object item = null;
            Action nullResult = () => Guard.That(item).IsNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNullOrDefault extension.");
        }

        [TestMethod]
        public void IsNullOrDefault_CustomMessageIsWhitespace()
        {
            const string MESSAGE = "         ";

            object item = null;
            Action nullResult = () => Guard.That(item).IsNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNullOrDefault extension.");
        }

        #endregion IsNullOrDefault

        #region IsNotNullOrDefault
        [TestMethod]
        public void IsNotNullOrDefault()
        {
            const string MESSAGE = "TheMensRoom";

            IEnumerable<string> item = new[] { "A", "B" };
            var notNullResult = Guard.That(item).IsNotNullOrDefault(MESSAGE).Value;

            notNullResult.Should().BeEquivalentTo(item);
        }

        [TestMethod]
        public void IsNotNullOrDefault_Fail()
        {
            const string MESSAGE = "TheMensRoom";

            var item = default(long);
            Action nullActionFail = () => Guard.That(item).IsNotNullOrDefault(MESSAGE);
            nullActionFail
                .ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsNotNullOrDefault_CustomMessageIsNull()
        {
            const string MESSAGE = null;

            object item = new { NotNull = "WhatWhat" };
            Action nullResult = () => Guard.That(item).IsNotNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotNullOrDefault extension.");
        }

        [TestMethod]
        public void IsNotNullOrDefault_CustomMessageIsEmptyString()
        {
            const string MESSAGE = "";

            object item = new { NotNull = "WhatWhat" };
            Action nullResult = () => Guard.That(item).IsNotNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotNullOrDefault extension.");
        }

        [TestMethod]
        public void IsNotNullOrDefault_CustomMessageIsWhitespace()
        {
            const string MESSAGE = "         ";

            object item = new { NotNull = "WhatWhat" };
            Action nullResult = () => Guard.That(item).IsNotNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage("Cannot pass Null, Empty or Whitespace as customMessage for IsNotNullOrDefault extension.");
        }



        #endregion IsNotNullOrDefault
    }
}
