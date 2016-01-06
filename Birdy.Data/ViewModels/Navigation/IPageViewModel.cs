namespace Birdy.Data.ViewModels
{
    public interface IPageViewModel
    {
        string Name { get; set; }

        bool IsSelected { get; set; }
    }
}