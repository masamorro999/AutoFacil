namespace AutosRA.ViewModels
{
    using System;
    using System.Windows.Input;
    using AutosRA.Models;
    using GalaSoft.MvvmLight.Command;
    using Services;

    public class MainViewModel
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region Properties
        public LoginViewModel Login
        {
            get;
            set;
        }

        public CategoriesViewModel Categories
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;
        }

        public VehiclesViewModel Vehicles
        {
            get;
            set;
        }

        public NewCategoryViewModel NewCategory
        {
            get;
            set;
        }
        #endregion

        #region Constructor

        public MainViewModel()
        {
            instance = this;
            navigationService = new NavigationService();
            Login = new LoginViewModel();
        }

        #endregion

        #region Singleton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region Commands
        public ICommand NewCategoryCommand
        {
            get
            {
                return new RelayCommand(AddNewCategory);
            }
        }

        async void AddNewCategory()
        {
            NewCategory = new NewCategoryViewModel();
            await navigationService.Navigate("NewCategoryView");
        }
        #endregion

    }
}
