﻿using CRUDLibrary.Services;
using CRUDLibrary.ViewModels;
using CRUDLibrary.ViewModels.Inventory;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace CRUDLibrary.Views.Pages;

/// <summary>
/// Interaction logic for InventoryPage.xaml
/// </summary>
public partial class InventoryPage : Page
{
    /// <summary>
    /// Initialises components for InventoryPage
    /// </summary>
    public InventoryPage(InventoryPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

        Loaded += async (_, _) => await viewModel.InitializeAsync();
    }

}
