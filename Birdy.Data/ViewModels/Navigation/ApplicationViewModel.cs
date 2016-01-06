namespace Birdy.Data.ViewModels.Navigation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Base;

    public class ApplicationViewModel : Observable
    {
        private ICommand changePageCommand;

        private IPageViewModel currentPageViewModel;
        private List<IPageViewModel> pageViewModels;

        public ApplicationViewModel()
        {
            this.PageViewModels.Add(new IndexPageViewModel { Name = "Index", Column = 0 });
            this.PageViewModels.Add(new BirdsManagementPageViewModel() { Name = "Birds Management", Column = 1 });
            this.PageViewModels.Add(new BirdsCounterPageViewModel() { Name = "Birds Counter", Column = 2 });

            this.CurrentPageViewModel = this.PageViewModels.First();
            this.CurrentPageViewModel.IsSelected = true;
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (this.pageViewModels == null)
                {
                    this.pageViewModels = new List<IPageViewModel>();
                }

                return this.pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return this.currentPageViewModel;
            }

            set
            {
                if (this.currentPageViewModel != value)
                {
                    this.currentPageViewModel = value;
                    this.RaisePropertyChangedEvent(nameof(this.CurrentPageViewModel));
                }
            }
        }

        public ICommand ChangePageCommand
        {
            get
            {
                if (this.changePageCommand == null)
                {
                    this.changePageCommand = new DelegateCommand<IPageViewModel>(this.ChangePage);
                }

                return this.changePageCommand;
            }
        }

        private void ChangePage(IPageViewModel page)
        {
            if (!this.PageViewModels.Contains(page))
            {
                this.PageViewModels.Add(page);
            }

            var chosenPageViewModel = this.PageViewModels.FirstOrDefault(p => p == page);

            this.CurrentPageViewModel.IsSelected = false;
            chosenPageViewModel.IsSelected = true;

            this.CurrentPageViewModel = chosenPageViewModel;
        }
    }
}