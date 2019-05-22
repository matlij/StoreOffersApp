using AppLocator.Bootstrap;
using AppLocator.Interfaces.Services.Data;
using AppLocator.Interfaces.Utilities;
using AppLocator.Models;
using AppLocator.Models.ViewModels;
using AppLocator.Utility;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace AppLocator.Helpers
{
    public partial class MainPage : ContentPage
    {
        private StoresView _viewModel;

        public MainPage()
        {
            InitializeComponent();

            //HandleReceivedMessage();

            _viewModel = new StoresView(AppContainer.Resolve<IStoreService>());
            BindingContext = _viewModel;
        }

        private void HandleReceivedMessage()
        {
            MessagingCenter.Subscribe<Store>(this, "StoreOfferFound", store =>
            {
                CrossLocalNotifications.Current.Show("Erbjudande från " + store.Name, store.Offer);
            });

            MessagingCenter.Subscribe<ValueChangedEventArgs>(this, "NewSendOfferDistanceValue", e =>
            {
                //_sendOfferDistance = e.NewValue;
                //GenerateStoreView();
            });
        }

        private async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tappedItem = e.Item as Store;

            await Navigation.PushAsync(new StorePage(tappedItem));
        }
    }
}
