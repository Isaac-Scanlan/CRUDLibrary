using CRUDLibrary.ViewModels;

namespace CRUDLibrary.Services;

/// <summary>
/// Defines a service for displaying a popup window and returning user input.
/// </summary>
public interface IWindowService
{
    /// <summary>
    /// Displays a popup window for entering book details.
    /// </summary>
    /// <param name="title">The pre-filled title of the book.</param>
    /// <param name="author">The pre-filled author of the book.</param>
    /// <param name="genre">The pre-filled genre of the book.</param>
    /// <param name="onPopupClosed">
    /// A callback function that is invoked when the popup closes,
    /// returning the book details as a <see cref="BookTableEntry"/>.
    /// </param>
    void ShowPopup(string title, string author, string genre, Action<BookTableEntry> onPopupClosed);
}

