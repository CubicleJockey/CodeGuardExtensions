using System;
using CubicleJockey.CodeGuardExtensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtentions.Tests
{
    [TestClass]
    public class SByteExtensionsTests : BaseTest
    {
        #region IsPositive

        [TestMethod]
        public void IsPositive()
        {
            const sbyte value = 10;

            var result = Guard.That(value).IsPositive("Shouldn't get me.").Value;

            result.Should().BeGreaterOrEqualTo(0);
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsPositive_Failed()
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
            const sbyte value = -10;

            var result = Guard.That(value).IsNegative("Shouldn't get me.").Value;

            result.Should().BeLessThan(0);
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsNegative_Failed()
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
            const sbyte value = 2;

            var result = Guard.That(value).IsEven("Shouldn't get me.").Value;

            (result % 2).ShouldBeEquivalentTo(0); //Even
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsEven_Failed()
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
            const sbyte value = 1;

            var result = Guard.That(value).IsOdd().Value;

            (result % 2).Should().BeGreaterThan(0); //Odd
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsOdd_Failed()
        {
            Action check = () => Guard.That((sbyte)2).IsOdd();

            check.ShouldThrow<ArgumentException>()
                 .WithMessage("Value must be odd.");
        }

        [TestMethod]
        public void IsOddCustomMessage()
        {
            const sbyte value = 1;

            var result = Guard.That(value).IsOdd("Shouldn't get me.").Value;

            (result % 2).Should().BeGreaterThan(0); //Odd
            result.ShouldBeEquivalentTo(value);
        }

        [TestMethod]
        public void IsOddCustomMessage_Failed()
        {
            const string MESSAGE = "Math Message";

            Action check = () => Guard.That((sbyte)2).IsOdd(MESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(MESSAGE);
        }

        [TestMethod]
        public void IsOddCustomMessageIsNull()
        {
            Action check = () => Guard.That((sbyte)2).IsOdd(null);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsOdd"));
        }

        [TestMethod]
        public void IsOddCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That((sbyte)1).IsOdd(string.Empty);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsOdd"));
        }

        [TestMethod]
        public void IsOddCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That((sbyte)1).IsOdd("      ");

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(ExpectedCustomeInvalidErrorMessage("IsOdd"));
        }

        #endregion IsOdd

        #region IsGreatherThan

        [TestMethod]
        public void IsGreaterThan()
        {
            const sbyte RHS = 4;
            const sbyte LHS = 6;

            var result = Guard.That(LHS).IsGreaterThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsGreaterThan_Fail()
        {
            const sbyte RHS = 6;
            const sbyte LHS = 4;
            const string CUSTOMMESSAGE = "Why you no greater?";

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsNull()
        {
            const sbyte RHS = 4;
            const sbyte LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsEmptyString()
        {
            const sbyte RHS = 4;
            const sbyte LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanCustomMessageIsWhitespace()
        {
            const sbyte RHS = 4;
            const sbyte LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFunc()
        {
            const sbyte RHS = 4;
            const sbyte LHS = 6;

            var result = Guard.That(LHS).IsGreaterThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsGreaterThanByFunc_Fail()
        {
            Func<sbyte> rhsFunc = () => (4 + 6 + 20);
            const sbyte LHS = 4;
            const string CUSTOMMESSAGE = "Why you no greater?";

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsNull()
        {
            Func<sbyte> rhsFunc = () => (4);
            const sbyte LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsEmptyString()
        {
            Func<sbyte> func = () => (4);
            const sbyte LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(func, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        [TestMethod]
        public void IsGreaterThanByFuncCustomMessageIsWhitespace()
        {
            Func<sbyte> rhsFunc = () => (4);
            const sbyte LHS = 6;

            Action check = () => Guard.That(LHS).IsGreaterThan(rhsFunc, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsGreaterThan"));
        }

        #endregion IsGreatherThan

        #region IsLessThan

        [TestMethod]
        public void IsLessThan()
        {
            const sbyte RHS = 6;
            const sbyte LHS = 4;

            var result = Guard.That(LHS).IsLessThan(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsLessThan_Fail()
        {
            const sbyte RHS = 4;
            const sbyte LHS = 6;
            const string CUSTOMMESSAGE = "Why you no lesser?";

            Action check = () => Guard.That(LHS).IsLessThan(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsNull()
        {
            const sbyte RHS = 6;
            const sbyte LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsEmptyString()
        {
            const sbyte RHS = 6;
            const sbyte LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanCustomMessageIsWhitespace()
        {
            const sbyte RHS = 6;
            const sbyte LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(RHS, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFunc()
        {
            Func<sbyte> rhsFunc = () => (4 + 2);
            const sbyte LHS = 4;

            var result = Guard.That(LHS).IsLessThan(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsLessThanByFunc_Fail()
        {
            Func<sbyte> rhsFunc = () => (4);
            const sbyte LHS = 6;
            const string CUSTOMMESSAGE = "Why you no lesser?";

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                 .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsNull()
        {
            Func<sbyte> rhsFunc = () => (4 + 5);
            const sbyte LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsEmptyString()
        {
            Func<sbyte> rhsFunc = () => (4 + 5);
            const sbyte LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        [TestMethod]
        public void IsLessThanByFuncCustomMessageIsWhitespace()
        {
            Func<sbyte> rhsFunc = () => (4 + 5);
            const sbyte LHS = 4;

            Action check = () => Guard.That(LHS).IsLessThan(rhsFunc, "   ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsLessThan"));
        }

        #endregion IsLessThan

        #region IsEqual

        [TestMethod]
        public void IsEqual()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 5;

            var result = Guard.That(LHS).IsEqual(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsEqual_Failed()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 6;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsEqual(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsEqualCustomMessageIsNull()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualCustomMessageEmptyString()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }


        [TestMethod]
        public void IsEqualCustomMessageIsWhitespace()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 6;

            Action check = () => Guard.That(LHS).IsEqual(RHS, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualByFunc()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => 5;

            var result = Guard.That(LHS).IsEqual(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsEqualByFunc_Failed()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => LHS + 1;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsEqualByFuncCustomMessageIsNull()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        [TestMethod]
        public void IsEqualByFuncCustomMessageEmptyString()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }


        [TestMethod]
        public void IsEqualByFuncCustomMessageIsWhitespace()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsEqual(rhsFunc, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsEqual"));
        }

        #endregion IsEqual

        #region IsNotEqual

        [TestMethod]
        public void IsNotEqual()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 6;

            var result = Guard.That(LHS).IsNotEqual(RHS, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsNotEqual_Failed()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 5;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotEqualCustomMessageIsNull()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualCustomMessageEmptyString()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }


        [TestMethod]
        public void IsNotEqualCustomMessageIsWhitespace()
        {
            const sbyte LHS = 5;
            const sbyte RHS = 6;

            Action check = () => Guard.That(LHS).IsNotEqual(RHS, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualByFunc()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => 6;

            var result = Guard.That(LHS).IsNotEqual(rhsFunc, "Should not see me.").Value;

            result.ShouldBeEquivalentTo(LHS);
        }

        [TestMethod]
        public void IsNotEqualByFunc_Failed()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => LHS;
            const string CUSTOMMESSAGE = "Not Equal and stuff!";

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsNotEqualByFuncCustomMessageIsNull()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        [TestMethod]
        public void IsNotEqualByFuncCustomMessageEmptyString()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }


        [TestMethod]
        public void IsNotEqualByFuncCustomMessageIsWhitespace()
        {
            const sbyte LHS = 5;
            Func<sbyte> rhsFunc = () => LHS + 1;

            Action check = () => Guard.That(LHS).IsNotEqual(rhsFunc, "    ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotEqual"));
        }

        #endregion IsNotEqual

        #region IsInRange

        [TestMethod]
        public void IsInRange()
        {
            const sbyte VALUE = 12;
            const sbyte START = 10;
            const sbyte END = 14;

            var result = Guard.That(VALUE).IsInRange(START, END, "Shouldn't see this.").Value;

            result.ShouldBeEquivalentTo(VALUE);
        }

        [TestMethod]
        public void IsInRange_Failed()
        {
            const sbyte VALUE = 12;
            const sbyte START = 13;
            const sbyte END = 15;
            const string CUSTOMMESSAGE = "Not in Range or something like that.";

            Action check = () => Guard.That(VALUE).IsInRange(START, END, CUSTOMMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(CUSTOMMESSAGE);
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsNull()
        {
            const sbyte VALUE = 12;
            const sbyte START = 13;
            const sbyte END = 15;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsEmptyString()
        {
            const sbyte VALUE = 12;
            const sbyte START = 13;
            const sbyte END = 15;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        [TestMethod]
        public void IsInRangeCustomMessageIsWhitespace()
        {
            const sbyte VALUE = 12;
            const sbyte START = 10;
            const sbyte END = 14;

            Action check = () => Guard.That(VALUE).IsInRange(START, END, null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsInRange"));
        }

        #endregion IsInRange

        #region IsPrime

        [TestMethod]
        public void IsPrime()
        {
            const sbyte PRIME = 13;
            var result = Guard.That(PRIME).IsPrime("Shouldn't see this message").Value;

            result.ShouldBeEquivalentTo(PRIME);
        }

        [TestMethod]
        public void IsPrime_Failed()
        {
            const string EXPECTEDMESSAGE = "A special message or something.";

            Action check = () => Guard.That((sbyte)4).IsPrime(EXPECTEDMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(EXPECTEDMESSAGE);
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsNull()
        {
            Action check = () => Guard.That((sbyte)9).IsPrime(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That((sbyte)9).IsPrime(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        [TestMethod]
        public void IsPrimeCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That((sbyte)9).IsPrime("  ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsPrime"));
        }

        #endregion IsPrime

        #region IsNotPrime

        [TestMethod]
        public void IsNotPrime()
        {
            const sbyte NOTPRIME = 55;
            var result = Guard.That(NOTPRIME).IsNotPrime().Value;

            result.ShouldBeEquivalentTo(NOTPRIME);
        }

        [TestMethod]
        public void IsNotPrime_Failed()
        {
            Action check = () => Guard.That((sbyte)3).IsNotPrime();

            check.ShouldThrow<ArgumentException>()
                .WithMessage("Value cannot be prime.");
        }

        [TestMethod]
        public void IsNotPrimeCustomMessage()
        {
            const sbyte NOTPRIME = 6;
            var result = Guard.That(NOTPRIME).IsNotPrime("Should not see this message!").Value;

            result.ShouldBeEquivalentTo(NOTPRIME);
        }

        [TestMethod]
        public void IsNotPrimeCustomMessage_Failed()
        {
            const string EXPECTEDMESSAGE = "Special sauce.";
            Action check = () => Guard.That((sbyte)3).IsNotPrime(EXPECTEDMESSAGE);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(EXPECTEDMESSAGE);
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsNull()
        {
            Action check = () => Guard.That((sbyte)8).IsNotPrime(null);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsEmptyString()
        {
            Action check = () => Guard.That((sbyte)8).IsNotPrime(string.Empty);

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        [TestMethod]
        public void IsNotPrimeCustomMessageIsWhitespace()
        {
            Action check = () => Guard.That((sbyte)8).IsNotPrime("  ");

            check.ShouldThrow<ArgumentException>()
                .WithMessage(ExpectedCustomeInvalidErrorMessage("IsNotPrime"));
        }

        #endregion IsNotPrime
    }
}