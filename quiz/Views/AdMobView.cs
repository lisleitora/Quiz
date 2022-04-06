using System;
using MarcTron.Plugin.Controls;
using Xamarin.Forms;

namespace quiz.Views
{
    public class AdMobView : ContentView
    {
        public AdMobView()
        {
            MTAdView ads = new MTAdView();
            ads.AdsId = "ca-app-pub-3940256099942544/6300978111";
            //ads.AdsId = "ca-app-pub-5690757805861205/5120640176";
            //ads.PersonalizedAds = true;

            Content = ads;
        }
    }
}