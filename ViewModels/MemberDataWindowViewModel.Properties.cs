using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.ViewModels;

public partial class MemberDataWindowViewModel
{
    /// <summary>
    /// Gets or sets the title of the new book.
    /// </summary>
    public string NewName
    {
        get => _newName;
        set
        {
            _newName = value;
            OnPropertyChanged(nameof(NewName));
        }
    }

    /// <summary>
    /// Gets or sets the author of the new book.
    /// </summary>
    public string NewEmail
    {
        get => _newEmail;
        set
        {
            _newEmail = value;
            OnPropertyChanged(nameof(NewEmail));
        }
    }

    /// <summary>
    /// Gets or sets the genre of the new book.
    /// </summary>
    public string NewPhoneNumber
    {
        get => _newPhoneNumber;
        set
        {
            _newPhoneNumber = value;
            OnPropertyChanged(nameof(NewPhoneNumber));
        }
    }

    /// <summary>
    /// Gets or sets the unique identifier of the new book.
    /// </summary>
    public string NewId
    {
        get => _newId;
        set
        {
            _newId = value;
            OnPropertyChanged(nameof(NewId));
        }
    }
}
