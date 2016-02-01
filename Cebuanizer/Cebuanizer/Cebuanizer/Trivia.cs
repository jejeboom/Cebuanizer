using System;
using SQLite;

namespace Cebuanizer
{
	public class Trivia
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string TrivPhrase { get; set; }

		public override string ToString()
		{
			return string.Format("[Trivia: ID={0}, TrivPhrase={1}]", ID, TrivPhrase);
		}
	}
}

