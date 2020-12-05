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
			Console.WriteLine("0 - natrag");

			return;
		}

		static void SelectMenu()
		{
			var EventAndAttendatns = new Dictionary<Event, List<Person>>();

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
						AddEvent(EventAndAttendatns);
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
						Console.Clear();
						PrintSubmenu();
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

			static int AddEvent(Dictionary<Event, List<Person>> EventAndAttendatns)
			{
				var newEvent = new Event();
				Console.Write("Unesite ime novog eventa: ");
				////provjerit je li event s imenom vec postoji
				var name = Console.ReadLine();
				newEvent.Name = name;
				newEvent.InputEventType();
				newEvent.InputStarTime();
				newEvent.InputEndTime();

				//var attendantsList = new List<Person>();


				//EventAndAttendatns.Add(newEvent, attendantsList);







				return (int)ReturnStatus.Success;
			}







		}

		public static bool ConfirmAction()
		{
			Console.WriteLine("Jeste li sigurni da zelite nastaviti?\n\tDA - da želim nastaviti\n\tNE - ne zelim nastaviti (unesi bilo koju tipku za prekid)");
			Console.Write("Izbor: ");
			var input = Console.ReadLine();

			return input.Equals("da", StringComparison.OrdinalIgnoreCase);
		}









	}
}
