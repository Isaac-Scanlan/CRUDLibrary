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
    /// Gets or sets the collection of Members displayed in the Members table.
    /// Notifies the UI when the collection is updated.
    /// </summary>
    public ObservableCollection<MemberTableEntry> MemberTableCollection
    {
        get => _memberTableCollection;
        set
        {
            _memberTableCollection = value;
            OnPropertyChanged(nameof(MemberTableCollection));
        }
    }

    /// <summary>
    /// Gets or sets the new book entry created via the popup.
    /// Notifies the UI when the value changes.
    /// </summary>
    public MemberTableEntry? NewMemberTableEntry
    {
        get => _memberTableEntry;
        set
        {
            _memberTableEntry = value;
            OnPropertyChanged(nameof(NewMemberTableEntry));
        }
    }

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

    /// <summary>
    /// Gets or sets the currently selected book in the inventory table.
    /// Notifies the UI when the selected book changes.
    /// </summary>
    public MemberTableEntry SelectedMember
    {
        get => _selectedMember;
        set
        {
            _selectedMember = value;
            OnPropertyChanged(nameof(SelectedMember));
        }
    }
}
