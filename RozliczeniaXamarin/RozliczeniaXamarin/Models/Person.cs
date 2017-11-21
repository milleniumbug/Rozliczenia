using System;

namespace RozliczeniaXamarin.Models
{
	public class Person
	{
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