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
    public void ShowBookPopup(string title, string author, string genre, Action<BookTableEntry> onPopupClosed)
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

    /// <summary>
    /// Displays a popup window for entering member details and returns the entered data upon closing.
    /// </summary>
    /// <param name="name">The pre-filled title of the member.</param>
    /// <param name="email">The pre-filled author of the member.</param>
    /// <param name="phoneNumber">The pre-filled genre of the member.</param>
    /// <param name="onPopupClosed">
    /// A callback function that is invoked when the popup closes,
    /// returning the entered member details as a <see cref="MemberTableEntry"/>.
    /// </param>
    public void ShowMemberPopup(string name, string email, string phoneNumber, Action<MemberTableEntry> onPopupClosed)
    {
        var popupWindow = new MemberDataWindow();
        var popupViewModel = new MemberDataWindowViewModel(name, email, phoneNumber, input =>
        {
            popupWindow.DialogResult = true;
            popupWindow.Close();
            onPopupClosed(input);
        });

        popupWindow.DataContext = popupViewModel;
        popupWindow.ShowDialog();
    }
}
