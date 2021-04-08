using Android.OS;
using Android.Views;
using com.companyname.NavigationCodeLab;
using Google.Android.Material.BottomSheet;

namespace CAPMobile.Droid.Fragment
{
    public class BottomSheetExample : BottomSheetDialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.bottom_sheet_layout, container, false);
        }

    }
}
