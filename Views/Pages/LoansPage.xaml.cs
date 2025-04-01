using CRUDLibrary.Services;
using CRUDLibrary.ViewModels.Loans;
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
        public LoansPage(LoansPageViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;

            Loaded += async (_, _) => await viewModel.InitializeAsync();
        }

        
    }
}
