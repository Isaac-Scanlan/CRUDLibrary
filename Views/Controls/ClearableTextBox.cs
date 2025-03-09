using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

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

    /// <summary>
    /// Clears the text content of the text box.
    /// </summary>
    private void ClearText()
    {
        Clear();
    }
}