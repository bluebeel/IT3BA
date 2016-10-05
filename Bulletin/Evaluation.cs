using System;
namespace Bulletin
{
	public abstract class Evaluation
	{
		protected Activity activity;

		protected Evaluation() { }

		public Evaluation(Activity activite)
		{
			this.activity = activite;
		}

		public abstract int Note();

	}

	public class Grade : Evaluation
	{
		public int note;
		public Grade(Activity activity, int cote) : base(activity)
		{
			if (cote < 0)
			{
				this.note = 0;
			}
			else
			{
				this.note = cote;
			}
		}

		public void setNote(int cote)
		{
			if (cote < 0)
			{
				this.note = 0;
			}
			else
			{
				this.note = cote;
			}
		}

		public override int Note()
		{
			return this.note;
		}
	}

	public class Appreciation : Evaluation
	{
		public string appreciation;
		public Appreciation(Activity activity, string cote) : base(activity)
		{
			this.appreciation = cote;
		}

		public void setAppreciation(string cote)
		{
			this.appreciation = cote;
		}

		public override int Note()
		{
			switch (this.appreciation)
			{
				case "N":
					return 20;
				case "C":
					return 16;
				case "B":
					return 12;
				case "TB":
					return 8;
				case "X":
					return 4;
				default:
					return 0;
			}
		}
	}
	public class Bulletin
	{
		public string type;
		public string code;
		public string eleve;
		public string note;

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
		public string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}
		public string Eleve
		{
			get
			{
				return this.eleve;
			}
			set
			{
				this.eleve = value;
			}
		}
		public string Note
		{
			get
			{
				return this.note;
			}
			set
			{
				this.note = value;
			}
		}
	}

}
