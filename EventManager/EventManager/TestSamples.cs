using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager
{
	class TestSamples
	{
		// Test values

		public static Dictionary<Event, List<Person>> GetTestSamples()
		{
			var EventAndAttendatns = new Dictionary<Event, List<Person>>();

			DateTime DT1 = new DateTime(2020, 12, 6);DT1 = DT1.AddHours(17);
			DateTime DT2 = new DateTime(2020, 12, 5); DT2 = DT2.AddHours(12); DT2.AddMinutes(25);
			DateTime DT3 = new DateTime(2021, 6, 7); DT3 = DT3.AddHours(17);
			DateTime DT4 = new DateTime(2020, 12, 5); DT4 =  DT4.AddHours(12);

			var E1 = new Event("DUMP - predavanje", "Lecture", DT1, DT1.AddHours(3), 001);
			var E2 = new Event("Kava", "Coffee", DT2, DT2.AddHours(3), 002);
			var E3 = new Event("Koncert Iron Maidena", "Concert", DT3, DT3.AddHours(5), 003);
			var E4 = new Event("naucit c#", "Study Session", DT4, DT4.AddHours(10), 004);

			var P1 = new Person("Ante", "Antic", "11111111", "000 000 001");
			var P2 = new Person("Jure", "Juric", "22222222", "000 000 002");
			var P3 = new Person("Ana", "Anic", "33333333", "000 000 003");
			var P4 = new Person("Marko", "Markic", "44444444", "000 000 004");

			var L1 = new List<Person>();
			var L2 = new List<Person>();
			var L3 = new List<Person>();
			var L4 = new List<Person>();

			L1.Add(P1); 
			L2.Add(P1); L2.Add(P2);
			L3.Add(P1); L3.Add(P2); L3.Add(P3);
			L4.Add(P1); L4.Add(P2); L4.Add(P3); L4.Add(P4);

			EventAndAttendatns.Add(E1, L1);
			EventAndAttendatns.Add(E2, L2);
			EventAndAttendatns.Add(E3, L3);
			EventAndAttendatns.Add(E4, L4);

			return EventAndAttendatns;
		}



	}
}
