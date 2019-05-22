using AppLocator.Bootstrap;
using AppLocator.Interfaces.Services.Data;
using AppLocator.Models;
using AppLocator.Models.ViewModels;
using AppLocator.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLocator.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StoreListPage : ContentPage
	{
		public StoreListPage ()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new StoreListViewModel(AppContainer.Resolve<IStoreService>());
        }

        private async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tappedItem = e.Item as Store;

            await Navigation.PushAsync(new StorePage(tappedItem));
        }
    }
}