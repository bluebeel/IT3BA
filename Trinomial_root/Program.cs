using System;

namespace Trinomial_root
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Recherche  des  racines  de ax^2 + bx + c");
			double a;
			do
			{
				Console.WriteLine("Coefficient a :");
			}
			while (!(double.TryParse(Console.ReadLine(), out a)));
			double b;
			do
			{
				Console.WriteLine("Coefficient b :");
			}
			while (!(double.TryParse(Console.ReadLine(), out b)));
			double c;
			do
			{
				Console.WriteLine("Coefficient c :");
			}
			while (!(double.TryParse(Console.ReadLine(), out c)));

			double delta = Math.Pow(b, 2) - 4 * a * c;
			Console.WriteLine("Discriminant: " + delta);
			double x;
			double x1;
			double x2;

			if (delta < 0)
			{
				Console.WriteLine("Pas de racine réelle");
			}
			else if (Math.Abs(delta - 0) < 0.00001)
			{
				x = -b / (2 * a);
				Console.WriteLine("Une  racine  réelle  double : " + x);
			}
			else
			{
				x1 = (-b - Math.Sqrt(delta)) / (2 * a);
				x2 = (-b + Math.Sqrt(delta)) / (2 * a);
				Console.WriteLine("Une  racine  réelle  double : " + x1 + "et" + x2);
			}
		}
	}
}
