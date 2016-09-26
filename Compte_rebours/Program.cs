using System;
using System.Timers;

namespace Compte_rebours
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			CountDown test = new CountDown(600);
			test.Start();
			Console.WriteLine(test.RemainingTime);

			System.Threading.Thread.Sleep(5000);
			Console.WriteLine(test.RemainingTime);
		}

	}
}
