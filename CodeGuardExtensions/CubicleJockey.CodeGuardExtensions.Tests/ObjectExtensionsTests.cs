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
    public class ObjectExtensionsTests : BaseTest
    {
        #region IsNull

        [TestMethod]
        public void IsNull_Valid()
        {
            object thingy = null;

            var guardedValue = Guard.That(thingy).IsNull("I shouldn't be seen").Value;
            guardedValue.Should().BeNull();
        }

        [TestMethod]
        public void IsNull_Fail()
        {
            const string VALUE = "TheValue";
            object thingy = new
            {
                SomeProperty = VALUE
            };
            Action check =
                () => Guard.That(thingy).IsNull("I'm Custom");
            check.ShouldThrow<ArgumentException>()
                .WithMessage("I'm Custom");
        }

        [TestMethod]
        public void IsNull_CustomMessageIsNull()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNull(null);
            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNull"));
        }

        [TestMethod]
        public void IsNull_CustomMessageIsEmptyString()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNull(string.Empty);
            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNull"));
        }

        [TestMethod]
        public void IsNull_CustomMessageIsWhitespace()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNull("    ");
            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNull"));
        }

        #endregion IsNull

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
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNull"));
        }

        [TestMethod]
        public void IsNotNull_CustomMessageIsEmptyString()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNotNull(string.Empty);
            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNull"));
        }

        [TestMethod]
        public void IsNotNull_CustomMessageIsWhitespace()
        {
            object thingy = null;
            Action check =
                () => Guard.That(thingy).IsNotNull("    ");
            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNull"));
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
        public void IsNotDefaultFailed()
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
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotDefault"));
        }

        [TestMethod]
        public void IsNotDefault_CustomMessageIsEmptyString()
        {
            const int number = 15;
            Action guard = () => Guard.That(number).IsNotDefault(string.Empty);
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotDefault"));
        }

        [TestMethod]
        public void IsNotDefault_CustomMessageIsWhitespace()
        {
            const int number = 15;
            Action guard = () => Guard.That(number).IsNotDefault("    ");
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotDefault"));
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
        public void IsDefaultFailed()
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
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsDefault"));
        }

        [TestMethod]
        public void IsDefault_CustomMessageIsEmptyString()
        {
            const int number = default(int);
            Action guard = () => Guard.That(number).IsDefault(string.Empty);
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsDefault"));
        }

        [TestMethod]
        public void IsDefault_CustomMessageIsWhitespace()
        {
            const int number = default(int);
            Action guard = () => Guard.That(number).IsDefault("    ");
            guard.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsDefault"));
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
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNullOrDefault"));
        }

        [TestMethod]
        public void IsNullOrDefault_CustomMessageIsEmptyString()
        {
            const string MESSAGE = "";

            object item = null;
            Action nullResult = () => Guard.That(item).IsNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNullOrDefault"));
        }

        [TestMethod]
        public void IsNullOrDefault_CustomMessageIsWhitespace()
        {
            const string MESSAGE = "         ";

            object item = null;
            Action nullResult = () => Guard.That(item).IsNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNullOrDefault"));
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
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNullOrDefault"));
        }

        [TestMethod]
        public void IsNotNullOrDefault_CustomMessageIsEmptyString()
        {
            const string MESSAGE = "";

            object item = new { NotNull = "WhatWhat" };
            Action nullResult = () => Guard.That(item).IsNotNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNullOrDefault"));
        }

        [TestMethod]
        public void IsNotNullOrDefault_CustomMessageIsWhitespace()
        {
            const string MESSAGE = "         ";

            object item = new { NotNull = "WhatWhat" };
            Action nullResult = () => Guard.That(item).IsNotNullOrDefault(MESSAGE);

            nullResult
                .ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotNullOrDefault"));
        }
        #endregion IsNotNullOrDefault

        #region Is

        [TestMethod]
        public void IsCustomMessage()
        {
            var result = Guard.That(long.MaxValue).Is(typeof(long), "Should not see me.").Value;

            result.ShouldBeEquivalentTo(long.MaxValue);
        }

        [TestMethod]
        public void IsCustomMessageFailed()
        {
            const string MESSAGE = "Wrong type dawg!";
            Action check = () => Guard.That(char.MaxValue).Is(typeof(string), MESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsCustomMessageIsNull()
        {
            Action check = () => Guard.That(char.MaxValue).Is(typeof(string), null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("Is"));
        }

        [TestMethod]
        public void IsCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(char.MaxValue).Is(typeof(string), string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("Is"));
        }

        [TestMethod]
        public void IsCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(char.MaxValue).Is(typeof(string), "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("Is"));
        }

        #endregion Is
    }
}
