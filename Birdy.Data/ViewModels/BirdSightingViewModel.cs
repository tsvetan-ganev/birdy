namespace Birdy.Data.ViewModels
{
    using Birdy.Data.Models;
    using System.Windows.Input;
    using Base;
    using Services;
    using System;

    public class BirdSightingViewModel : Observable
    {
        private readonly Bird bird = new Bird();

        private ICommand incrementBirdsCount;

        private ICommand decrementBirdsCount;

        public BirdSightingViewModel()
        {
        }

        public BirdSightingViewModel(Bird model)
        {
            this.bird = model;
        }

        public Guid Id
        {
            get { return this.bird.Id; }
        }

        public string Name
        {
            get { return this.bird.Name; }
            set { this.bird.Name = value; }
        }

        public int Count
        {
            get
            {
                return this.bird.SightingsCount;
            }

            set
            {
                if (value < 0)
                {
                    this.bird.SightingsCount = 0;
                }
                else
                {
                    this.bird.SightingsCount = value;
                    this.RaisePropertyChangedEvent(nameof(this.Count));
                    BirdsService.Instance.UpdateBirdSightingsCount(this);
                }
            }
        }

        public string Picture
        {
            get { return this.bird.Picture; }
            set { this.bird.Picture = value; }
        }

        public ICommand IncrementBirdsCount
        {
            get
            {
                if (this.incrementBirdsCount == null)
                {
                    this.incrementBirdsCount = new DelegateCommand<object>(p =>
                    {
                        this.Count += 1;
                    });
                }

                return this.incrementBirdsCount;
            }
        }

        public ICommand DecrementBirdsCount
        {
            get
            {
                if (this.decrementBirdsCount == null)
                {
                    this.decrementBirdsCount = new DelegateCommand<object>(p =>
                    {
                        this.Count -= 1;
                    });
                }

                return this.decrementBirdsCount;
            }
        }
    }
}
