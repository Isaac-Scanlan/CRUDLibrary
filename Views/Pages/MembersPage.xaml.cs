using CRUDLibrary.Services;
using CRUDLibrary.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CRUDLibrary.Views.Pages
{
    /// <summary>
    /// Interaction logic for MembersPage.xaml
    /// </summary>
    public partial class MembersPage : Page
    {
        /// <summary>
        /// Initialises components for Members Page
        /// </summary>
        public MembersPage(MembersPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            Loaded += async (_, _) => await viewModel.InitializeAsync();
        }
    }
}
