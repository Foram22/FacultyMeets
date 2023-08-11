﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace FacultyMeets;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        //global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
        //LoadApplication(new App());
    }
}

