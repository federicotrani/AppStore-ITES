using AppStore.mvvm.Views;

namespace AppStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new ProductoListaPage(new mvvm.ViewModels.ProductoListaViewModel()));
      
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
