using AppLocator.Bootstrap;
using AppLocator.Interfaces.Utilities;
using AppLocator.Models;
using AppLocator.Models.ViewModels;
using AppLocator.Utility;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLocator.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        public SettingsView SettingsView { get; private set; }

        public SettingsPage ()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Settings = await App.DataBase.GetSettingsAsync(1);

            //sliderLabelOffer.Text = $"Erbjudanderadie: {Settings.StoreOfferRadius} km";
            //sliderOffer.Value = Settings.StoreOfferRadius;

            //sliderLabelSearch.Text = $"Sök erbjudanden intervall: {Settings.SearchOfferIntervalSeconds} sek";
            //sliderSearch.Value = Settings.SearchOfferIntervalSeconds;

            //var userLocation = await GeoLocator.GetLocationAsync();

            SettingsView = new SettingsView(AppContainer.Resolve<IGeoLocator>());
            BindingContext = SettingsView;
        }

        private void SliderOffer_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            SettingsView.Settings.StoreOfferRadius = Math.Round(e.NewValue, 2);
            sliderLabelOffer.Text = $"Erbjudanderadie: {SettingsView.Settings.StoreOfferRadius} km";
        }

        private void SliderSearch_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            SettingsView.Settings.SearchOfferIntervalSeconds = Convert.ToInt32(e.NewValue);
            sliderLabelSearch.Text = $"Sök erbjudanden intervall: {SettingsView.Settings.SearchOfferIntervalSeconds} sek";
        }

        private async void ButtonSaveClicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(e, "NewSendOfferDistanceValue");
            var result = await App.DataBase.SaveSettingsAsync(SettingsView.Settings);
            if (result > 0)
            {
                await DisplayAlert("Sparat!", "Dina inställningar har sparats.", "OK");
            }
            else
            {
                await DisplayAlert("Något blev fel", "Dina inställningar har inte sparats.", "OK");
            }
        }
    }
}