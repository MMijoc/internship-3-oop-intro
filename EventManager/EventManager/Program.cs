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
			PrintMainMenu();
			Console.ReadLine();
			Console.Clear();
			PrintSubmenu();

			



		}


		static void SelectMenu()
		{
			var EventAndAttendatns = new Dictionary<Event, List<Person>>();

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


		static int AddEvent(Dictionary<Event, List<Person>> EventAndAttendatns)
		{
			return (int)ReturnStatus.Success;
		}









	}
}
