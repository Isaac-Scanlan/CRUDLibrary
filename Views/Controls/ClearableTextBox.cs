using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Collections;

namespace CRUDLibrary.Views.Controls;

/// <summary>
/// Represents a custom text box with a built-in clear button.
/// </summary>
public class ClearableTextBox : TextBox
{
    /// <summary>
    /// Gets the command used to clear the text in the <see cref="ClearableTextBox"/>.
    /// </summary>
    public ICommand ClearCommand { get; }

    /// <summary>
    /// Initializes the <see cref="ClearableTextBox"/> class.
    /// Overrides the default style key to apply a custom style.
    /// </summary>
    static ClearableTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ClearableTextBox), new FrameworkPropertyMetadata(typeof(ClearableTextBox))
        );
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClearableTextBox"/> class.
    /// Sets up the <see cref="ClearCommand"/> to clear the text when executed.
    /// </summary>
    public ClearableTextBox()
    {
        ClearCommand = new RelayCommand(ClearText);
    }

    public static readonly DependencyProperty IsDropDownOpenProperty =
    DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(ClearableTextBox), new PropertyMetadata(false));

    public bool IsDropDownOpen
    {
        get => (bool)GetValue(IsDropDownOpenProperty);
        set => SetValue(IsDropDownOpenProperty, value);
    }

    public static readonly DependencyProperty ItemsSourceProperty =
    DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ClearableTextBox), new PropertyMetadata(null));

    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    /// <summary>
    /// Clears the text content of the text box.
    /// </summary>
    private void ClearText()
    {
        Clear();
    }
}