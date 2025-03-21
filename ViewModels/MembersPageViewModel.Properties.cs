using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.ViewModels;

public partial class MembersPageViewModel
{
    /// <summary>
    /// Gets or sets the search query for filtering books.
    /// Notifies the UI when the value changes.
    /// </summary>
    public string Member
    {
        get => _member;
        set
        {
            _member = value;
            OnPropertyChanged(nameof(Member));
        }
    }
}
