using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace Cebuanizer
{
	[Activity (Label = "Cebuanizer", MainLauncher = true, NoHistory = true,  ScreenOrientation = ScreenOrientation.Portrait)]
	public class actStartUp : Activity
	{
		private ImageView mimgIcon;
		private ImageView mimgSlogan;
		private TextView mtxtTrivia;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.StartUp);

			mimgIcon = FindViewById<ImageView> (Resource.Id.limgIcon);
			mimgIcon.SetImageResource (Resource.Drawable.icon_large);
			mimgSlogan = FindViewById<ImageView> (Resource.Id.limgSlogan);
			mtxtTrivia = FindViewById<TextView> (Resource.Id.txtTrivia);
			mimgSlogan.SetImageResource (Resource.Drawable.slogan);

			Database.createDatabase ("Trivia");
			mtxtTrivia.Text += Database.getRandomTrivia ();

			mimgIcon.Click += (object sender, System.EventArgs e) => StartActivity(typeof(actMenu));

		}
	}
}


