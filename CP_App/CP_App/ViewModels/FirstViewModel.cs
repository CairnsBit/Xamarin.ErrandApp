using MvvmHelpers.Commands;
using System.Windows.Input;

namespace CP_App.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        int count = 0;
        string countDisplay = "0";
        public ICommand IncreaseCount { get; }

        public FirstViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
        }
        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }

        void OnIncrease()
        {
            count++;
            CountDisplay = $"{count}";
        }
    }
}
