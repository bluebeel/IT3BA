using System;
using Newtonsoft.Json;

namespace Bulletin
{
	public class Activity
	{
		private int ects;
		private string name;
		private string code;
		private string professeur;

		[JsonIgnore]
		private Teacher teacher;

		public Activity(int ects, string name, string code)
		{
			this.ects = ects;
			this.name = name;
			this.code = code;
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

		public string Professeur
		{
			get
			{
				return this.professeur;
			}
			set
			{
				this.professeur = value;
			}
		}

		[JsonIgnore]
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
