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
}
