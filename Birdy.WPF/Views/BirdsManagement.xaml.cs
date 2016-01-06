namespace Birdy.WPF.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using Birdy.Data.Services;
    using Birdy.Data.ViewModels;
    using Data.Models;

    public partial class BirdsManagement : UserControl
    {
        private BirdsManagementViewModel viewModel;

        public BirdsManagement()
        {
            this.InitializeComponent();
        }

        public BirdsManagementViewModel ViewModel
        {
            get
            {
                if (this.viewModel == null)
                {
                    var birds = BirdsService.Instance.Birds;

                    this.viewModel = new BirdsManagementViewModel(birds);
                }

                return this.viewModel;
            }

            set
            {
                this.viewModel = value;
            }
        }

        public string[] GetBirdTypes()
        {
            var enumValues = Enum.GetNames(typeof(BirdType));
            return enumValues;
        }
    }
}
