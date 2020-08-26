using System;

namespace MockPractice.Challenge
{
	public class ConsoleLogger
	{
		public void PrintNextWeekday(DayOfWeek day)
		{
			var nextWeekDay = DateTime.Now.AddDays(1);

			while (nextWeekDay.DayOfWeek != day)
			{
				nextWeekDay = nextWeekDay.AddDays(1);
			}

			Console.WriteLine(nextWeekDay);
		}
	}
}
