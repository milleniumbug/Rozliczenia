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
		[Test]
		public void DistributeCostsBasic()
		{
			var a = new Person("A");
			var b = new Person("B");
			var c = new Person("C");
			CollectionAssert.AreEquivalent(
				new[] { new Transfer(b, a, 50.0m) },
				RozliczeniaXamarin.Calculator.DistributeCosts(new[]
				{
					new Payment(a, 100.0m),
					new Payment(b, 0.0m),
				}));
			CollectionAssert.AreEquivalent(
				new[] {new Transfer(c, a, 20.0m)},
				RozliczeniaXamarin.Calculator.DistributeCosts(
					new[]
					{
						new Payment(a, 40.0m),
						new Payment(b, 20.0m),
						new Payment(c, 0.0m)
					}));

			CollectionAssert.AreEquivalent(
				new[]
				{
					new Transfer(a, b, 10.0m),
					new Transfer(c, b, 10.0m)
				},
				RozliczeniaXamarin.Calculator.DistributeCosts(
					new[]
					{
						new Payment(a, 0.0m),
						new Payment(b, 30.0m),
						new Payment(c, 0.0m)
					}));

			CollectionAssert.AreEquivalent(
				new[]
				{
					new Transfer(a, b, 6.66m),
					new Transfer(c, b, 6.66m)
				},
				RozliczeniaXamarin.Calculator.DistributeCosts(
					new[]
					{
						new Payment(a, 0.0m),
						new Payment(b, 20.0m),
						new Payment(c, 0.0m)
					}));
		}
	}
}
