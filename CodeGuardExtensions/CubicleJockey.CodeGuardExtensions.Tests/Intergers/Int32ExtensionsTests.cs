﻿using System;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests.Intergers
{
    [TestClass]
    public class Int32ExtensionsTests : BaseTest
    {
        #region IsPositive

        [TestMethod]
        public void IsPositive()
        {
            const int value = 10;

            var result = Guard.That(value).IsPositive("Shouldn't get me.").Value;

            result.Should().BePositive();
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsPositiveFailed()
        {
            const string MESSAGE = "Math Message";

            Action check = () => Guard.That(-1).IsPositive(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsPositiveCustomMessageIsNull()
        {
            Action check = () => Guard.That(-1).IsPositive(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPositive"));
        }

        [TestMethod]
        public void IsPositiveCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(-1).IsPositive(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPositive"));
        }

        [TestMethod]
        public void IsPositiveCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(-1).IsPositive("      ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPositive"));
        }

        #endregion IsPositive

        #region IsNegative

        [TestMethod]
        public void IsNegative()
        {
            const int value = -10;

            var result = Guard.That(value).IsNegative("Shouldn't get me.").Value;

            result.Should().BeNegative();
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsNegativeFailed()
        {
            const string MESSAGE = "Math Message";

            Action check = () => Guard.That(1).IsNegative(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsNegativeCustomMessageIsNull()
        {
            Action check = () => Guard.That(1).IsNegative(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNegative"));
        }

        [TestMethod]
        public void IsNegativeCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(1).IsNegative(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNegative"));
        }

        [TestMethod]
        public void IsNegativeCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(1).IsNegative("      ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNegative"));
        }

        #endregion IsNegative

        #region IsEven

        [TestMethod]
        public void IsEven()
        {
            const int value = 2;

            var result = Guard.That(value).IsEven("Shouldn't get me.").Value;

            (result % 2).ShouldBeEquivalentTo(0); //Even
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsEvenFailed()
        {
            const string MESSAGE = "Math Message";

            Action check = () => Guard.That(1).IsEven(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsEvenCustomMessageIsNull()
        {
            Action check = () => Guard.That(2).IsEven(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEven"));
        }

        [TestMethod]
        public void IsEvenCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(2).IsEven(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEven"));
        }

        [TestMethod]
        public void IsEvenCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(2).IsEven("      ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEven"));
        }

        #endregion IsEven

        #region IsOdd

        [TestMethod]
        public void IsOdd()
        {
            const int value = 1;

            var result = Guard.That(value).IsOdd("Shouldn't get me.").Value;

            (result%2).Should().BeGreaterThan(0); //Odd
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsOddFailed()
        {
            const string MESSAGE = "Math Message";

            Action check = () => Guard.That(2).IsOdd(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsOddCustomMessageIsNull()
        {
            Action check = () => Guard.That(1).IsOdd(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsOdd"));
        }

        [TestMethod]
        public void IsOddCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(1).IsOdd(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsOdd"));
        }

        [TestMethod]
        public void IsOddCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(1).IsOdd("      ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsOdd"));
        }

        #endregion IsOdd
        
        #region IsGreatherThan

        [TestMethod]
        public void IsGreaterThan()
        {
            const int RHS = 4;
            const int LHS = 6;

            var result = Guard.That(LHS).IsGreaterThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsGreaterThan_Fail()
        {
            const int RHS = 6;
            const int LHS = 4;
            const string CUSTOMMESSAGE = "Why you no greater?";

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsNull()
        {
            const int RHS = 4;
            const int LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsEmptyString()
        {
            const int RHS = 4;
            const int LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsWhitespace()
        {
            const int RHS = 4;
            const int LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFunc()
        {
            const int RHS = 4;
            const int LHS = 6;

            var result = Guard.That(LHS).IsGreaterThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsGreaterThanByFunc_Fail()
        {
            Func<int> rhsFunc = () => (4 + 6 + 20);
            const int LHS = 4;
            const string CUSTOMMESSAGE = "Why you no greater?";

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsNull()
        {
            Func<int> rhsFunc = () => (-14);
            const int LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsEmptyString()
        {
            Func<int> func = () => (-14);
            const int LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(func, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsWhitespace()
        {
            Func<int> rhsFunc = () => (-14);
            const int LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        #endregion IsGreatherThan

        #region IsLessThan

        [TestMethod]
        public void IsLessThan()
        {
            const int RHS = 6;
            const int LHS = 4;

            var result = Guard.That(LHS).IsLessThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsLessThan_Fail()
        {
            const int RHS = 4;
            const int LHS = 6;
            const string CUSTOMMESSAGE = "Why you no lesser?";

            Action check = () => Guard.That(LHS).IsLessThan(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsNull()
        {
            const int RHS = 6;
            const int LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsEmptyString()
        {
            const int RHS = 6;
            const int LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsWhitespace()
        {
            const int RHS = 6;
            const int LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFunc()
        {
            Func<int> rhsFunc = () => (4 + 2);
            const int LHS = 4;

            var result = Guard.That(LHS).IsLessThan(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsLessThanByFunc_Fail()
        {
            Func<int> rhsFunc = () => (4);
            const int LHS = 6;
            const string CUSTOMMESSAGE = "Why you no lesser?";

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsNull()
        {
            Func<int> rhsFunc = () => (4 + 5);
            const int LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsEmptyString()
        {
            Func<int> rhsFunc = () => (4 + 5);
            const int LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsWhitespace()
        {
            Func<int> rhsFunc = () => (4 + 5);
            const int LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        #endregion IsLessThan

        #region IsEqual

        [TestMethod]
        public void IsEqual()
        {
            const int LHS = 5;
            const int RHS = 5;

            var result = Guard.That(LHS).IsEqual(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsEqualFailed()
        {
            const int LHS = 5;
            const int RHS = 6;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsEqual(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsEqualCustomMessageIsNull()
        {
            const int LHS = 5;
            const int RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualCustomMessageEmptyString()
        {
            const int LHS = 5;
            const int RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }


        [TestMethod]
        public void IsEqualCustomMessageIsWhitespace()
        {
            const int LHS = 5;
            const int RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualByFunc()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => 5;

            var result = Guard.That(LHS).IsEqual(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsEqualByFuncFailed()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => LHS + 1;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsEqualByFuncCustomMessageIsNull()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualByFuncCustomMessageEmptyString()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }


        [TestMethod]
        public void IsEqualByFuncCustomMessageIsWhitespace()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        #endregion IsEqual

        #region IsNotEqual

        [TestMethod]
        public void IsNotEqual()
        {
            const int LHS = 5;
            const int RHS = 6;

            var result = Guard.That(LHS).IsNotEqual(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsNotEqualFailed()
        {
            const int LHS = 5;
            const int RHS = 5;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotEqualCustomMessageIsNull()
        {
            const int LHS = 5;
            const int RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualCustomMessageEmptyString()
        {
            const int LHS = 5;
            const int RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }


        [TestMethod]
        public void IsNotEqualCustomMessageIsWhitespace()
        {
            const int LHS = 5;
            const int RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualByFunc()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => 6;

            var result = Guard.That(LHS).IsNotEqual(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsNotEqualByFuncFailed()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => LHS;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotEqualByFuncCustomMessageIsNull()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualByFuncCustomMessageEmptyString()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }


        [TestMethod]
        public void IsNotEqualByFuncCustomMessageIsWhitespace()
        {
            const int LHS = 5;
            Func<int> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        #endregion IsNotEqual

        #region IsInRange

        [TestMethod]
        public void IsInRange()
        {
            const int VALUE = 12;
            const int START = 10;
            const int END = 14;

            var result = Guard.That(VALUE).IsInRange(START, END, "Shouldn't see this.").Value;

            result.ShouldBeEquivalentTo(VALUE);
        }

        [TestMethod]
        public void IsInRangeFailed()
        {
            const int VALUE = 12;
            const int START = 13;
            const int END = 15;
            const string CUSTOMMESSAGE = "Not in Range or something like that.";

            Action check = () => Guard.That(VALUE).IsInRange(START, END, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsNull()
        {
            const int VALUE = 12;
            const int START = 13;
            const int END = 15;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsEmptyString()
        {
            const int VALUE = 12;
            const int START = 13;
            const int END = 15;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsWhitespace()
        {
            const int VALUE = 12;
            const int START = 10;
            const int END = 14;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        #endregion IsInRange

        #region IsPrime

        [TestMethod]
        public void IsPrime()
        {
            const int PRIME = 13;
            var result = Guard.That(PRIME).IsPrime("Shouldn't see this message").Value;

            result.ShouldBeEquivalentTo(PRIME);
        }

        [TestMethod]
        public void IsPrimeFailed()
        {
            const string EXPECTEDMESSAGE = "A special message or something.";

            Action check = () => Guard.That(4).IsPrime(EXPECTEDMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(EXPECTEDMESSAGE);
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsNull()
        {
            Action check = () => Guard.That(9).IsPrime(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(9).IsPrime(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(9).IsPrime("  ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        #endregion IsPrime

        #region IsNotPrime

        [TestMethod]
        public void IsNotPrime()
        {
            const int NOTPRIME = 55;
            var result = Guard.That(NOTPRIME).IsNotPrime().Value;

            result.ShouldBeEquivalentTo(NOTPRIME);
        }

        [TestMethod]
        public void IsNotPrimeFailed()
        {
            Action check = () => Guard.That(3).IsNotPrime();

            check.ShouldThrow<ArgumentException>()
                .WithMessage("Value cannot be prime.");
        }

        [TestMethod]
        public void IsNotPrimeCustomMessage()
        {
            const int NOTPRIME = 55;
            var result = Guard.That(NOTPRIME).IsNotPrime("Should not see this message!").Value;

            result.ShouldBeEquivalentTo(NOTPRIME);
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageFailed()
        {
            const string EXPECTEDMESSAGE = "Special sauce.";
            Action check = () => Guard.That(3).IsNotPrime(EXPECTEDMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(EXPECTEDMESSAGE);
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsNull()
        {
            Action check = () => Guard.That(9).IsNotPrime(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(9).IsNotPrime(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(9).IsNotPrime("  ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        #endregion IsNotPrime
    }
}
