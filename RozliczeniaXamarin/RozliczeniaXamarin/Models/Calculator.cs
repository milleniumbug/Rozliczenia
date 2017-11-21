using System;
using System.Collections.Generic;
using System.Linq;
using RozliczeniaXamarin.Models;

namespace RozliczeniaXamarin
{
	public class Calculator
    {
	    public static IEnumerable<Transfer> DistributeCosts(IReadOnlyCollection<Payment> initialPayments)
	    {
		    var sum = initialPayments.Sum(payment => payment.MoneyAmount);
		    var avg = sum / initialPayments.Count;
		    var paidTooMuch = initialPayments.Where(payment => payment.MoneyAmount > avg).ToList();
		    var paidTooLittle = initialPayments.Where(payment => payment.MoneyAmount < avg).ToList();
		    var result = new List<Transfer>();
		    var paidTooMuchIndex = 0;
		    foreach(var payment in paidTooLittle)
		    {
			    var needsToPay = avg - payment.MoneyAmount;
			    while(needsToPay > 0.0m)
			    {
				    var paymentAmount = Math.Min(needsToPay, paidTooMuch[paidTooMuchIndex].MoneyAmount - avg);
				    if(paymentAmount == 0.0m)
						break;
				    needsToPay -= paymentAmount;
				    paidTooMuch[paidTooMuchIndex] = paidTooMuch[paidTooMuchIndex].Clone(moneyAmount: paidTooMuch[paidTooMuchIndex].MoneyAmount - paymentAmount);
					result.Add(new Transfer(
						from: payment.Who,
						to: paidTooMuch[paidTooMuchIndex].Who,
						moneyAmount: paymentAmount
					));
				    if(paidTooMuch[paidTooMuchIndex].MoneyAmount == 0.0m)
					    paidTooMuchIndex++;
			    }
		    }
		    return result.Select(transfer => transfer.Clone(moneyAmount: Math.Round(transfer.MoneyAmount, 2)));
	    }
    }
}
