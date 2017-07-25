using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.Util;
using Android.Content;

namespace SharedElementTransitions
{
	//[Activity]
	[Activity(MainLauncher = true)]
	public class StartActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_start);

			FindViewById<Button>(Resource.Id.button).Click += (sender, e) =>
			{
				var imageView = FindViewById(Resource.Id.imageView);
				var textView = FindViewById(Resource.Id.textView);
				var button = FindViewById(Resource.Id.button);

				var intent = new Intent(this, typeof(EndActivity));

				if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
				{
					textView.TransitionName = GetString(Resource.String.activity_text_trans);
					button.TransitionName = GetString(Resource.String.activity_mixed_trans);

					var pair1 = Pair.Create(imageView, imageView.TransitionName);
					var pair2 = Pair.Create(textView, textView.TransitionName);
					var pair3 = Pair.Create(button, button.TransitionName);

					var options = ActivityOptionsCompat.MakeSceneTransitionAnimation(this, pair1, pair2, pair3);

					StartActivity(intent, options.ToBundle());
				}
				else
				{
					StartActivity(intent);
				}
			};
		}
	}
}
