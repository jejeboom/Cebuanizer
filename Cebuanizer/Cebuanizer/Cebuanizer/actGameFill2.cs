
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
	[Activity (Label = "actGameFill2")]			
	public class actGameFill2 : Activity
	{

		private ImageView mimgHome;
		private ImageView mimgCoin;
		private TextView mtxtSentence;
		private TextView mtxtCoins;
		private EditText mtxtInput;
		private Button mbtnSubmit;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			int intCtr = 0;
			string[,] sentence = {
				{"Si Juan ay LALAKI", "lalaki"},
				{"Si Sheila ay BABAE", "babaye"},
				{"Si Sheila ay BABAYE", "babae"}
			};

			// Create your application here

			SetContentView (Resource.Layout.GameFill2);

			mimgHome = FindViewById<ImageView> (Resource.Id.limgFHome);
			mimgHome.SetImageResource (Resource.Drawable.home);
			mimgCoin = FindViewById<ImageView> (Resource.Id.limgFCoin);
			mimgCoin.SetImageResource (Resource.Drawable.coin_small);
			mtxtSentence = FindViewById<TextView> (Resource.Id.ltxtFSentence);
			mtxtInput = FindViewById<EditText> (Resource.Id.ltxtFInput);
			mbtnSubmit = FindViewById<Button> (Resource.Id.lbtnFSubmit);
			mtxtCoins = FindViewById<TextView> (Resource.Id.ltxtFCoin);
			mtxtCoins.Text = Convert.ToString(Database.getCoins ());
			//0
			mtxtSentence.Text = sentence [0, 0];

			mbtnSubmit.Click += (object sender, EventArgs e) => {
				if(intCtr <= 1){
					if(mtxtInput.Text == sentence[intCtr, 1]){
						intCtr++;
						mtxtSentence.Text = sentence [intCtr, 0];
						mtxtInput.Text = "";
						Database.addCoins(10);
						mtxtCoins.Text = Convert.ToString(Database.getCoins());
					}
				}else{
					if(mtxtInput.Text == sentence[2, 1]){
						Database.addCoins(10);
						mtxtCoins.Text = Convert.ToString(Database.getCoins());
						StartActivity(typeof(actGameMatching));
					}
					mtxtInput.Text = "";
				}
			};
		}
	}
}

