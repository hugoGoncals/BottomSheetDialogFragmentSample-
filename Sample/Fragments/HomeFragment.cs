using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.Navigation;

namespace com.companyname.NavigationCodeLab.Fragments
{
    public class HomeFragment : Fragment //, View.IOnClickListener
    {
        public HomeFragment() { }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            
            HasOptionsMenu = true;
            return inflater.Inflate(Resource.Layout.home_fragment, container, false);
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            base.OnCreateOptionsMenu(menu, inflater);
            inflater.Inflate(Resource.Menu.main_menu, menu);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            NavOptions navOptions = new NavOptions.Builder()
                .SetEnterAnim(Resource.Animation.slide_in_right) 
                .SetExitAnim(Resource.Animation.slide_out_left) 
                .SetPopEnterAnim(Resource.Animation.slide_in_left)
                .SetPopExitAnim(Resource.Animation.slide_out_right)
                .Build();

            view.FindViewById<Button>(Resource.Id.navigate_destination_button).Click += (sender, e) =>
            {
                Navigation.FindNavController((View)sender).Navigate(Resource.Id.bottom_sheet_dest, null, navOptions);
            };
        }
    }
}