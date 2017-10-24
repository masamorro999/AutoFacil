﻿namespace AutosRA.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using AutosRA.Models;
    using AutosRA.Services;

    public class CategoriesViewModel : INotifyPropertyChanged
    {
        #region Attributes
        List<Category> categories;
        public ObservableCollection<Category> _categories;
        #endregion

        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public ObservableCollection<Category> CategoriesList
        {
            get
            {
                return _categories;
            }
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    PropertyChanged?.Invoke(
                        this, 
                        new PropertyChangedEventArgs(nameof(CategoriesList)));
                }
            }
        }
        #endregion


        #region Constructor
        public CategoriesViewModel()
        {
            instance = this;

            apiService = new ApiService();
            dialogService = new DialogService();
            LoadCategories();
        }
        #endregion

        #region Singleton
        static CategoriesViewModel instance;

        public static CategoriesViewModel GetInstance()
        {
            if (instance == null)
            {
                return new CategoriesViewModel();
            }
            return instance;
        }
        #endregion


        #region Methods
        public void  AddCategory(Category category)
        {
            categories.Add(category);
            CategoriesList = new ObservableCollection<Category>(
                categories.OrderBy(c => c.Description));
        }

        async void LoadCategories()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await apiService.GetList<Category>(
                "http://autosraapi.azurewebsites.net",
                "/api", 
                "/Categories", 
                mainViewModel.Token.TokenType,
                mainViewModel.Token.AccessToken
            );

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }
            categories = (List<Category>)response.Result;
            CategoriesList = new ObservableCollection<Category>(
                categories.OrderBy(c => c.Description));
        }
        #endregion

    }
}
