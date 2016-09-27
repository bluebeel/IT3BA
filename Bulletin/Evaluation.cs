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

	public class Note
	{
		public string code;
		public int score;

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
		public int Score
		{
			get
			{
				return this.score;
			}
			set
			{
				this.score = value;
			}
		}
	}

}
