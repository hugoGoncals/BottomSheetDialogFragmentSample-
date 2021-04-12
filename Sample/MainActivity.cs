using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.DrawerLayout.Widget;
using AndroidX.Navigation;
using AndroidX.Navigation.Fragment;
using AndroidX.Navigation.UI;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Navigation;
using System;

namespace com.companyname.NavigationCodeLab
{
    /*
        * An activity demonstrating use of a NavHostFragment with a navigation drawer and bottom.
    */
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity, NavController.IOnDestinationChangedListener
    {
        private AppBarConfiguration appBarConfiguration;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.navigation_activity);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            NavHostFragment host = SupportFragmentManager.FindFragmentById(Resource.Id.my_nav_host_fragment) as NavHostFragment;
            NavController navController = host.NavController;

            int[] topLevelDestinationIds = new int[] { Resource.Id.home_dest};
            appBarConfiguration = new AppBarConfiguration.Builder(topLevelDestinationIds).SetDrawerLayout(FindViewById<DrawerLayout>(Resource.Id.drawer_layout)).Build();

            SetupActionBar(navController, appBarConfiguration);
            SetupNavigationMenu(navController);
            SetupBottomNavMenu(navController);

            navController.AddOnDestinationChangedListener(this);
        }


        private void SetupBottomNavMenu(NavController navController)
        {
            var bottomNav = FindViewById<BottomNavigationView>(Resource.Id.bottom_nav_view);
            if (bottomNav != null)
                NavigationUI.SetupWithNavController(bottomNav, navController);
        }

        private void SetupNavigationMenu(NavController navController)
        {
            var sideNavView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (sideNavView != null)
                NavigationUI.SetupWithNavController(sideNavView, navController);
        }

        private void SetupActionBar(NavController navController, AppBarConfiguration appBarConfiguration)
        {
            NavigationUI.SetupActionBarWithNavController(this, navController, appBarConfiguration);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            bool retValue = base.OnCreateOptionsMenu(menu);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView == null)
            {
                MenuInflater.Inflate(Resource.Menu.overflow_menu, menu);
                return true;
            }
            return retValue;
        }

        public void OnDestinationChanged(NavController p0, NavDestination p1, Bundle p2)
    {
        int navDestinationId = p1.Id;
        string destination;

        try { destination = Resources.GetResourceName(navDestinationId); }
        catch (Android.Content.Res.Resources.NotFoundException) { destination = Convert.ToString(navDestinationId); }

        Toast.MakeText(this, "Navigated to " + destination, ToastLength.Short).Show();
    } 
}
}