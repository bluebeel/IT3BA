using System;
using System.Reflection;


namespace Introspection
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Item beer = new Item("42X", "Leffe  des  vignes", 14.50);
			Type type = beer.GetType();
			Inspection test = new Inspection(type);
			test.String();

		}
	}
}
