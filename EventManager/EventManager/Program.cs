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
			Console.WriteLine("4 - Dodaj osobu na event");
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
						DeleteEvent(EventAndAttendants);
						break;
					case 3:
						UpdateEvent(EventAndAttendants);
						break;
					case 4:
						AddPerson(EventAndAttendants);
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
			var eventName = InputString("Unesite ime eventa: ");
			if (EventExists(EventAndAttendants, eventName))
			{
				Console.WriteLine("Već postoji event s danim imenom!");
				return;
			}

			newEvent.Name = eventName;
			newEvent.InputEventType();
			newEvent.InputStarTime();
			newEvent.InputEndTime();
			newEvent.EventId = (EventAndAttendants.Count + 1) * 10;

			var attendantsList = new List<Person>();
			EventAndAttendants.Add(newEvent, attendantsList);

			return;
		}

		static void DeleteEvent(Dictionary<Event, List<Person>> EventAndAttendants)
		{
			PrintEvents(EventAndAttendants);
			var eventId = InputNumber("Unesite ID eventa kojega želite obrisati: ");

			foreach (var item in EventAndAttendants)
			{
				
				if (item.Key.EventId == eventId) {
					if(ConfirmAction())
						EventAndAttendants.Remove(item.Key);
					return;
				}

			}

			Console.WriteLine("Ne postoji event s unesneim Id-om!");
			return;
		}

		static void UpdateEvent(Dictionary<Event, List<Person>> EventAndAttendants)
		{
			PrintEvents(EventAndAttendants);
			var eventId = InputNumber("Unesite ID eventa na kojega želite urediti: ");

			foreach (var item in EventAndAttendants)
			{
				if (item.Key.EventId == eventId)
				{
					Console.Clear();
					while (true)
					{
						PrintEventDetails(EventAndAttendants, eventId);
						Console.WriteLine("1 - Uredi ime eventa\n2 - Uredi Vrstu eventa\n3 - Uredi vrijeme početka\n4 - Uredi vrijeme kraja\n0 - natrag na glavni izbornik");
						Console.Write("Izbor: ");
						
						var input = "";

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
								var newName = InputString("Unesite novo ime eventa: ");
								Console.WriteLine("Jese li sigurni da zelite preimenovti event \"{0}\" u \"{1}\"", item.Key.Name, newName);
								if (ConfirmAction())
									item.Key.Name = newName;
								break;
							case 2:
								
								item.Key.InputEventType();
								break;
							case 3:
								item.Key.InputStarTime();
								break;
							case 4:
								item.Key.InputEndTime();
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
			}
		}

		static void AddPerson(Dictionary<Event, List<Person>> EventAndAttendants)
		{
			PrintEvents(EventAndAttendants);
			var eventId = InputNumber("Unesite ID eventa na koji želite dodati novu osobu: ");


			foreach (var item in EventAndAttendants)
			{
				if (item.Key.EventId == eventId)
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

		static void PrintEvents(Dictionary<Event, List<Person>> EventAndAttendants)
		{
			foreach (var item in EventAndAttendants)
				Console.WriteLine("{0, 8} {1, -32}", item.Key.EventId, item.Key.Name);

			return;
		}

		static void PrintEventDetails(Dictionary<Event, List<Person>> EventAndAttendants, int eventId)
		{
			foreach (var item in EventAndAttendants)
			{
				if (item.Key.EventId == eventId)
				{
					Console.WriteLine("{0, -32} {1, -16} {2, -32} {3, -32} {4, -32} {5, -8}", "Event", "Tip eventa", "Vrjijeme početka", "Vrijeme završetka", "Vrijeme trajanja", "Broj sudionika");
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
					Console.WriteLine("{0, -12} {1, -32} {2, -32} {3, -16}", "Redni broj", "Ime", "Prezime", "Broj mobitela");
					var i = 1;
					foreach (var person in item.Value)
					{
						Console.WriteLine("{0, -12} {1, -32} {2, -32} {3, -16}", i, person.FirstName, person.LastName, person.PhoneNumber);
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

		public static bool ConfirmAction()
		{
			Console.WriteLine("Jeste li sigurni da zelite nastaviti?\n\tDA - da želim nastaviti\n\tNE - ne zelim nastaviti (unesi bilo koju tipku za prekid)");
			Console.Write("Izbor: ");
			var input = Console.ReadLine();

			return input.Equals("da", StringComparison.OrdinalIgnoreCase);
		}

		public static string InputString(string message)
		{
			string input;
			while (true)
			{
				if (!string.IsNullOrEmpty(message))
					Console.Write(message);

				input = Console.ReadLine();
				input = input.Trim();

				if (!string.IsNullOrEmpty(input))
					break;
				else
					Console.WriteLine("Nije dozvoljeno unijeti prazan string!");
			}

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
