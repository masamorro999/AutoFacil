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
        #endregion
    }
}
