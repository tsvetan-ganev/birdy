namespace Birdy.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Base;
    using Models;

    public class BirdEntryViewModel : Observable
    {
        private readonly Bird model = new Bird();

        public BirdEntryViewModel()
        {
            this.model = new Bird();
        }

        public BirdEntryViewModel(Bird bird)
        {
            this.model = bird;
        }

        public Guid Id
        {
            get { return this.model.Id; }
            set { this.model.Id = this.Id; }
        }

        public string Name
        {
            get
            {
                return this.model.Name;
            }

            set
            {
                this.model.Name = value;
                this.RaisePropertyChangedEvent(nameof(this.Name));
            }
        }

        public BirdType Type
        {
            get
            {
                return this.model.Type;
            }

            set
            {
                this.model.Type = value;
                this.RaisePropertyChangedEvent(nameof(this.Type));
            }
        }

        public decimal Length
        {
            get
            {
                return this.model.Length;
            }

            set
            {
                this.model.Length = value;
                this.RaisePropertyChangedEvent(nameof(this.Length));
            }
        }

        public string Description
        {
            get
            {
                return this.model.Description;
            }

            set
            {
                this.model.Description = value;
                this.RaisePropertyChangedEvent(nameof(this.Description));
            }
        }

        public string BaseColor
        {
            get
            {
                return this.model.BaseColor;
            }

            set
            {
                this.model.BaseColor = value;
                this.RaisePropertyChangedEvent(nameof(this.BaseColor));
            }
        }

        public string Picture
        {
            get
            {
                return this.model.Picture;
            }

            set
            {
                this.model.Picture = value;
                this.RaisePropertyChangedEvent(nameof(this.Picture));
            }
        }

        public IEnumerable<BirdType> BirdTypeEnumValues
        {
            get
            {
                return Enum.GetNames(typeof(BirdType)).Cast<BirdType>();
            }
        }

        public void RaisePropertiesChangedEvents()
        {
            this.RaisePropertyChangedEvent(nameof(this.Name));
            this.RaisePropertyChangedEvent(nameof(this.Type));
            this.RaisePropertyChangedEvent(nameof(this.Length));
            this.RaisePropertyChangedEvent(nameof(this.Description));
            this.RaisePropertyChangedEvent(nameof(this.BaseColor));
            this.RaisePropertyChangedEvent(nameof(this.Picture));
        }
    }
}