using System;
namespace Calculator
{
	public class SubCommand : Command<double>
	{
		/*
		 Extends the Command abstract class, implementing the Execute method by invoking the corresponding operations on Receiver. 
		 It defines a link between the Receiver and the action.
		 A Command class holds some subset of the following: 
		 an object, a method to be applied to the object, and the arguments to be passed when the method is applied. 
		 The Command's "execute" method then causes the pieces to come together.
		 
		 */
		protected IReciever<double> reciever;
		public SubCommand(IReciever<double> recv)
		{
			reciever = recv;
		}

		public override double Execute()
		{
			reciever.SetAction(ACTION.Sub);
			return reciever.GetResult();
		}
	}
}
