using System;
using SQLite;

namespace Cebuanizer
{
	public class Coins
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public int CoinsCount { get; set; }

		public override string ToString()
		{
			return string.Format("[Coins: ID={0}, CoinsCount={1}]", ID, CoinsCount);
		}
	}
}

