namespace AutosRA.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using AutosRA.Models;

    public class CategoriesViewModel
    {
        #region Properties
        public ObservableCollection<Category> Categories
        {
            get;
            set;
        }
        #endregion


        #region Constructor
        public CategoriesViewModel()
        {
            LoadCategories();
        }
        #endregion


        #region Methods
        void LoadCategories()
        {
            
        }
        #endregion

    }
}
