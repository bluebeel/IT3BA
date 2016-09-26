using System;
namespace Cours
{
	public class trinomial_root
	{
		public trinomial_root()
		{
			Console.WriteLine("Recherche  des  racines  de ax^2 + bx + c");
			Console.WriteLine("Coefficient a :");
			string aStr = Console.ReadLine();
			double a = double.Parse(aStr);
			Console.WriteLine("Coefficient b :");
			string bStr = Console.ReadLine();
			double b = double.Parse(bStr);
			Console.WriteLine("Coefficient c :");
			string cStr = Console.ReadLine();
			double c = double.Parse(cStr);
		}
	}
}
