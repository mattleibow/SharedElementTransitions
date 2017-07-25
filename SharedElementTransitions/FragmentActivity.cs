using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace SharedElementTransitions
{
	[Activity]
	//[Activity(MainLauncher = true)]
	public class FragmentActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_fragment);

			var startFragment = new StartFragment();
			SupportFragmentManager
				.BeginTransaction()
				.Replace(Resource.Id.container, startFragment)
				.Commit();
		}
	}
}
