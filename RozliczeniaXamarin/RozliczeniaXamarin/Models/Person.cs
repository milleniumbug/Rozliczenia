using System;

namespace RozliczeniaXamarin.Models
{
	public class Person : IEquatable<Person>
	{
		/// <inheritdoc />
		public bool Equals(Person other)
		{
			if(ReferenceEquals(null, other)) return false;
			if(ReferenceEquals(this, other)) return true;
			return string.Equals(Name, other.Name);
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if(ReferenceEquals(null, obj)) return false;
			if(ReferenceEquals(this, obj)) return true;
			if(obj.GetType() != this.GetType()) return false;
			return Equals((Person) obj);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public static bool operator ==(Person left, Person right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Person left, Person right)
		{
			return !Equals(left, right);
		}

		public string Name { get; }

		/// <inheritdoc />
		public Person(string name)
		{
			Name = name;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return Name;
		}
	}
}