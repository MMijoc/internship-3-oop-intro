using System;
using System.Collections.Generic;

enum ReturnStatus
{
	Success,
	Failure
}

namespace EventManager
{
	class Program
	{
		static void Main(string[] args)
		{
			SelectMenu();

		}

		static void PrintMainMenu()
		{
			Console.WriteLine("1 - Dodaj event");
			Console.WriteLine("2 - Brisanje eventa");
			Console.WriteLine("3 - Uredi event");
			Console.WriteLine("4 - Dodaj osobu(e) na event");
			Console.WriteLine("5 - Ukloni osobu sa eventa");
			Console.WriteLine("6 - Ispis detalja eventa");
			Console.WriteLine("0 - izlaz");
			Console.Write("Izbor: ");

			return;
		}

		static void PrintSubmenu()
		{
			Console.WriteLine("Ispis detalja eventa");
			Console.WriteLine("\t1 - Ispis u formatu: ime eventa - vrijeme početka - vrijeme kraja - broji ljudi na eventu");
			Console.WriteLine("\t2 - Ispis svih osoba na eventu u formatu: redni broj - ime - prezime - broj mobitela");
			Console.WriteLine("\t3 - Ispis svih detalja (eventa i osoba na njima)");
			Console.WriteLine("\t0 - natrag");
			Console.Write("Izbor: ");

			return;
		}

		static void SelectMenu()
		{
			var EventAndAttendants = new Dictionary<Event, List<Person>>();
			EventAndAttendants = TestSamples.GetTestSamples();

			while (true)
			{
				var input = "";

				PrintMainMenu();
				var isNumber = int.TryParse(input = Console.ReadLine(), out var select);

				if (!isNumber)
				{
					Console.WriteLine("Nepoznata naredba \"{0}\"\nPritnisni bilo koju tipku za nastavak . . .", input);
					Console.ReadLine();
					Console.Clear();
					continue;
				}

				switch (select)
				{
					case 1:
						AddEvent(EventAndAttendants);
						break;
					case 2:

						break;
					case 3:

						break;
					case 4:

						break;
					case 5:

						break;
					case 6:
						SubmenuSelect(EventAndAttendants);
						Console.Clear();
						continue;
					case 0:
						return;
					default:
						Console.WriteLine("Nepoznata naredba \"{0}\"", input);
						break;
				}

				Console.WriteLine("\nPritnisni bilo koju tipku za nastavak . . .");
				Console.ReadLine();
				Console.Clear();
			}
		}

		static void AddEvent(Dictionary<Event, List<Person>> EventAndAttendants)
		{
			var newEvent = new Event();
			Console.Write("Unesite ime novog eventa: ");
			var name = Console.ReadLine();
			name = name.Trim();
			//provjerit je li event s imenom vec postoji
			newEvent.Name = name;
			newEvent.InputEventType();
			newEvent.InputStarTime();
			newEvent.InputEndTime();

			var attendantsList = new List<Person>();

			EventAndAttendants.Add(newEvent, attendantsList);

			return;
		}

		static void AddPerson(Dictionary<Event, List<Person>> EventAndAttendants)
		{
			var eventName = InputString("Unesite ime eventa na koji želite dodati nove osobe: ");

			foreach (var item in EventAndAttendants)
			{
				if (eventName.Equals(item.Key.Name, StringComparison.OrdinalIgnoreCase))
				{
					var newPerson = new Person();
					newPerson.InputPerson();
					item.Value.Add(newPerson);
					break;
				}
			}

			return;
		}

		static void SubmenuSelect(Dictionary<Event, List<Person>> EventAndAttendants)
		{
			Console.Clear();
			while (true)
			{
				var input = "";

				PrintSubmenu();
				var isNumber = int.TryParse(input = Console.ReadLine(), out var select);

				if (!isNumber)
				{
					Console.WriteLine("Nepoznata naredba \"{0}\"\nPritnisni bilo koju tipku za nastavak . . .", input);
					Console.ReadLine();
					Console.Clear();
					continue;
				}

				PrintEvents(EventAndAttendants);
				int eventId;
				switch (select)
				{
					case 1:
						eventId = InputNumber("Unesite Id eventa: ");
						Console.Clear();
						PrintEventDetails(EventAndAttendants, eventId);
						break;
					case 2:
						eventId = InputNumber("Unesite Id eventa: ");
						Console.Clear();
						PrintEventAttendants(EventAndAttendants, eventId);
						break;
					case 3:
						eventId = InputNumber("Unesite Id eventa: ");
						Console.Clear();
						PrintEventDetails(EventAndAttendants, eventId);
						PrintEventAttendants(EventAndAttendants, eventId);

						//foreach (var item in EventAndAttendants)
						//{
						//	if (item.Key.EventId == eventId)
						//	{

						//		Console.Write("\n{0, -40} {1, -16} {2, -32} {3, -32} {4, -32} {5, -8}", "Event", "Tip eventa", "Vrjijeme početka", "Vrijeme završetka", "Vrijeme trajanja (u satima)", "Broj sudionika");
						//		item.Key.PrintDetails();
						//		Console.Write("{0, -32} {1, 8}", item.Key.EndTime - item.Key.StartTime, item.Value.Count);

						//		Console.WriteLine("\n\nLista osoba koji idu na event:");
						//		var i = 0;
						//		foreach (var person in item.Value)
						//		{
						//			Console.Write("{0, -8}", i);
						//			person.PrintDetails();
						//			i++;
						//		}
						//	}

						//}

						break;
					case 0:
						return;
					default:
						Console.WriteLine("Nepoznata naredba \"{0}\"", input);
						break;
				}

				Console.WriteLine("\nPritnisni bilo koju tipku za nastavak . . .");
				Console.ReadLine();
				Console.Clear();
			}
		}

		static void PrintEventDetails(Dictionary<Event, List<Person>> EventAndAttendants, int eventId)
		{
			foreach (var item in EventAndAttendants)
			{
				if (item.Key.EventId == eventId)
				{
					Console.WriteLine("{0, -32} {1, -16} {2, -32} {3, -32} {4, -32} {5, -8}", "Event", "Tip eventa", "Vrjijeme početka", "Vrijeme završetka", "Vrijeme trajanja (u satima)", "Broj sudionika");
					Console.WriteLine("{0, -32} {1, -16} {2, -32} {3, -32} {4, -32} {5, -8}", item.Key.Name, item.Key.Type, item.Key.StartTime, item.Key.EndTime, item.Key.EndTime - item.Key.StartTime, item.Value.Count);
					return;
				}
			}

			Console.WriteLine("Ne postoji event s ID-om \"{0}\"", eventId);
			return;
		}

		static void PrintEventAttendants(Dictionary<Event, List<Person>> EventAndAttendants, int eventId)
		{
			foreach (var item in EventAndAttendants)
			{
				if (item.Key.EventId == eventId)
				{
					Console.WriteLine("Lista osoba koji idu na event:");
					Console.WriteLine("{0, -12} {1, -32} {2, -32} {3, -16}", "Redni broj", "Ime", "Prezim", "Broj mobitela");
					var i = 1;
					foreach (var person in item.Value)
					{
						Console.WriteLine("{0, -12} {1, -32} {2, -32} {3, -16}", i, person.FirstName, person.LastName, person.PhoneNumber);
						//Console.Write("{0, -8}", i);
						//person.PrintDetails();
						i++;
					}
					return;
				}
			}

			Console.WriteLine("Ne postoji event s ID-om \"{0}\"", eventId);
			return;
		}

		static bool EventExists(Dictionary<Event, List<Person>> EventAndAttendants, string eventName)
		{
			var exists = false;

			foreach (var item in EventAndAttendants)
			{
				if (eventName.Equals(item.Key.Name, StringComparison.OrdinalIgnoreCase))
				{
					exists = true;
					break;
				}
			}

			return exists;
		}

		static void PrintEvents(Dictionary<Event, List<Person>> EventAndAttendants)
		{
			foreach (var item in EventAndAttendants)
				Console.WriteLine("{0, 8} {1, -32}", item.Key.EventId, item.Key.Name);

			return;
		}

		public static bool ConfirmAction()
		{
			Console.WriteLine("Jeste li sigurni da zelite nastaviti?\n\tDA - da želim nastaviti\n\tNE - ne zelim nastaviti (unesi bilo koju tipku za prekid)");
			Console.Write("Izbor: ");
			var input = Console.ReadLine();

			return input.Equals("da", StringComparison.OrdinalIgnoreCase);
		}

		public static string InputString(string message)
		{
			if (!string.IsNullOrEmpty(message))
				Console.Write("\n" + message);

			var input = Console.ReadLine();
			input = input.Trim();


			return input;
		}

		static int InputNumber(string message)
		{
			while (true)
			{
				if (message != "")
					Console.Write(message);
				bool isNumber = int.TryParse(Console.ReadLine(), out int number);

				if (isNumber)
					return number;
				else
					Console.WriteLine("Nepravilan unos!");
			}
		}
	}
}
