namespace AutosRA.Models
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using AutosRA.ViewModels;
    using GalaSoft.MvvmLight.Command;
    using Services;

    public class Category
    {
        #region Services
        NavigationService navigationService;
        DialogService dialogService;
        #endregion

        #region Properties
        public int CategoryId
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public List<Vehicle> Vehicles
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public Category()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
        }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return CategoryId;
        }
        #endregion

        #region Commands
        public ICommand SelectCategoryCommand
        {
            get
            {
                return new RelayCommand(SelectCategory);
            }
        }

        async void SelectCategory()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Vehicles = new VehiclesViewModel(Vehicles);
            await navigationService.Navigate("VehiclesView");
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(Edit);
            }
        }

        async void Edit ()
        {
            MainViewModel.GetInstance().EditCategory = new EditCategoryViewModel(this);
            await navigationService.Navigate("EditCategoryView");
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(Delete);
            }
        }

        async void Delete()
        {
            var response = await dialogService.ShowConfirm("Confirm", "Are you sure you want to delete this record?");
            if (!response)
            {
                return;
            }

            CategoriesViewModel.GetInstance().DeleteCategory(this); 

        }
        #endregion
    }
}
