namespace Birdy.Data.ViewModels.Base
{
    public abstract class BasePageViewModel : Observable, IPageViewModel
    {
        private bool isSelected;

        public string Name { get; set; }

        public uint Column { get; set; }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                this.isSelected = value;
                this.RaisePropertyChangedEvent(nameof(this.IsSelected));
            }
        }
    }
}