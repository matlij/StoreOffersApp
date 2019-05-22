using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using AppLocator.Models.Messages;
using Android.Content;
using AppLocator.Droid.Services;

namespace AppLocator.Droid
{
    [Activity(Label = "AppLocator", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            MessagingCenter.Subscribe<StartFindStoreOffersTask>(this, "StartFindStoreOffersTask", message =>
            {
                var intent = new Intent(this, typeof(LongRunningTaskService));
                StartService(intent);
            });

            MessagingCenter.Subscribe<StopFindStoreOffersTask>(this, "StopFindStoreOffersTask", message =>
            {
                var intent = new Intent(this, typeof(LongRunningTaskService));
                StopService(intent);
            });

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}