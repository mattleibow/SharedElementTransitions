using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace SharedElementTransitions
{
	public class EndFragment : Android.Support.V4.App.Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			Bundle bundle = Arguments;
			string actionTitle = "DUMMY ACTION";
			Bitmap imageBitmap = null;
			string transText = "";
			string transitionName = "";

			if (bundle != null)
			{
				transitionName = bundle.GetString("TRANS_NAME");
				actionTitle = bundle.GetString("ACTION");
				imageBitmap = (Bitmap)bundle.GetParcelable("IMAGE");
				transText = bundle.GetString("TRANS_TEXT");
			}

			Activity.Title = actionTitle;

			var view = inflater.Inflate(Resource.Layout.fragment_end, container, false);

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				view.FindViewById(Resource.Id.listImage).TransitionName = transitionName;
				view.FindViewById(Resource.Id.textView).TransitionName = transText;
			}

			view.FindViewById<ImageView>(Resource.Id.listImage).SetImageBitmap(imageBitmap);
			view.FindViewById<TextView>(Resource.Id.textView).Text = actionTitle;

			return view;
		}
	}
}
