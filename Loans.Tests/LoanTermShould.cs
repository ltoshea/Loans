using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Loans.Tests
{
    // Arrange - Setup test object, init data
    // Act - Call method, set property
    // Assert - Compare return value to expected

    [TestFixture]
    public class LoanTermShould
    {
        [Test]
        //[Ignore("Need to complete update work.")] 
        public void ReturnTermInMonths()
        {
            var sut = new LoanTerm(1);

            Assert.That(sut.ToMonths(), Is.EqualTo(12), "Months should be 12 * number of years");
        }

        [Test]
        public void StoreYears()
        {
            var sut = new LoanTerm(1);

            Assert.That(sut.Years, Is.EqualTo(1));
        }

        [Test]
        public void RespectValueEquality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            Assert.That(a, Is.EqualTo(b));
        }
        
        [Test]
        public void RespectValueInEquality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);

            Assert.That(a, Is.Not.EqualTo(b));
        }

        //SameAs is for reference types pointing to the same object in memory
        [Test]
        public void ReferenceEqualityExample()
        {
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(1);

            Assert.That(a, Is.SameAs(b));
            Assert.That(a, Is.Not.SameAs(c));

            var x = new List<string> { "a", "b" };
            var y = x;
            var z = new List<string> { "a", "b" };

            Assert.That(y, Is.SameAs(x));
            Assert.That(z, Is.Not.SameAs(x));
        }

        //Within used here to give a tolerance
        [Test]
        public void Double()
        {
            double a = 1.0 / 3.0;
            
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));
            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent);
        }

        [Test]
        public void NotAllowZeroYears()
        {
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                                .With
                                .Property("Message") //Not type safe
                                .EqualTo("Please specify a value greater than 0.\r\nParameter name: years"));

            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                                .With
                                .Message
                                .EqualTo("Please specify a value greater than 0.\r\nParameter name: years"));

            // Correct ex and para name but don't care about the message
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                                .With
                                .Property("ParamName")
                                .EqualTo("years"));

            //Is type safe
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                              .With
                              .Matches<ArgumentOutOfRangeException>(
                                ex => ex.ParamName == "years"));
        }

    }
}
