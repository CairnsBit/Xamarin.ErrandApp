using CP_App.Models;
using CP_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        private readonly SecondViewModel model;

        public SecondPage()
        {
            InitializeComponent();
            model = BindingContext as SecondViewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Refresh();
        }
    }
}
