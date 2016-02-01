using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;

namespace Cebuanizer
{
	public class Dictionary
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string TagalogWord { get; set; }

		public string CebuanoWord { get; set; }

		public int Cost { get; set; }

		public int Status { get; set; }

		public override string ToString()
		{
			return string.Format("[Dictionary: ID={0}, TagalogWord={1}, CebuanoWord]={2},Cost={3}, Status={4}]", ID, TagalogWord, CebuanoWord, Cost, Status);
		}
	}
}