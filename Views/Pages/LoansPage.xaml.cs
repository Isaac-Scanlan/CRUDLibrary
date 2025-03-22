using CRUDLibrary.Services;
using CRUDLibrary.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace CRUDLibrary.Views.Pages
{
    /// <summary>
    /// Interaction logic for LoansPage.xaml
    /// </summary>
    public partial class LoansPage : Page
    {
        /// <summary>
        /// Initialises components for Loans Page
        /// </summary>
        public LoansPage()
        {
            InitializeComponent();

            //var windowService = App.ServiceProvider?.GetRequiredService<IWindowService>();
            //var viewModel = App.ServiceProvider?.GetRequiredService<LoansPageViewModel>();

            //DataContext = viewModel;
        }

        
    }
}
