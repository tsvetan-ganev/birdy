namespace Birdy.Data.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class BirdsCounterViewModel : ObservableCollection<BirdSightingViewModel>
    {
        public BirdsCounterViewModel()
            : base()
        {
        }

        public BirdsCounterViewModel(IList<BirdSightingViewModel> birds)
            : base(birds)
        {
        }
    }
}