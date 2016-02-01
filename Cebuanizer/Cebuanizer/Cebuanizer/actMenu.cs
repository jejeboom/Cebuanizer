
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
using Android.Content.PM;
using Android.Media;
using SQLite;
using Mono.Data.Sqlite;

namespace Cebuanizer
{
	[Activity (Label = "actMenu",  ScreenOrientation = ScreenOrientation.Portrait)]			
	public class actMenu : Activity
	{
		private ImageView mimgSlogan;
		private MediaPlayer mpButtonTap;
		private Button mbtnPlay;
		private Button mbtnDictionary;
		private Button mbtnPhrases;
		private Button mbtnAchievements;
		private TextView mtxtTip;
		private ImageView mimgCoin;
		private TextView mtxtCoin;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Menu);

			mpButtonTap = MediaPlayer.Create (this, Resource.Raw.buttontap);

			mimgSlogan = FindViewById<ImageView> (Resource.Id.limgMenuSlogan);
			mimgSlogan.SetImageResource (Resource.Drawable.slogan);
			mimgCoin = FindViewById<ImageView> (Resource.Id.limgCoinIcon);
			mimgCoin.SetImageResource (Resource.Drawable.coin_small);

			mbtnPlay = FindViewById<Button> (Resource.Id.lbtnPlay);
			mbtnPhrases = FindViewById<Button> (Resource.Id.lbtnPhrases);
			mbtnDictionary = FindViewById<Button> (Resource.Id.lbtnDictionary);
			mbtnAchievements = FindViewById<Button> (Resource.Id.lbtnAchievements);
			mtxtTip = FindViewById<TextView> (Resource.Id.ltxtTip);
			mtxtCoin = FindViewById<TextView> (Resource.Id.ltxtCoin);

			Database.createDatabase ("Tip");
			Database.createDatabase("Coins");
			Database.createDatabase ("Dictionary");
			Database.createDatabase ("Phrases");

			mtxtCoin.Text = Convert.ToString(Database.getCoins ());
			mtxtTip.Text = Database.getRandomTip();  

			mbtnPlay.Click += (object sender, EventArgs e) => {
				mpButtonTap.Start ();
				StartActivity(typeof(actGame));
			};
			mbtnPhrases.Click += (object sender, EventArgs e) => {
				mpButtonTap.Start ();
				StartActivity(typeof(actPhrases));
			};
			mbtnDictionary.Click += (object sender, EventArgs e) => {
				mpButtonTap.Start ();
				StartActivity(typeof(actDictionary));
			};
			mbtnAchievements.Click += (object sender, EventArgs e) => {
				mpButtonTap.Start ();
			};
		}
	}
}

