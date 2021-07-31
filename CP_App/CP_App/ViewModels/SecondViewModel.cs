using CP_App.Models;
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
        public ObservableRangeCollection<Grouping<string, Errand>> ErrandGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Errand> FavoriteCommand { get; }

        public SecondViewModel()
        {
            Title = "Errands";

            Errand = new ObservableRangeCollection<Errand>();
            ErrandGroups = new ObservableRangeCollection<Grouping<string, Errand>>();

            var image = "https://image.pngaaa.com/962/680962-small.png";

            Errand.Add(new Errand { Category = "Physical", Name = "Squats", Description = "Go down", Image = image });
            Errand.Add(new Errand { Category = "Physical", Name = "Running", Description = "Move legs", Image = image });
            Errand.Add(new Errand { Category = "Physical", Name = "Push-ups", Description = "Push ground", Image = image });
            Errand.Add(new Errand { Category = "Physical", Name = "Go crazy", Description = "Go Stupid", Image = image });

            Errand.Add(new Errand { Category = "Mental", Name = "Meditation", Description = "Think", Image = image });
            Errand.Add(new Errand { Category = "Mental", Name = "Become Monkey", Description = "Ook ook", Image = image });
            Errand.Add(new Errand { Category = "Mental", Name = "Become Clown", Description = "Circus", Image = image });
            Errand.Add(new Errand { Category = "Mental", Name = "Prepare", Description = "Mentally", Image = image });

            ErrandGroups.Add(new Grouping<string, Errand>("Mental", Errand.Where(c => c.Category == "Mental")));
            ErrandGroups.Add(new Grouping<string, Errand>("Physical", Errand.Where(c => c.Category == "Physical")));

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Errand>(Favorite);
        }

        Errand previouslySelected;
        Errand selectedErrand;
        public Errand SelectedErrand
        {
            get => selectedErrand;
            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "OK");
                    previouslySelected = value;
                    value = null;
                }
                selectedErrand = value;
                OnPropertyChanged();
            }
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1000);
            IsBusy = false;
        }

        async Task Favorite(Errand errand)
        {
            if (errand == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Favorited", errand.Name, "OK");
        }
    }
}
