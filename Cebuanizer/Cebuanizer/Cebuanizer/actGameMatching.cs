using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cebuanizer
{
	[Activity (Label = "actGameMatching")]
	public class actGameMatching : Activity
	{
		string[] tagalog = {"Siya", "Ako", "Ikaw", "Babae", "Lalaki" };
		string[] cebuano = {"Siya", "Ako", "Ikaw", "Babaye", "Lalaki" };
		int i = 0;
		int x = 0;

		private ImageView mimgHome;
		private ImageView mimgCoin;
		private TextView mtxtCoins;

		protected override void OnCreate (Bundle savedInstanceState)
		{ 
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.GameMatching);

			// Get our button from the layout resource,
			// and attach an event 
			TextView tv = FindViewById<TextView>(Resource.Id.textView1);
			Button btn1 = FindViewById<Button> (Resource.Id.button1);
			Button btn2 = FindViewById<Button> (Resource.Id.button2);
			Button btn3 = FindViewById<Button> (Resource.Id.button3);
			Button btn4 = FindViewById<Button> (Resource.Id.button4);
			Button btn5 = FindViewById<Button> (Resource.Id.button5);

			mimgHome = FindViewById<ImageView> (Resource.Id.limgGMHome);
			mimgHome.SetImageResource (Resource.Drawable.home);
			mimgCoin = FindViewById<ImageView> (Resource.Id.limgGMCoin);
			mimgCoin.SetImageResource (Resource.Drawable.coin_small);
			mtxtCoins = FindViewById<TextView> (Resource.Id.ltxtMCoin);
			mtxtCoins.Text = Convert.ToString(Database.getCoins ());

			tv.Text = tagalog[i];
			btn1.Text = cebuano[2];
			btn2.Text = cebuano[1];
			btn3.Text = cebuano[0];
			btn4.Text = cebuano[3];
			btn5.Text = cebuano[4];
			btn1.Click += delegate
			{
				if(i == 4){
					StartActivity(typeof(actGameTranslation));
				}
				x = 2;
				if (x == i)
				{
					Database.addCoins(10);
					mtxtCoins.Text = Convert.ToString(Database.getCoins());
					if (i < 4)
					{
						i++;
					}
					btn1.Visibility = ViewStates.Invisible;
				}
				tv.Text = tagalog[i];
			};
			btn2.Click += delegate
			{
				if(i == 4){
					StartActivity(typeof(actGameTranslation));
				}
				x = 1;
				if (x == i)
				{
					Database.addCoins(10);
					mtxtCoins.Text = Convert.ToString(Database.getCoins());
					if (i < 4)
					{
						i++;
					}
					btn2.Visibility = ViewStates.Invisible;
				}
				tv.Text = tagalog[i];
			};

			btn3.Click += delegate
			{
				if(i == 4){
					StartActivity(typeof(actGameTranslation));
				}
				x = 0;

				if (x == i)
				{
					Database.addCoins(10);
					mtxtCoins.Text = Convert.ToString(Database.getCoins());
					if (i < 4)
					{
						i++;
					}
					btn3.Visibility = ViewStates.Invisible;
				}
				tv.Text = tagalog[i];

			};

			btn4.Click += delegate
			{
				if(i == 4){
					StartActivity(typeof(actGameTranslation));
				}
				x = 3;
				if (x == i)
				{
					Database.addCoins(10);
					mtxtCoins.Text = Convert.ToString(Database.getCoins());
					if (i < 4)
					{
						i++;
					}
					btn4.Visibility = ViewStates.Invisible;
				}
				tv.Text = tagalog[i];

			};

			btn5.Click += delegate
			{
				if(i == 4){
					StartActivity(typeof(actGameTranslation));
				}
				x = 4;
				if (x == i)
				{
					Database.addCoins(10);
					mtxtCoins.Text = Convert.ToString(Database.getCoins());
					if (i < 4)
					{
						i++;
					}
					btn5.Visibility = ViewStates.Invisible;
				}
				tv.Text = tagalog[i];

			};

			mimgHome.Click += delegate {
				StartActivity(typeof(actMenu));
			};
		}
	}
}


