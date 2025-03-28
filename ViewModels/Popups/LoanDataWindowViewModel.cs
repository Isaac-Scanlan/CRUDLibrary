using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.ViewModels.BaseViewModels;
using CRUDLibrary.ViewModels.Inventory;
using CRUDLibrary.ViewModels.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.ViewModels.Popups;

public partial class LoanDataWindowViewModel : PopupWindowViewModel<Loan, LoanTableEntry>
{
    private string _borrower;
    private string _book;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddBookPopupWindowViewModel"/> class.
    /// </summary>
    /// <param name="borrower">The initial borrower of the book.</param>
    /// <param name="book">The initial book of the book.</param>
    /// <param name="genre">The initial genre of the book.</param>
    /// <param name="closeAction">An action that is invoked when the popup is closed, returning a <see cref="BookTableEntry"/>.</param>
    public LoanDataWindowViewModel(string borrower, string book, Action<LoanTableEntry> closeAction)
        : base(closeAction)
    {
        _borrower = borrower;
        _book = book;
    }

    /// <summary>
    /// Submits the book details and invokes the close action with a new <see cref="BookTableEntry"/>.
    /// </summary>
    protected override void Submit()
    {
        CloseAction.Invoke(new LoanTableEntry
        {
            Book = NewBook,
            Borrower = NewBorrower,
        });
    }
}
