using System.Windows;
using System.Windows.Controls;

namespace CRUDLibrary.Views.Controls;

/// <summary>
/// Represents a custom button styled as an "Edit" button.
/// </summary>
public class EditButton : Button
{
    /// <summary>
    /// Initializes the <see cref="EditButton"/> class.
    /// Overrides the default style key to apply a custom style.
    /// </summary>
    static EditButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(EditButton), new FrameworkPropertyMetadata(typeof(EditButton))
        );
    }
}
