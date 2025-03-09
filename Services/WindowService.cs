using CRUDLibrary.ViewModels;
using CRUDLibrary.Views.Windows;

namespace CRUDLibrary.Services;

/// <summary>
/// Provides a service for displaying a popup window to add a new book.
/// </summary>
public class WindowService : IWindowService
{
    /// <summary>
    /// Displays a popup window for entering book details and returns the entered data upon closing.
    /// </summary>
    /// <param name="title">The pre-filled title of the book.</param>
    /// <param name="author">The pre-filled author of the book.</param>
    /// <param name="genre">The pre-filled genre of the book.</param>
    /// <param name="onPopupClosed">
    /// A callback function that is invoked when the popup closes,
    /// returning the entered book details as a <see cref="BookTableEntry"/>.
    /// </param>
    public void ShowPopup(string title, string author, string genre, Action<BookTableEntry> onPopupClosed)
    {
        var popupWindow = new AddBookPopupWindow();
        var popupViewModel = new AddBookPopupWindowViewModel(title, author, genre, input =>
        {
            popupWindow.DialogResult = true;
            popupWindow.Close();
            onPopupClosed(input);
        });

        popupWindow.DataContext = popupViewModel;
        popupWindow.ShowDialog();
    }
}
