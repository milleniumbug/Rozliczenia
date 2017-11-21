using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RozliczeniaXamarin.Models;

namespace RozliczeniaTests
{
	[TestFixture]
	public class Calculator
	{
		private Person personA;
		private Person personB;
		private Person personC;

		[SetUp]
		public void SetUp()
		{
			personA = new Person("A");
			personB = new Person("B");
			personC = new Person("C");
		}

		[Test]
		public void DistributeCostsBasic()
		{

			CollectionAssert.AreEquivalent(
				new[] { new Transfer(personB, personA, 50.0m) },
				RozliczeniaXamarin.Calculator.DistributeCosts(new[]
				{
					new Payment(personA, 100.0m),
					new Payment(personB, 0.0m),
				}));
			CollectionAssert.AreEquivalent(
				new[] { new Transfer(personC, personA, 20.0m) },
				RozliczeniaXamarin.Calculator.DistributeCosts(
					new[]
					{
						new Payment(personA, 40.0m),
						new Payment(personB, 20.0m),
						new Payment(personC, 0.0m)
					}));

			CollectionAssert.AreEquivalent(
				new[]
				{
					new Transfer(personA, personB, 10.0m),
					new Transfer(personC, personB, 10.0m)
				},
				RozliczeniaXamarin.Calculator.DistributeCosts(
					new[]
					{
						new Payment(personA, 0.0m),
						new Payment(personB, 30.0m),
						new Payment(personC, 0.0m)
					}));
		}

		[Test]
		[Ignore("integrating FsCheck")]
		public void TroublesomeRoundingTest()
		{
			CollectionAssert.AreEquivalent(
				new[]
				{
					new Transfer(personA, personB, 6.66m),
					new Transfer(personC, personB, 6.66m)
				},
				RozliczeniaXamarin.Calculator.DistributeCosts(
					new[]
					{
						new Payment(personA, 0.0m),
						new Payment(personB, 20.0m),
						new Payment(personC, 0.0m)
					}));
		}
	}
}
