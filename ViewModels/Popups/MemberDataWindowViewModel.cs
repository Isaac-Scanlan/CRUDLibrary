using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.ViewModels.BaseViewModels;
using CRUDLibrary.ViewModels.Members;
using System.Formats.Tar;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels.Popups;

/// <summary>
/// Represents the ViewModel for the Add Member Popup Window.
/// Handles user input and submission of new book details.
/// </summary>
public partial class MemberDataWindowViewModel : PopupWindowViewModel<LibraryMember, MemberTableEntry>
{
    private string _newName;
    private string _newEmail;
    private string _newPhoneNumber;
    private string _newId;

    /// <summary>
    /// Initializes a new instance of the <see cref="MemberDataWindowViewModel"/> class.
    /// </summary>
    /// <param name="name">The initial name of the member.</param>
    /// <param name="email">The initial email of the member.</param>
    /// <param name="phoneNumber">The initial phoneNumber of the member.</param>
    /// <param name="closeAction">An action that is invoked when the popup is closed, returning a <see cref="MemberTableEntry"/>.</param>
    public MemberDataWindowViewModel(string name, string email, string phoneNumber, Action<MemberTableEntry> closeAction) : 
        base(closeAction)
    {
        _newName = name;
        _newEmail = email;
        _newPhoneNumber = phoneNumber;
        _newId = string.Empty;
    }

    /// <summary>
    /// Submits the book details and invokes the close action with a new <see cref="MemberTableEntry"/>.
    /// </summary>
    protected override void Submit()
    {
        CloseAction.Invoke(new MemberTableEntry
        {
            Name = NewName,
            Email = NewEmail,
            PhoneNumber = NewPhoneNumber,
            Id = NewId,
        });
    }
}
