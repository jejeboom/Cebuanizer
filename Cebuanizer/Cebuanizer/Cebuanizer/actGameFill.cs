using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cebuanizer
{
	[Activity (Label = "actGameFill")]
	public class actGameFill : Activity
	{
		TextView tv;
		TextView tv3;
		Button btn;

		string[] tsentence = new string[]{"Si Juan ay LALAKI.", "Si Sheila ay BABAE."};
		string[] csentence = new string[]{"Si Juan ay LALAKE.", "Si Sheila ay BABAYE."};
		string[] tanswer = new string[]{"lalake", "babaye"};
		string[] canswer = new string[]{"lalaki", "babae"};

		string ts;
		string cs;
		string tans;
		string cans;
		int tag;
		int ceb;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.GameFill);

			// Get our button from the layout resource,
			// and attach an event to it
			tv = FindViewById<TextView>(Resource.Id.editText1);
			tv3 = FindViewById<TextView> (Resource.Id.textView2);
			btn = FindViewById<Button>(Resource.Id.button1);

			//		ts = tsentence[new Random(tsentence.Next(0, tsentence.Length))];
			//	cs = csentence[new Random(csentence.Next(0, csentence.Length))];
			int intCtr = 0;
			ts = Convert.ToString(tsentence.GetValue(0));
			cs = Convert.ToString(csentence.GetValue(0));

			tag = 0;
			ceb = 0;

			tans = Convert.ToString(tanswer.GetValue(tag));
			cans = Convert.ToString(canswer.GetValue (ceb));

			tv3.Text = ts;

			btn.Click += delegate {
				if(tv.Text == tans)
				{
					if (tag == 0)
					{
						ts = Convert.ToString(tsentence.GetValue(++tag));
					}
					else if(tag == 1)
						ts = Convert.ToString(tsentence.GetValue(0));

					tag = Array.IndexOf(tsentence, ts);
					tans = Convert.ToString(tanswer.GetValue(tag));
					intCtr++;
					tv3.Text = ts;
				}
				if(intCtr == 2){
					StartActivity(typeof(actGameMatching));
				}
			};
		}
	}
}


