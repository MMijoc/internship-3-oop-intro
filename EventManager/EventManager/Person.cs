using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager
{
	class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PersonalIdentificationNumber { get; set; }
		public string PhoneNumber { get; set; }

		public Person()
		{

		}
		public Person(string name, string lastName, string id, string phoneNumber)
		{
			FirstName = name;
			LastName = lastName;
			PersonalIdentificationNumber = id;
			PhoneNumber = phoneNumber;
		}
		public void InputPerson()
		{
			Console.Write("Unesite ime osobe: ");
			var name = Console.ReadLine();
			name = name.Trim();

			Console.Write("Unesite prezime: ");
			var lastName = Console.ReadLine();
			lastName = lastName.Trim();

			Console.Write("Unesite OIB: ");
			var id = Console.ReadLine();
			PersonalIdentificationNumber = id.Trim();

			Console.Write("Unesite broj mobitela: ");
			var phoneNumber = Console.ReadLine();
			phoneNumber = phoneNumber.Trim();


			FirstName = name;
			LastName = lastName;
			PersonalIdentificationNumber = id;
			PhoneNumber = phoneNumber;

			return;
		}


	}
}
