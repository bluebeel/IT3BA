using System;
namespace Calculator
{
	public class MultCommand : Command<double>
	{
		protected IReciever<double> reciever;
		public MultCommand(IReciever<double> recv)
		{
			reciever = recv;
		}

		public override double Execute()
		{
			reciever.SetAction(ACTION.Mult);
			return reciever.GetResult();
		}
	}
}
