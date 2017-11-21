using System;

namespace RozliczeniaXamarin.Models
{
	public class Transfer : IEquatable<Transfer>
	{
		public Person From { get; }

		public Person To { get; }

		public decimal MoneyAmount { get; }

		public Transfer Clone(Person from = null, Person to = null, decimal? moneyAmount = null)
		{
			if(from == null)
				from = this.From;
			if(to == null)
				to = this.To;
			if(moneyAmount == null)
				moneyAmount = this.MoneyAmount;
			return new Transfer(from, to, moneyAmount.Value);
		}

		/// <inheritdoc />
		public bool Equals(Transfer other)
		{
			if(ReferenceEquals(null, other)) return false;
			if(ReferenceEquals(this, other)) return true;
			return From.Equals(other.From) && To.Equals(other.To) && MoneyAmount == other.MoneyAmount;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if(ReferenceEquals(null, obj)) return false;
			if(ReferenceEquals(this, obj)) return true;
			if(obj.GetType() != this.GetType()) return false;
			return Equals((Transfer) obj);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = From.GetHashCode();
				hashCode = (hashCode * 397) ^ To.GetHashCode();
				hashCode = (hashCode * 397) ^ MoneyAmount.GetHashCode();
				return hashCode;
			}
		}

		public static bool operator ==(Transfer left, Transfer right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Transfer left, Transfer right)
		{
			return !Equals(left, right);
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"{nameof(From)}: {From}, {nameof(To)}: {To}, {nameof(MoneyAmount)}: {MoneyAmount}";
		}

		/// <inheritdoc />
		public Transfer(Person from, Person to, decimal moneyAmount)
		{
			From = from;
			To = to;
			MoneyAmount = moneyAmount;
		}
	}
}