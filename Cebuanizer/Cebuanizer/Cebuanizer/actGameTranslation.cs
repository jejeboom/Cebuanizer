
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
	[Activity (Label = "actGameTranslation")]			
	public class actGameTranslation : Activity
	{
		private EditText mtxtbAnswer;
		private TextView mtxtSentence;
		private Button mbtnOk;
		private TextView mtxtWord1;
		private TextView mtxtWord2;
		private TextView mtxtWord3;
		private ImageView mimgHome;
		private ImageView mimgCoin;
		private TextView mtxtCoins;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here

			SetContentView (Resource.Layout.GameTranslation);

			mtxtbAnswer = FindViewById<EditText> (Resource.Id.ltxtbTAnswer);
			mtxtSentence = FindViewById<TextView> (Resource.Id.ltxtTSentence);
			mtxtWord1 = FindViewById<TextView> (Resource.Id.ltxtTWord1);
			mtxtWord2 = FindViewById<TextView> (Resource.Id.ltxtTWord2);
			mtxtWord3 = FindViewById<TextView> (Resource.Id.ltxtTWord3);
			mbtnOk = FindViewById<Button> (Resource.Id.lbtnTOk);
			mimgHome = FindViewById<ImageView> (Resource.Id.limgGTHome);
			mimgHome.SetImageResource (Resource.Drawable.home);
			mimgCoin = FindViewById<ImageView> (Resource.Id.limgGTCoin);
			mimgCoin.SetImageResource (Resource.Drawable.coin_small);
			mtxtCoins = FindViewById<TextView> (Resource.Id.ltxtGTCoin);
			mtxtCoins.Text = Convert.ToString(Database.getCoins ());
			int intCtr = 0;

			string[,] sentence = { 
				{"AKO AY LALAKI", "AKO AY LALAKI", "LALAKI", "AY", "AKO"},
				{"AKO AY BABAYE", "AKO AY BABAE", "AY", "AKO", "BABAE"},
				{"AKO AY BABAE", "AKO AY BABAYE", "AKO", "BABAYE", "AY"},
				{"IKAW AY LALAKI", "IKAW AY LALAKI", "LALAKI", "AY", "IKAW"},
				{"IKAW AY BABAYE", "IKAW AY BABAE", "AY", "IKAW", "BABAE"},
				{"IKAW AY BABAE", "IKAW AY BABAYE", "IKAW", "BABAYE", "AY"},
				{"SIYA AY LALAKI", "SIYA AY LALAKI", "LALAKI", "AY", "SIYA"},
				{"SIYA AY BABAYE", "SIYA AY BABAE", "AY", "SIYA", "BABAE"},
				{"SIYA AY BABAE", "SIYA AY BABAYE", "SIYA", "BABAYE", "AY"}
			};
			mtxtSentence.Text = sentence[intCtr, 0];
			mtxtWord1.Text = sentence[intCtr, 2];
			mtxtWord2.Text = sentence[intCtr, 3];
			mtxtWord3.Text = sentence[intCtr, 4];

			mtxtWord1.Click += (object sender, EventArgs e) => {
				if(string.IsNullOrEmpty(mtxtbAnswer.Text)){
					mtxtbAnswer.Text = mtxtWord1.Text;
				}else{
					mtxtbAnswer.Text += " " + mtxtWord1.Text;
				}
				mtxtWord1.Text = "";
			};
			mtxtWord2.Click += (object sender, EventArgs e) => {
				if(string.IsNullOrEmpty(mtxtbAnswer.Text)){
					mtxtbAnswer.Text = mtxtWord2.Text;
				}else{
					mtxtbAnswer.Text += " " + mtxtWord2.Text;
				}
				mtxtWord2.Text = "";
			};
			mtxtWord3.Click += (object sender, EventArgs e) => {
				if(string.IsNullOrEmpty(mtxtbAnswer.Text)){
					mtxtbAnswer.Text = mtxtWord3.Text;
				}else{
					mtxtbAnswer.Text += " " + mtxtWord3.Text;
				}
				mtxtWord3.Text = "";
			};

			mbtnOk.Click += (object sender, EventArgs e) => {
				if(mtxtbAnswer.Text == sentence[intCtr, 1]){
					if(intCtr <= 7){
						intCtr++;
						Database.addCoins(10);
						mtxtCoins.Text = Convert.ToString(Database.getCoins());
					}else{
						Database.addCoins(10);
						mtxtCoins.Text = Convert.ToString(Database.getCoins());
						StartActivity(typeof(actMenu));
					}
				}
				mtxtbAnswer.Text = "";
				mtxtSentence.Text = sentence[intCtr, 0];
				mtxtWord1.Text = sentence[intCtr, 2];
				mtxtWord2.Text = sentence[intCtr, 3];
				mtxtWord3.Text = sentence[intCtr, 4];
			};

			mimgHome.Click += delegate {
				StartActivity(typeof(actMenu));
			};
		}
	}
}

