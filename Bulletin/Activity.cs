using System;
namespace Bulletin
{
	public class Activity
	{
		private int ects;
		public string name;
		public string code;
		public Teacher teacher;

		public Activity(int ects, string name, string code, Teacher prof)
		{
			this.ects = ects;
			this.name = name;
			this.code = code;
			this.teacher = prof;
		}

		public int ECTS
		{
			get
			{
				return this.ects;
			}
			set
			{
				this.ects = value;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		public string Code
		{
			get
			{
				return this.code;
			}
			set
			{
				this.code = value;
			}
		}

		public Teacher Teacher
		{
			get
			{
				return this.teacher;
			}
			set
			{
				this.teacher = value;
			}
		}

	}
}
