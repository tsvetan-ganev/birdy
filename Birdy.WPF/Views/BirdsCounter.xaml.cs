namespace Birdy.WPF.Views
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using Data.Services;
    using Data.ViewModels;

    public partial class BirdsCounter : UserControl
    {
        private BirdsCounterViewModel viewModel;

        public BirdsCounter()
        {
            this.InitializeComponent();
        }

        public BirdsCounterViewModel ViewModel
        {
            get
            {
                if (this.viewModel == null)
                {
                    this.viewModel = new BirdsCounterViewModel(
                        BirdsService.Instance.Birds
                                    .Select(b => new BirdSightingViewModel(b))
                                    .ToList());
                }

                return this.viewModel;
            }
        }
    }
}
