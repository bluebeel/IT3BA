using System;


namespace Polynomial
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Polynome p = new Polynome(new double[] { 1, 0, -2});
			Polynome q = new Polynome(new double[] { 1, 0, -2 });
			Console.WriteLine(p.Degree);
			Console.WriteLine(p);
			Console.WriteLine(p.Evaluate(2));
			Console.WriteLine(p == q);
			Console.WriteLine(p.Equals(q));

		}
	}
}
