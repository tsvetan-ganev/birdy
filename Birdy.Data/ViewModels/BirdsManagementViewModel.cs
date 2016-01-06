namespace Birdy.Data.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Base;
    using Models;
    using Services;

    public class BirdsManagementViewModel : ObservableCollection<BirdEntryViewModel>
    {
        private ICommand removeItemCommand;
        private ICommand addItemCommand;
        private ICommand updateItemCommand;

        public BirdsManagementViewModel()
            : base()
        {
        }

        public BirdsManagementViewModel(IList<Bird> birds)
            : base()
        {
            foreach (var sourceBird in birds)
            {
                var birdEntryViewModel = new BirdEntryViewModel(sourceBird);
                this.Add(birdEntryViewModel);
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (this.removeItemCommand == null)
                {
                    this.removeItemCommand = new DelegateCommand<BirdEntryViewModel>((bird) =>
                    {
                        this.Remove(bird);
                        BirdsService.Instance.RemoveBird(bird.Id);
                    });
                }

                return this.removeItemCommand;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (this.addItemCommand == null)
                {
                    this.addItemCommand = new DelegateCommand<BirdEntryViewModel>((bird) =>
                    {
                        BirdEntryViewModel newBird = new BirdEntryViewModel()
                        {
                        };

                        this.Add(newBird);
                        BirdsService.Instance.AddBird(newBird);
                    });
                }

                return this.addItemCommand;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateItemCommand == null)
                {
                    this.updateItemCommand = new DelegateCommand<BirdEntryViewModel>((bird) =>
                    {
                        if (BirdsService.Instance.UpdateBird(bird))
                        {
                            bird.RaisePropertiesChangedEvents();
                        }
                    });
                }

                return this.updateItemCommand;
            }
        }
    }
}