using SQLite;

namespace Cebuanizer
{
	public class Phrases
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string TagalogPhrase { get; set; }

		public string CebuanoPhrase { get; set; }

		public int Cost { get; set; }

		public int Status { get; set; }

		public override string ToString()
		{
			return string.Format("[Phrases: ID={0}, TagalogPhrase={1}, CebuanoPhrase={2},Cost={3}, Status={4}]", ID, TagalogPhrase, CebuanoPhrase, Cost, Status);
		}
	}
}


