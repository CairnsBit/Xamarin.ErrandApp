using CP_App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var errand = ((ListView)sender).SelectedItem as Errand;
            if (errand == null)
                return;
            await DisplayAlert("Errand Selected", errand.Name, "OK");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void MenuItem_Clicked(object sender, System.EventArgs e)
        {
            var errand = ((MenuItem)sender).BindingContext as Errand;
            if (errand == null)
                return;
            await DisplayAlert("Errand Favorited", errand.Name, "OK");
        }
    }
}