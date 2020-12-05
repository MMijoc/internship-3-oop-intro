using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager
{
	enum EventType
	{
		Coffee,
		Lecture,
		Concert,
		StudySession
	}
	public class Event
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public int EventId { get; set; }
		public Event()
		{

		}
		public Event(string name, string type, DateTime startTime, DateTime endTime, int id)
		{
			Name = name;
			Type = type;
			StartTime = startTime;
			EndTime = endTime;
			EventId = id;
		}

		public void InputEventType()
		{
			int eventTypeNumber;

			Console.WriteLine("Unesi vrstu eventa\n\t0 - Coffee\n\t1 - Lecture\n\t2 - Concert\n\t3 - StudySession");
			while (true) {
				Console.Write("Izbor: ");
				bool isNumber = int.TryParse(Console.ReadLine(), out eventTypeNumber);

				if (isNumber && eventTypeNumber >= 0 && eventTypeNumber <= 3)
					break;
				else
					Console.WriteLine("Nepravilan unos!");
			}

			switch (eventTypeNumber)
			{
				case (int)EventType.Coffee:
					Type = "Coffee";
					break;
				case (int)EventType.Lecture:
					Type = "Lecture";
					break;
				case (int)EventType.Concert:
					Type = "Concert";
					break;
				case (int)EventType.StudySession:
					Type = "StudySession";
					break;
				default:
					Console.WriteLine("Nepravilan unos!");
					break;
			}

			return;
		}

		public void InputStarTime()
		{
			DateTime userDateTime;

			Console.Clear();
			while (true)
			{
				Console.WriteLine("Unesite datum i vrijeme početka\n\t(unijeti u formatu: dan mjesec godina sati:minute)");
				Console.Write("Unos: ");

				if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
				{
					Console.WriteLine("Unijeli ste datum {0} {1}, potvrdite unos", userDateTime.ToShortDateString(), userDateTime.ToShortTimeString());
					if (Program.ConfirmAction())
						break;
					
				}
				else
				{
					Console.WriteLine("Nepravilan unos!");
				}
			}

			StartTime = userDateTime;
		}

		public void InputEndTime()
		{
			DateTime userDateTime;

			Console.Clear();
			while (true)
			{
				Console.WriteLine("Unesite datum i vrijeme kraja\n\t(unijeti u formatu: dan mjesec godina sati:minute)");
				Console.Write("Unos: ");

				if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
				{
					if (EndTime < userDateTime) {
						Console.WriteLine("Vrijeme kraja ne može biti prije vremena početka!");
						continue;
					}

					Console.WriteLine("Unijeli ste datum {0} {1}, potvrdite unos", userDateTime.ToShortDateString(), userDateTime.ToShortTimeString());
					if (Program.ConfirmAction())
						break;

				}
				else
				{
					Console.WriteLine("Nepravilan unos!");
				}
			}

			EndTime = userDateTime;
		}

		public void PrintDetails()
		{
			Console.Write("\n{0, -40} {1, -16} {2, -32} {3, -32}",Name, Type, StartTime, EndTime);
		}



	}

}