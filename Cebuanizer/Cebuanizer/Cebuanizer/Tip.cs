using System;
using SQLite;

namespace Cebuanizer
{
	public class Tip
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string TipPhrase { get; set; }

		public override string ToString()
		{
			return string.Format("[Tip: ID={0}, TipPhrase={1}]", ID, TipPhrase);
		}
	}
}

