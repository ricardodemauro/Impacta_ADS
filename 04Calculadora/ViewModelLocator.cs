using Microsoft.Extensions.DependencyInjection;
using WPF.Calculadora.ViewModels;

namespace WPF.Calculadora
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {

        }

        public MainViewModel Main => App.ServiceProvider.GetService<MainViewModel>();
    }
}
