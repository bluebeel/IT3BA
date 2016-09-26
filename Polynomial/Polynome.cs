using System;

namespace Polynomial
{
	public class Polynome
	{

		public double[] Tab;
		public int Degree
		{
			get
			{
				return Tab.Length - 1;
			}
		}
		public Polynome(double[] tab)
		{
			Tab = tab;
		}
		public override string ToString()
		{
			string str = String.Format("{0}x^{1} ", Tab[0], Tab.Length - 1);
			for (int i = 1; i < Tab.Length; i++)
			{
				str += String.Format("+ {0}x^{1} ", Tab[i], Tab.Length - i - 1);
			}
			return str;
		}
		public double Evaluate(double num)
		{
			double str = 0;
			for (int i = 0; i < Tab.Length; i++)
			{
				str += Tab[i] * Math.Pow(num, Tab.Length - i - 1);
			}
			return str;
		}

	}
}