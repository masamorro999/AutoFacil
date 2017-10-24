namespace AutosRA.Services
{
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Views;

    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch (pageName)
            {
                case "CategoriesView":
                    await Application.Current.MainPage.Navigation.PushAsync(new CategoriesView());                
                    break;
                case "VehiclesView":
                    await Application.Current.MainPage.Navigation.PushAsync(new VehiclesView());
                    break;  
                case "NewCategoryView":
                    await Application.Current.MainPage.Navigation.PushAsync(new NewCategoryView());
                    break;         
            }

        }

        public async Task Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
