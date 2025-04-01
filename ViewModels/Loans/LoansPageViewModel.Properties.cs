using CRUDLibrary.Models.LibraryModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.ViewModels.Loans;

public partial class LoansPageViewModel
{
    /// <summary>
    /// Gets or sets the search query for filtering loans.
    /// Notifies the UI when the value changes.
    /// </summary>
    public string LoanedBook
    {
        get => _loanedBook;
        set
        {
            _loanedBook = value;
            OnPropertyChanged(nameof(LoanedBook));
        }
    }

    public List<string> BookList
    {
        get => _booksList;
        set
        {
            _booksList = value;
            OnPropertyChanged(nameof(BookList));
        }
    }

    public List<string> MemberList
    {
        get => _membersList;
        set
        {
            _membersList = value;
            OnPropertyChanged(nameof(MemberList));
        }
    }

    public List<string> BooksList
    {
        get => _booksList;
        set
        {
            _booksList = value;
            OnPropertyChanged(nameof(BooksList));
        }
    }

    public List<string> MembersList
    {
        get => _membersList;
        set
        {
            _membersList = value;
            OnPropertyChanged(nameof(MembersList));
        }
    }
}
