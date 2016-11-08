using System;
namespace Calculator
{
	public class InvalidArgumentException : Exception
	{
		private string args;
		private string expected;

		public InvalidArgumentException(string args, string expected) : base()
		{
			this.args = args;
			this.expected = expected;
		}

		public override string ToString()
		{
			return "This command expected the following arguments: \"" + this.expected + "\"\nbut got: \"" + this.args + "\"";
		}
	}
}
