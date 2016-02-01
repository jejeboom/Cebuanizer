using System;
using System.Collections.Generic;

using Android.App;
using Android.Widget;
using Android.OS;

using SQLite;

namespace Cebuanizer
{
	[Activity(Label = "Cebuanizer", MainLauncher = true, Icon = "@drawable/logo2")]
	public class PhraseDatabase : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// create variables for our onscreen widgets

			var btnCreate = FindViewById<Button> (Resource.Id.btnCreate);
			var txtResult = FindViewById<TextView> (Resource.Id.txtResult);
			var mlstPhrases = FindViewById<ListView> (Resource.Id.llstPhrases);
			// create DB path
			var docsFolder = System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine (docsFolder, "db_sqlnet.db");

			// disable the single and list buttons until the database has been created

			// create events for buttons

			btnCreate.Click += delegate {
				var result = createDatabase (pathToDatabase);
				txtResult.Text = result + "\n";
				// if the database was created ok, then enable the list and single buttons
				var records = findNumberRecords(pathToDatabase);
				if(records == 0 ){
					var peopleList = new List<Phrases>
					{
						new Phrases { TagalogPhrase = "Magandang Hapon", CebuanoPhrase = "Maayong hapon.", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Magandang Araw", CebuanoPhrase = "Maayong adlaw sa imo.", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Magandang Gabi", CebuanoPhrase = "Maayong gabii.", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Goodluck", CebuanoPhrase = "Maayo unta swertihon!", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Magandang Umaga", CebuanoPhrase = "Maayong buntag.", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Hello, Kumusta ka?", CebuanoPhrase = "Uy, kumusta man ka?", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Hindi ko maintindihan.", CebuanoPhrase = "Wala ko kasabot.", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Naiintidihan ko.", CebuanoPhrase = "Nakasabot ko.", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Ayos lang ako.", CebuanoPhrase = "Maayo man ko.", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Matagal na panahong di nagkita.", CebuanoPhrase = "Dugayng panahon wala ta nagkita", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Ang pangalan ko ay Juan.", CebuanoPhrase = "Ang akong ngalan kay Juan.", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Maligayang Pagdating.", CebuanoPhrase = "Maayong pag-abot", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Anong pangalan mo?", CebuanoPhrase = "Unsa'y imong ngalan?", Cost = 0, Status = 0},
						new Phrases { TagalogPhrase = "Taga-saan ka?", CebuanoPhrase = "Taga-asa ka?", Cost = 0, Status = 0}
					};
					var results = insertUpdateAllData(peopleList, pathToDatabase);
					txtResult.Text += string.Format("{0}\nNumber of records = {1}\n", results, records);
				}


				StartActivity(typeof(actPhrase));

			};

			/*
			btnSingle.Click += delegate
			{
				
				var result = insertUpdateData(new Person{ FirstName = string.Format("John {0}", DateTime.Now.Ticks), LastName = "Smith" }, pathToDatabase);
				var records = findNumberRecords(pathToDatabase);
				txtResult.Text += string.Format("{0}\nNumber of records = {1}\n", result, records);

			};


			btnList.Click += delegate
			{
				var peopleList = new List<Phrases>
				{
					new Phrases { TagalogPhrase = "Magandang Hapon", CebuanoPhrase = "Maayong hapon.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Magandang Araw", CebuanoPhrase = "Maayong adlaw sa imo.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Magandang Gabi", CebuanoPhrase = "Maayong gabii.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Goodluck", CebuanoPhrase = "Maayo unta swertihon!", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Magandang Umaga", CebuanoPhrase = "Maayong buntag.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Hello, Kumusta ka?", CebuanoPhrase = "Uy, kumusta man ka?", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Hindi ko maintindihan.", CebuanoPhrase = "Wala ko kasabot.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Naiintidihan ko.", CebuanoPhrase = "Nakasabot ko.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Ayos lang ako.", CebuanoPhrase = "Maayo man ko.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Matagal na panahong di nagkita.", CebuanoPhrase = "Dugayng panahon wala ta nagkita", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Ang pangalan ko ay Juan.", CebuanoPhrase = "Ang akong ngalan kay Juan.", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Maligayang Pagdating.", CebuanoPhrase = "Maayong pag-abot", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Anong pangalan mo?", CebuanoPhrase = "Unsa'y imong ngalan?", Cost = 0, Status = 0},
					new Phrases { TagalogPhrase = "Taga-saan ka?", CebuanoPhrase = "Taga-asa ka?", Cost = 0, Status = 0}
				};
				var result = insertUpdateAllData(peopleList, pathToDatabase);
				var records = findNumberRecords(pathToDatabase);
				txtResult.Text += string.Format("{0}\nNumber of records = {1}\n", result, records);
			};*/
		}


		private string createDatabase(string path)
		{
			try
			{
				var connection = new SQLiteConnection(path);
				connection.CreateTable<Phrases>();
				return "Database created";
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}
		}

		private string insertUpdateData(Phrases data, string path)
		{
			try
			{
				var db = new SQLiteConnection(path);
				if (db.Insert(data) != 0)
					db.Update(data);
				return "Single data file inserted or updated";
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}
		}

		private string insertUpdateAllData(IEnumerable<Phrases> data, string path)
		{
			try
			{
				var db = new SQLiteConnection(path);
				if (db.InsertAll(data) != 0)
					db.UpdateAll(data);
				return "List of data inserted or updated";
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}
		}

		private int findNumberRecords(string path)
		{
			try
			{
				var db = new SQLiteConnection(path);
				// this counts all records in the database, it can be slow depending on the size of the database
				var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Phrases");

				// for a non-parameterless query
				// var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

				return count;
			}
			catch (SQLiteException)
			{
				return -1;
			}

		}
		private static bool isTableExisting(string strTblName){
			try{
				var docsFolder = System.Environment.GetFolderPath (System.Environment.SpecialFolder.MyDocuments);
				var pathToDatabase = System.IO.Path.Combine (docsFolder, "db_sqlnet.db");
				var connection = new SQLiteConnection(pathToDatabase);
				var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='" + strTblName + "'");
				if(count > 0){
					return true;
				}else{
					return false;
				}
			}catch(SQLiteException){
				return false;
			}
		}
	}
}


