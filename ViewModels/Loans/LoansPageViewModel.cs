using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.Services;
using CRUDLibrary.ViewModels.BaseViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Formats.Tar;

namespace CRUDLibrary.ViewModels.Loans;

public partial class LoansPageViewModel : CrudPageViewModel<Loan, LoanTableEntry>
{
    private string _loanedBook { get; set; }

    private List<string> _booksList;
    private List<string> _membersList;

    private ILogger<LoansPageViewModel> _logger;


    public LoansPageViewModel(ILogger<LoansPageViewModel> logger, IWindowService windowService, LibraryService libraryService) 
        : base(windowService, libraryService)
    {
        _logger = logger;
        _booksList = [];
        _membersList = [];
    }

    /// <summary>
    /// Initializes the ViewModel by loading the initial book collection.
    /// </summary>
    public async Task InitializeAsync()
    {
        await ReloadLoansCollectionAsync();
    }

    private void OpenPopup(string bookName, string member)
    {
        _windowService.ShowLoansPopup(bookName, member, BooksList, MembersList, result =>
        {
            NewEntry = result;
        });
    }

    /// <inheritdoc/>
    protected override async Task AddAsync()
    {
        while (true)
        {
            OpenPopup(string.Empty, string.Empty);

            if (NewEntry is null || NewEntry.Equals(new LoanTableEntry()))
            {
                return;
            }

            var book = (await _libraryService.GetBooksNameExactlyAsync(NewEntry.Book)).FirstOrDefault();
            var member = (await _libraryService.GetMemberNameExactlyAsync(NewEntry.Borrower)).FirstOrDefault();
            var loansCout = (await _libraryService.GetLoansAsync()).Count;

            if (member is null || book is null)
            {
                continue;
            }

            if (book.Loans.Count > 0)
            {
                var lastLoan = book.Loans.LastOrDefault().ReturnDate;

                if (lastLoan == null)
                {
                    continue;
                }
            }

            var newLoan = new Loan()
            {
                BookID = book.Id,
                Book = book,
                BorrowerID = member.Id,
                Borrower = member,
                LoanDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(7),
            };

            await _libraryService.AddLoanAsync(newLoan);

            await _libraryService.SaveChanges();
            await ReloadLoansCollectionAsync();
            break;
        }
    }

    /// <inheritdoc/>
    protected override async Task DeleteAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    protected override async Task EditAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    protected override async Task SearchAsync()
    {
        var loanResults = await _libraryService.GetLoansByBookName(LoanedBook);
        Table.Clear();

        LoanTableEntry.ToLoanTableEntry(loanResults, Table);
    }

    /// <summary>
    /// Reloads the book collection from the library service.
    /// </summary>
    private async Task ReloadLoansCollectionAsync()
    {
        Table.Clear();

        LoanTableEntry.ToLoanTableEntry(await _libraryService.GetLoansAsync(), Table);

        var foo = await _libraryService.GetBooksAsync();
        var foo2 = foo.Select(p => p.Title);
        BookList.AddRange(foo2);

        MemberList.AddRange(
            (await _libraryService.GetMembersAsync()).Select(p => p.Name)
            );
    }
}
