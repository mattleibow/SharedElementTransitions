using System;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Transitions;
using Android.Views;
using Android.Widget;

namespace SharedElementTransitions
{
	public class StartFragment : Android.Support.V4.App.Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.fragment_start, container, false);

			var strings = new[] { "First Element", "Second Element", "Third Element" };
			var myListAdapter = new MyListAdapter(Activity, Resource.Layout.list_item, strings);

			var listView = view.FindViewById<ListView>(Resource.Id.listView);
			listView.Adapter = myListAdapter;
			listView.ItemClick += OnItemClick;

			return view;
		}

		public void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			string imageTransitionName = "";
			string textTransitionName = "";

			var imageView = e.View.FindViewById<ImageView>(Resource.Id.imageView);
			var textView = e.View.FindViewById<TextView>(Resource.Id.textView);

			var staticImage = View.FindViewById<ImageView>(Resource.Id.imageView);

			EndFragment endFragment = new EndFragment();

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				SharedElementReturnTransition = TransitionInflater.From(Activity).InflateTransition(Resource.Transition.change_image_trans);
				ExitTransition = TransitionInflater.From(Activity).InflateTransition(Android.Resource.Transition.Fade);

				endFragment.SharedElementEnterTransition = TransitionInflater.From(Activity).InflateTransition(Resource.Transition.change_image_trans);
				endFragment.EnterTransition = TransitionInflater.From(Activity).InflateTransition(Android.Resource.Transition.Fade);

				imageTransitionName = imageView.TransitionName;
				textTransitionName = textView.TransitionName;
			}

			var bundle = new Bundle();
			bundle.PutString("TRANS_NAME", imageTransitionName);
			bundle.PutString("ACTION", textView.Text);
			bundle.PutString("TRANS_TEXT", textTransitionName);
			bundle.PutParcelable("IMAGE", ((BitmapDrawable)imageView.Drawable).Bitmap);
			endFragment.Arguments = bundle;

			FragmentManager.BeginTransaction()
				.Replace(Resource.Id.container, endFragment)
				.AddToBackStack("Payment")
				.AddSharedElement(imageView, imageTransitionName)
				.AddSharedElement(textView, textTransitionName)
				.AddSharedElement(staticImage, GetString(Resource.String.fragment_image_trans))
				.Commit();
		}

		private class MyListAdapter : ArrayAdapter<string>
		{
			public MyListAdapter(Context context, int textViewResourceId, string[] objects)
				: base(context, textViewResourceId, objects)
			{
			}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				var view = convertView;

				if (view == null)
				{
					view = LayoutInflater.From(Context).Inflate(Resource.Layout.list_item, null);
				}

				var listItem = GetItem(position);

				var textView = view.FindViewById<TextView>(Resource.Id.textView);
				textView.Text = listItem;

				var imageView = view.FindViewById<ImageView>(Resource.Id.imageView);
				imageView.SetImageResource(GetRandomImage());

				if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
				{
					textView.TransitionName = "trans_text" + position;
					imageView.TransitionName = "trans_image" + position;
				}

				return view;
			}

			private int GetRandomImage()
			{
				if (new Random().Next(2) == 1)
					return Resource.Drawable.aa_logo_blue;
				return Resource.Drawable.aa_logo_green;
			}
		}
	}
}
