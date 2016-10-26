using System;

namespace Reflexion
{
	public interface Computer
	{
		string Name
		{
			get;
		}

		double Compute (params double[] values);
	}
}
