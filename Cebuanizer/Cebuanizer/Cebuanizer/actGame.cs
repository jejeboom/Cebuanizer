
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

namespace Cebuanizer
{
	[Activity (Label = "actGame")]			
	public class actGame : Activity
	{

		private ImageView mimgHome;
		private ImageView mimgCoin;
		private TextView mtxtCoin;
		private Button mbtnOne;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Game);

			mimgHome = FindViewById<ImageView> (Resource.Id.limgGHome);
			mimgCoin = FindViewById<ImageView> (Resource.Id.limgGCoin);
			mbtnOne = FindViewById<Button> (Resource.Id.lbtnGOne);

			mimgHome.SetImageResource (Resource.Drawable.home);
			mimgCoin.SetImageResource (Resource.Drawable.coin_small);

			mtxtCoin = FindViewById<TextView> (Resource.Id.ltxtGCoin);
			mtxtCoin.Text = Convert.ToString(Database.getCoins ());

			mimgHome.Click += (object sender, EventArgs e) => {
				StartActivity(typeof(actMenu));
			};

			mbtnOne.Click += (object sender, EventArgs e) => {
				StartActivity(typeof(actGameFill2));
			};
		}
	}
}

