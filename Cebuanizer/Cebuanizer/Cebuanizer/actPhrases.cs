
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
using Android.Media;


using SQLite;

namespace Cebuanizer
{
	[Activity (Label = "actPhrase")]			
	public class actPhrases : Activity
	{

		private ListView mlstPhrases;
		private List<PhraseModel> mlistPhrases = new List<PhraseModel> ();


		protected override void OnCreate (Bundle savedInstanceState)
		{
			TextView tv1 = FindViewById<TextView> (Resource.Id.textView1);
			MediaPlayer mp1 = MediaPlayer.Create (this, Resource.Raw.Good_Afternoon);
			MediaPlayer mp2 = MediaPlayer.Create (this, Resource.Raw.Good_Day);
			MediaPlayer mp3 = MediaPlayer.Create (this, Resource.Raw.Good_Evening);
			MediaPlayer mp4 = MediaPlayer.Create (this, Resource.Raw.Good_Luck);
			MediaPlayer mp5 = MediaPlayer.Create (this, Resource.Raw.Good_Morning);
			MediaPlayer mp6 = MediaPlayer.Create (this, Resource.Raw.Hello);
			MediaPlayer mp7 = MediaPlayer.Create (this, Resource.Raw.I_dont);
			MediaPlayer mp8 = MediaPlayer.Create (this, Resource.Raw.understand);
			MediaPlayer mp9 = MediaPlayer.Create (this, Resource.Raw.Im_Okay);
			MediaPlayer mp10 = MediaPlayer.Create (this, Resource.Raw.No_See);
			MediaPlayer mp11 = MediaPlayer.Create (this, Resource.Raw.My_Name);
			MediaPlayer mp12 = MediaPlayer.Create (this, Resource.Raw.Welcome);
			MediaPlayer mp13 = MediaPlayer.Create (this, Resource.Raw.Name);
			MediaPlayer mp14 = MediaPlayer.Create (this, Resource.Raw.Where);
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Phrases);
			mlstPhrases = FindViewById<ListView> (Resource.Id.llstPhrases);
			var docsFolder = System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine (docsFolder, "db_sqlnet.db");

			try
			{
				var db = new SQLiteConnection(pathToDatabase);

				var phrases = db.Table<Phrases>();
				foreach(var p in phrases){
					mlistPhrases.Add(new PhraseModel { strPCeb = p.CebuanoPhrase, strPTag = p.TagalogPhrase });
				}
				mlstPhrases.Adapter = new PhraseAdapter (this, mlistPhrases);
			}
			catch (SQLiteException ex)
			{
				string m =  ex.Message ;
			}

			PhraseAdapter adapter = new PhraseAdapter (this, mlistPhrases);
			mlstPhrases.Adapter = adapter;
			mlstPhrases.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {

				string item = e.Position.ToString();
				if(item == "0") {
					mp1.Start();
				}
				else if(item == "1") {
					mp2.Start();
				}
				else if(item == "2") {
					mp3.Start();
				}
				else if(item == "3") {
					mp4.Start();
				}
				else if(item == "4") {
					mp5.Start();
				}
				else if(item == "5") {
					mp6.Start();
				}
				else if(item == "6") {
					mp7.Start();
				}
				else if(item == "7") {
					mp8.Start();
				}
				else if(item == "8") {
					mp9.Start();
				}
				else if(item == "9") {
					mp10.Start();
				}
				else if(item == "10") {
					mp11.Start();
				}
				else if(item == "11") {
					mp12.Start();
				}
				else if(item == "12") {
					mp13.Start();
				}
				else if(item == "13") {
					mp14.Start();
				}

			};
			//mimgHome.Click += (object sender, EventArgs e) => StartActivity(typeof(actMenu));
			//mlstPhrases.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => mpPhrase.Start();
		}
	}
}

