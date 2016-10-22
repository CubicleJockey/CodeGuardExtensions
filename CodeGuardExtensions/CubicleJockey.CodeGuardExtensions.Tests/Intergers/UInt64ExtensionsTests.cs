using System;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests.Intergers
{
    [TestClass]
    public class UInt64ExtensionsTests : BaseTest
    {
        #region IsEven

        [TestMethod]
        public void IsEven()
        {
            const ulong value = 12;
            var result = Guard.That(value).IsEven().Value;

            (result % 2).ShouldBeEquivalentTo(0); //Even
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsEven_Failed()
        {
            const string MESSAGE = "Math Message";
            Action check = () => Guard.That(1u).IsEven(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsEvenCustomMessage()
        {
            const ulong value = 2;

            var result = Guard.That(value).IsEven("Shouldn't get me.").Value;

            (result % 2).ShouldBeEquivalentTo(0); //Even
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsEvenMessage_Failed()
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
            const ulong value = 11;
            var result = Guard.That(value).IsOdd().Value;

            (result % 2).Should().NotBe(0); //Odd
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsOdd_Failed()
        {
            const string MESSAGE = "Math Message";
            Action check = () => Guard.That(2u).IsOdd(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsOddCustomMessage()
        {
            const ulong value = 1;

            var result = Guard.That(value).IsOdd("Shouldn't get me.").Value;

            (result % 2).Should().NotBe(0); //Odd
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsOddCustoMessage_Failed()
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
            const ulong RHS = 4;
            const ulong LHS = 6;

            var result = Guard.That(LHS).IsGreaterThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsGreaterThan_Fail()
        {
            const ulong RHS = 6;
            const ulong LHS = 4;
            const string CUSTOMMESSAGE = "Why you no greater?";

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsNull()
        {
            const ulong RHS = 4;
            const ulong LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsEmptyString()
        {
            const ulong RHS = 4;
            const ulong LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsWhitespace()
        {
            const ulong RHS = 4;
            const ulong LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFunc()
        {
            const ulong RHS = 4;
            const ulong LHS = 6;

            var result = Guard.That(LHS).IsGreaterThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsGreaterThanByFunc_Fail()
        {
            Func<ulong> rhsFunc = () => (4 + 6 + 20);
            const ulong LHS = 4;
            const string CUSTOMMESSAGE = "Why you no greater?";

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsNull()
        {
            Func<ulong> rhsFunc = () => (4);
            const ulong LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsEmptyString()
        {
            Func<ulong> func = () => (4);
            const ulong LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(func, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsWhitespace()
        {
            Func<ulong> rhsFunc = () => (4);
            const ulong LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        #endregion IsGreatherThan

        #region IsLessThan

        [TestMethod]
        public void IsLessThan()
        {
            const ulong RHS = 6;
            const ulong LHS = 4;

            var result = Guard.That(LHS).IsLessThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsLessThan_Fail()
        {
            const ulong RHS = 4;
            const ulong LHS = 6;
            const string CUSTOMMESSAGE = "Why you no lesser?";

            Action check = () => Guard.That(LHS).IsLessThan(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsNull()
        {
            const ulong RHS = 6;
            const ulong LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsEmptyString()
        {
            const ulong RHS = 6;
            const ulong LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsWhitespace()
        {
            const ulong RHS = 6;
            const ulong LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFunc()
        {
            Func<ulong> rhsFunc = () => (4 + 2);
            const ulong LHS = 4;

            var result = Guard.That(LHS).IsLessThan(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsLessThanByFunc_Fail()
        {
            Func<ulong> rhsFunc = () => (4);
            const ulong LHS = 6;
            const string CUSTOMMESSAGE = "Why you no lesser?";

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsNull()
        {
            Func<ulong> rhsFunc = () => (4 + 5);
            const ulong LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsEmptyString()
        {
            Func<ulong> rhsFunc = () => (4 + 5);
            const ulong LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsWhitespace()
        {
            Func<ulong> rhsFunc = () => (4 + 5);
            const ulong LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        #endregion IsLessThan

        #region IsEqual

        [TestMethod]
        public void IsEqual()
        {
            const ulong LHS = 5;
            const ulong RHS = 5;

            var result = Guard.That(LHS).IsEqual(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsEqual_Failed()
        {
            const ulong LHS = 5;
            const ulong RHS = 6;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsEqual(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsEqualCustomMessageIsNull()
        {
            const ulong LHS = 5;
            const ulong RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualCustomMessageEmptyString()
        {
            const ulong LHS = 5;
            const ulong RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }


        [TestMethod]
        public void IsEqualCustomMessageIsWhitespace()
        {
            const ulong LHS = 5;
            const ulong RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualByFunc()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => 5;

            var result = Guard.That(LHS).IsEqual(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsEqualByFunc_Failed()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => LHS + 1;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsEqualByFuncCustomMessageIsNull()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualByFuncCustomMessageEmptyString()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }


        [TestMethod]
        public void IsEqualByFuncCustomMessageIsWhitespace()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        #endregion IsEqual

        #region IsNotEqual

        [TestMethod]
        public void IsNotEqual()
        {
            const ulong LHS = 5;
            const ulong RHS = 6;

            var result = Guard.That(LHS).IsNotEqual(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsNotEqual_Failed()
        {
            const ulong LHS = 5;
            const ulong RHS = 5;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotEqualCustomMessageIsNull()
        {
            const ulong LHS = 5;
            const ulong RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualCustomMessageEmptyString()
        {
            const ulong LHS = 5;
            const ulong RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }


        [TestMethod]
        public void IsNotEqualCustomMessageIsWhitespace()
        {
            const ulong LHS = 5;
            const ulong RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualByFunc()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => 6;

            var result = Guard.That(LHS).IsNotEqual(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsNotEqualByFunc_Failed()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => LHS;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotEqualByFuncCustomMessageIsNull()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualByFuncCustomMessageEmptyString()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }


        [TestMethod]
        public void IsNotEqualByFuncCustomMessageIsWhitespace()
        {
            const ulong LHS = 5;
            Func<ulong> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        #endregion IsNotEqual

        #region IsInRange

        [TestMethod]
        public void IsInRange()
        {
            const ulong VALUE = 12;
            const ulong START = 10;
            const ulong END = 14;

            var result = Guard.That(VALUE).IsInRange(START, END, "Shouldn't see this.").Value;

            result.ShouldBeEquivalentTo(VALUE);
        }

        [TestMethod]
        public void IsInRange_Failed()
        {
            const ulong VALUE = 12;
            const ulong START = 13;
            const ulong END = 15;
            const string CUSTOMMESSAGE = "Not in Range or something like that.";

            Action check = () => Guard.That(VALUE).IsInRange(START, END, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsNull()
        {
            const ulong VALUE = 12;
            const ulong START = 13;
            const ulong END = 15;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsEmptyString()
        {
            const ulong VALUE = 12;
            const ulong START = 13;
            const ulong END = 15;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsWhitespace()
        {
            const ulong VALUE = 12;
            const ulong START = 10;
            const ulong END = 14;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        #endregion IsInRange

        #region IsPrime

        [TestMethod]
        public void IsPrime()
        {
            const ulong PRIME = 839;
            var result = Guard.That(PRIME).IsPrime().Value;

            result.ShouldBeEquivalentTo(PRIME);
        }

        [TestMethod]
        public void IsPrime_Failed()
        {
            Action check = () => Guard.That(4u).IsPrime();
            check.ShouldThrow<ArgumentException>()
                .WithMessage("Value should be prime.");
        }

        [TestMethod]
        public void IsPrimeCustomMessage()
        {
            const ulong PRIME = 13;
            var result = Guard.That(PRIME).IsPrime("Shouldn't see this message").Value;

            result.ShouldBeEquivalentTo(PRIME);
        }

        [TestMethod]
        public void IsPrimeMessage_Failed()
        {
            const string EXPECTEDMESSAGE = "A special message or something.";

            Action check = () => Guard.That(4u).IsPrime(EXPECTEDMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(EXPECTEDMESSAGE);
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsNull()
        {
            Action check = () => Guard.That(9u).IsPrime(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(9u).IsPrime(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(9u).IsPrime("  ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        #endregion IsPrime

        #region IsNotPrime

        [TestMethod]
        public void IsNotPrime()
        {
            const ulong NOTPRIME = 55;
            var result = Guard.That(NOTPRIME).IsNotPrime().Value;

            result.ShouldBeEquivalentTo(NOTPRIME);
        }

        [TestMethod]
        public void IsNotPrime_Failed()
        {
            Action check = () => Guard.That(3).IsNotPrime();

            check.ShouldThrow<ArgumentException>()
                .WithMessage("Value cannot be prime.");
        }

        [TestMethod]
        public void IsNotPrimeCustomMessage()
        {
            const ulong NOTPRIME = 55;
            var result = Guard.That(NOTPRIME).IsNotPrime("Should not see this message!").Value;

            result.ShouldBeEquivalentTo(NOTPRIME);
        }

        [TestMethod]
        public void IsNotPrimeCustomMessage_Failed()
        {
            const string EXPECTEDMESSAGE = "Special sauce.";
            Action check = () => Guard.That(3u).IsNotPrime(EXPECTEDMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(EXPECTEDMESSAGE);
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsNull()
        {
            Action check = () => Guard.That(9u).IsNotPrime(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That(9u).IsNotPrime(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That(9u).IsNotPrime("  ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        #endregion IsNotPrime
    }
}