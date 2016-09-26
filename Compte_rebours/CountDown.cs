using System;
using System.Timers;

namespace Compte_rebours
{
	
	public class CountDown
	{
		public int Sec;
		private int elapsed;
		public int RemainingTime
		{
			get
			{
				return Sec - elapsed;
			}
		}
		private static Timer aTimer;
		public CountDown(int sec)
		{
			Sec = sec;
			aTimer = new Timer(1000);
			aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		}
		public void Start()
		{
			aTimer.Enabled = true;
		}
		public void Stop()
		{
			aTimer.Enabled = false;
		}
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			if (Sec - elapsed > 0)
				elapsed++;
			else
				aTimer.Enabled = false;
		}

	}
}
