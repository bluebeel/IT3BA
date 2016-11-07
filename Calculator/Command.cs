using System;
namespace Calculator
{
	public abstract class Command<T>
	{
		/*
		Command decouples the object that invokes the operation from the one that knows how to perform it. 
		To achieve this separation, we creates an abstract base class that maps a receiver (an object) with an action (a pointer to a member function). 
		The base class contains an execute() method that simply calls the action on the receiver.
		*/
		public abstract T Execute();
	}
}
