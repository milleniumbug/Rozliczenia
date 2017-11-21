using System;
using System.Collections.Generic;
using System.Text;

namespace RozliczeniaXamarin.Models
{
    public class Payment : IEquatable<Payment>
    {
	    /// <inheritdoc />
	    public bool Equals(Payment other)
	    {
		    if(ReferenceEquals(null, other)) return false;
		    if(ReferenceEquals(this, other)) return true;
		    return MoneyAmount == other.MoneyAmount && Who.Equals(other.Who);
	    }

	    /// <inheritdoc />
	    public override bool Equals(object obj)
	    {
		    if(ReferenceEquals(null, obj)) return false;
		    if(ReferenceEquals(this, obj)) return true;
		    if(obj.GetType() != this.GetType()) return false;
		    return Equals((Payment) obj);
	    }

	    /// <inheritdoc />
	    public override int GetHashCode()
	    {
		    unchecked
		    {
			    return (MoneyAmount.GetHashCode() * 397) ^ Who.GetHashCode();
		    }
	    }

	    public static bool operator ==(Payment left, Payment right)
	    {
		    return Equals(left, right);
	    }

	    public static bool operator !=(Payment left, Payment right)
	    {
		    return !Equals(left, right);
	    }

	    public decimal MoneyAmount { get; }

		public Person Who { get; }

	    public Payment Clone(Person who = null, decimal? moneyAmount = null)
	    {
		    if(moneyAmount == null)
			    moneyAmount = this.MoneyAmount;
		    if(who == null)
			    who = this.Who;
			return new Payment(who, moneyAmount.Value);
	    }

	    /// <inheritdoc />
	    public override string ToString()
	    {
		    return $"{nameof(MoneyAmount)}: {MoneyAmount}, {nameof(Who)}: {Who}";
	    }

	    /// <inheritdoc />
	    public Payment(Person who, decimal moneyAmount)
	    {
		    MoneyAmount = moneyAmount;
		    Who = who;
	    }
    }
}
