using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels;

/// <summary>
/// Represents the ViewModel for the Add Member Popup Window.
/// Handles user input and submission of new book details.
/// </summary>
public partial class MemberDataWindowViewModel : ViewModelBase
{
    /// <summary>
    /// Gets the command that submits the new member details.
    /// </summary>
    public ICommand SubmitCommand { get; }

    private readonly Action<MemberTableEntry> _closeAction;
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
    /// <param name="closeAction">An action that is invoked when the popup is closed, returning a <see cref="BookTableEntry"/>.</param>
    public MemberDataWindowViewModel(string name, string email, string phoneNumber, Action<MemberTableEntry> closeAction)
    {
        _newName = name;
        _newEmail = email;
        _newPhoneNumber = phoneNumber;
        _newId = string.Empty;

        _closeAction = closeAction;
        SubmitCommand = new RelayCommand(Submit);
    }

    /// <summary>
    /// Submits the book details and invokes the close action with a new <see cref="BookTableEntry"/>.
    /// </summary>
    private void Submit()
    {
        _closeAction.Invoke(new MemberTableEntry
        {
            Name = NewName,
            Email = NewEmail,
            PhoneNumber = NewPhoneNumber,
            Id = NewId,
        });
    }
}
