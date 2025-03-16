using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Markup;

namespace CRUDLibrary.Views.Controls;

/// <summary>
/// Represents a custom data grid with additional features.
/// </summary>
[ContentProperty(nameof(Columns))] // This enables defining <DisplayTable.Columns> in XAML
public class DisplayTable : DataGrid
{
    static DisplayTable()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(DisplayTable), new FrameworkPropertyMetadata(typeof(DisplayTable))
        );
    }

    /// <summary>
    /// Gets or sets the currently selected row in the data grid.
    /// Supports two-way data binding.
    /// </summary>
    public object SelectedRow
    {
        get => GetValue(SelectedRowProperty);
        set => SetValue(SelectedRowProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="SelectedRow"/> dependency property.
    /// Enables binding to the selected row of the data grid.
    /// </summary>
    public static readonly DependencyProperty SelectedRowProperty =
        DependencyProperty.Register(
            nameof(SelectedRow),
            typeof(object),
            typeof(DisplayTable),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );
}