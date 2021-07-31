using CP_App.Models;
using CP_App.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CP_App.ViewModels
{
    class SecondViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Errand> Errand { get; set; }
        //public ObservableRangeCollection<Grouping<string, Errand>> ErrandGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Errand> RemoveCommand { get; }

        public SecondViewModel()
        {
            Title = "Errands";

            Errand = new ObservableRangeCollection<Errand>();
            //ErrandGroups = new ObservableRangeCollection<Grouping<string, Errand>>();

            //ErrandGroups.Add(new Grouping<string, Errand>("Mental", Errand.Where(c => c.Category == "Mental")));
            //ErrandGroups.Add(new Grouping<string, Errand>("Physical", Errand.Where(c => c.Category == "Physical")));

            RefreshCommand = new AsyncCommand(Refresh);
            SelectedCommand = new AsyncCommand<object>(Selected);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Errand>(Remove);
        }

        Errand previouslySelected;
        Errand selectedErrand;
        public Errand SelectedErrand
        {
            get => selectedErrand;
            set => SetProperty(ref selectedErrand, value);
        }

        public async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Errand.Clear();
            var errands = await ErrandService.GetErrand();
            Errand.AddRange(errands);
            IsBusy = false;
        }
        async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Errands name.");
            var description = await App.Current.MainPage.DisplayPromptAsync("Description", "What is the errand.");
            var category = await App.Current.MainPage.DisplayPromptAsync("Category", "Which category.");
            await ErrandService.AddErrand(name, description, category);
            await Refresh();
        }
        async Task Remove(Errand errand)
        {
            await ErrandService.RemoveErrand(errand.Id);
            await Refresh();
        }

        async Task Selected(object args)
        {
            var errand = args as Errand;
            if (errand == null)
                return;

            SelectedErrand = null;

            await Application.Current.MainPage.DisplayAlert("Selected", errand.Name, "OK");
        }
    }
}
