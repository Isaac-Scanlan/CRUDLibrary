using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.Services;
using CRUDLibrary.ViewModels.BaseViewModels;
using CRUDLibrary.ViewModels.Inventory;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.ViewModels.Loans;

public partial class LoansPageViewModel : CrudPageViewModel<Loan, LoanTableEntry>
{
    private string _loanedBook { get; set; }

    private ILogger<LoansPageViewModel> _logger;

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


    public LoansPageViewModel(ILogger<LoansPageViewModel> logger, IWindowService windowService, LibraryService libraryService) 
        : base(windowService, libraryService)
    {
        _logger = logger;

        
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
        _windowService.ShowLoansPopup(bookName, member, result =>
        {
            NewEntry = result;
        });
    }

    /// <inheritdoc/>
    protected override async Task AddAsync()
    {
        OpenPopup(string.Empty, string.Empty);

        if (NewEntry is null)
        {
            return;
        }

        var loanResults = await _libraryService.GetLoansAsync();
        var members = await _libraryService.GetMembersAsync();

        List<Loan> loans = new List<Loan>();

        for (int i = 0; i < members.Count; i++)
        {


        }

        await _libraryService.SaveChanges();

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

        var loans = await _libraryService.GetLoansAsync();
        LoanTableEntry.ToLoanTableEntry(loans, Table);
    }
}
