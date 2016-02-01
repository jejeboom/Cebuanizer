
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;
using Mono.Data.Sqlite;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
//using Android.Support.V7.App;
//using Android.Support.V4.View;

namespace Cebuanizer
{
	[Activity (Label = "actDictionary", NoHistory = true)]	
	public class actDictionary : Activity
	{
		private static string path = System.IO.Path.Combine((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)), "db_sqlnet.db");
		private ImageView mimgHome;		
		private ListView mlstWords;
		private List<DictWordModel> mlistWords = new List<DictWordModel>();
		private MediaPlayer mpWord;
		//private SearchView srch;
		private ArrayAdapter adapters;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Dictionary);

			mimgHome = FindViewById<ImageView>(Resource.Id.limgHome);
			mlstWords = FindViewById<ListView>(Resource.Id.llstWords);
			mpWord = MediaPlayer.Create(this, Resource.Raw.cebuano_woman);
			mimgHome.SetImageResource(Resource.Drawable.home);
			//srch = FindViewById<SearchView>(Resource.Id.search);

			try
			{
				var db = new SQLiteConnection(path);

				var words = db.Table<Dictionary>();
				foreach (var w in words)
				{
					mlistWords.Add(new DictWordModel { strCeb = w.CebuanoWord, strTag = w.TagalogWord });
				}
				mlstWords.Adapter = new DictWordAdapter(this, mlistWords);
				adapters = new ArrayAdapter<DictWordModel>(this, Android.Resource.Layout.SimpleListItem1, mlistWords);
			}
			catch (SQLiteException ex)
			{
				string m = ex.Message;
			}

			//lstWords.Adapter = new DictWordAdapter (this, mlistWords);
			mimgHome.Click += (object sender, EventArgs e) => StartActivity(typeof(actMenu));
			//mlstWords.ItemClick += (object sender, AdapterView .ItemClickEventArgs e) => mpWord.Start();
		}

		/*   public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu, menu);

            var item = menu.FindItem(Resource.Id.search);

            var searchView = MenuItemCompat.GetActionView(item);

            srch = searchView.JavaCast<SearchView>();

            srch.QueryTextChange += (s, e) => adapters.Filter.InvokeFilter(e.NewText);

            srch.QueryTextSubmit += (s, e) =>
                {
                    Toast.MakeText(this, "Searched for: " + e.Query, ToastLength.Short).Show();
                    e.Handled = true;
                };

            return true;
        }
        */
	}
}

