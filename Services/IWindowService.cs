using CRUDLibrary.ViewModels;
using CRUDLibrary.ViewModels.Inventory;
using CRUDLibrary.ViewModels.Loans;
using CRUDLibrary.ViewModels.Members;

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
    void ShowBookPopup(string title, string author, string genre, Action<BookTableEntry> onPopupClosed);

    /// <summary>
    /// Displays a popup window for entering member details.
    /// </summary>
    /// <param name="name">The pre-filled title of the member.</param>
    /// <param name="email">The pre-filled author of the member.</param>
    /// <param name="phoneNumber">The pre-filled genre of the member.</param>
    /// <param name="onPopupClosed">
    /// A callback function that is invoked when the popup closes,
    /// returning the member details as a <see cref="MemberTableEntry"/>.
    /// </param>
    void ShowMemberPopup(string name, string email, string phoneNumber, Action<MemberTableEntry> onPopupClosed);

    void ShowLoansPopup(string book, string member, Action<LoanTableEntry> onPopupClosed);
}

