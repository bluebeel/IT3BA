using System;
namespace Calculator
{
	public enum ACTION {
		Add,
		Mult,
		Div,
		Sub
	}

	/* The Receiver interface */
	public interface IReciever<T>
	{
		//  This interface contains the real operational logic that need to be performed on the data.
		void SetAction(ACTION action);
		T GetResult();
	}
}
