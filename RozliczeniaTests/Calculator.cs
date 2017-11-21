using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FsCheck;
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

		[Test]
		public void EmptyInput()
		{
			// found by FsCheck
			Assert.DoesNotThrow(() => RozliczeniaXamarin.Calculator.DistributeCosts(new Payment[0]));
		}

		[Test]
		public void Fuzz()
		{
			Func<Payment[], bool> inputMoneyEqualsOutputMoney = payments =>
			{
				var input = payments.Sum(payment => payment.MoneyAmount);
				var afterPayments = payments.ToDictionary(payment => payment.Who, payment => payment);
				var transfers = RozliczeniaXamarin.Calculator.DistributeCosts(payments);
				foreach(var transfer in transfers)
				{
					afterPayments[transfer.To] = afterPayments[transfer.To]
						.Clone(moneyAmount: afterPayments[transfer.To].MoneyAmount + transfer.MoneyAmount);
					afterPayments[transfer.From] = afterPayments[transfer.From]
						.Clone(moneyAmount: afterPayments[transfer.From].MoneyAmount - transfer.MoneyAmount);
				}
				var output = afterPayments.Select(x => x.Value).Sum(payment => payment.MoneyAmount);
				return input == output;
			};
			FsCheck.Prop.ForAll(inputMoneyEqualsOutputMoney).QuickCheckThrowOnFailure();
		}
	}
}
