using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace SharedElementTransitions
{
	[Activity]
	public class EndActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_end);

			var smallImageView = FindViewById(Resource.Id.textView);
			var editText = FindViewById(Resource.Id.editText);

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				smallImageView.TransitionName = GetString(Resource.String.activity_text_trans);
				editText.TransitionName = GetString(Resource.String.activity_mixed_trans);
			}
		}
	}
}
