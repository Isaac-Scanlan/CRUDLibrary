﻿using CRUDLibrary.Services;
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
        public MembersPage()
        {
            InitializeComponent();

            var windowService = App.ServiceProvider?.GetRequiredService<IWindowService>();
            var viewModel = App.ServiceProvider?.GetRequiredService<MembersPageViewModel>();

            DataContext = viewModel;
        }
    }
}
