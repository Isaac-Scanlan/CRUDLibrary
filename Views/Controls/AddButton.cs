using System.Windows;
using System.Windows.Controls;

namespace CRUDLibrary.Views.Controls;

/// <summary>
/// Represents a custom button styled as an "Add" button.
/// </summary>
public class AddButton : Button
{
    /// <summary>
    /// Initializes the <see cref="AddButton"/> class.
    /// Overrides the default style key to apply a custom style.
    /// </summary>
    static AddButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(AddButton), new FrameworkPropertyMetadata(typeof(AddButton))
            );
    }
}
