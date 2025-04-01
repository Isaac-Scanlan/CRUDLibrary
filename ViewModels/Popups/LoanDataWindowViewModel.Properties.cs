using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.ViewModels.Popups;

public partial class LoanDataWindowViewModel
{
    public string NewBook
    {
        get => _book;
        set
        {
            _book = value;
            OnPropertyChanged(nameof(NewBook));
        }
    }

    public string NewBorrower
    {
        get => _borrower;
        set
        {
            _borrower = value;
            OnPropertyChanged(nameof(NewBorrower));
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
