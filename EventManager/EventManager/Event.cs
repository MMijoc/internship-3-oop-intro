using System;
using System.Collections.Generic;
using System.Text;

//		Name, EventType, StartTime i EndTime.
namespace EventManager
{
	enum EventType
	{
		Coffee,
		Lecture,
		Concert,
		StudySession
	}
	class Event
	{
		public string Name { get; set; }
		public int EventType { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime DateTime { get; set; }

	}
}
