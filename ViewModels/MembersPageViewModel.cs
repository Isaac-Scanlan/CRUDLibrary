using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Models.Enums;
using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels;

/// <summary>
/// ViewModel for managing the members page of the library system.
/// Handles member searching, adding, editing, and deleting operations.
/// </summary>
public partial class MembersPageViewModel : ViewModelBase
{
    private string _member;
    private MemberTableEntry? _memberTableEntry;
    private MemberTableEntry _selectedMember;
    private readonly IWindowService _windowService;
    private readonly LibraryService _libraryService;
    private ObservableCollection<MemberTableEntry> _memberTableCollection;

    /// <summary>
    /// Command for searching books in the library.
    /// </summary>
    public ICommand SearchMemberCommand { get; }

    /// <summary>
    /// Command for opening the add book popup.
    /// </summary>
    public ICommand AddMemberCommand { get; }

    /// <summary>
    /// Command for opening the edit book popup.
    /// </summary>
    public ICommand EditMemberCommand { get; }

    /// <summary>
    /// Command for deleting a selected book entry.
    /// </summary>
    public ICommand DeleteMemberCommand { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MembersPageViewModel"/> class.
    /// </summary>
    /// <param name="windowService">Service for managing windows and popups.</param>
    public MembersPageViewModel(IWindowService windowService)
    {
        _windowService = windowService;
        if (App.ServiceProvider is not null)
        {
            _libraryService = App.ServiceProvider.GetRequiredService<LibraryService>();
        }
        else
        {
            throw new InvalidOperationException("ServiceProvider has not been initialised.");
        }

        _memberTableCollection = [];
        _member = string.Empty;
        _selectedMember = MemberTableEntry.Empty;
        _memberTableEntry = MemberTableEntry.Empty;

        //SearchMemberCommand = new AsyncRelayCommand(SearchBooksAsync);
        AddMemberCommand = new AsyncRelayCommand(AddNewMember);
        //EditMemberCommand = new AsyncRelayCommand(EditBookInfo);
        //DeleteMemberCommand = new AsyncRelayCommand(RemoveBook);

        

        MemberTableEntry.ToMemberTableEntry(_libraryService.GetMembersAsync().Result, _memberTableCollection);
    }

    /// <summary>
    /// Opens a popup for adding or editing a book.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="author">The author of the book.</param>
    /// <param name="genre">The genre of the book.</param>
    private void OpenPopup(string title, string author, string genre)
    {
        _windowService.ShowMemberPopup(title, author, genre, result =>
        {
            NewBookTableEntry = result;
        });
    }

    /// <summary>
    /// Adds a new book to the inventory.
    /// </summary>
    private async Task AddNewMember()
    {
        OpenPopup(string.Empty, string.Empty, string.Empty);

        if (NewBookTableEntry is null)
        {
            return;
        }
    }

    private async Task AddDBData()
    {
        var members = new List<LibraryMember>
        {
            new LibraryMember { Id = 1, Name = "John Brady", Email = "johnbrady@gmail.com", PhoneNumber = "1234567890", LoanHistory = [] },
            new LibraryMember { Id = 2, Name = "Emily Stone", Email = "emilystone@yahoo.com", PhoneNumber = "9876543210", LoanHistory = [] },
            new LibraryMember { Id = 3, Name = "Michael Carter", Email = "michaelc@gmail.com", PhoneNumber = "5551234567", LoanHistory = [] },
            new LibraryMember { Id = 4, Name = "Sophia Lee", Email = "sophialee@hotmail.com", PhoneNumber = "4445556666", LoanHistory = [] },
            new LibraryMember { Id = 5, Name = "David Kim", Email = "davidk@live.com", PhoneNumber = "7778889999", LoanHistory = [] },
            new LibraryMember { Id = 6, Name = "Olivia Turner", Email = "oliviaturner@gmail.com", PhoneNumber = "1122334455", LoanHistory = [] },
            new LibraryMember { Id = 7, Name = "James Brown", Email = "jamesb@outlook.com", PhoneNumber = "6677889900", LoanHistory = [] },
            new LibraryMember { Id = 8, Name = "Isabella Moore", Email = "isabellam@aol.com", PhoneNumber = "1231231234", LoanHistory = [] },
            new LibraryMember { Id = 9, Name = "Liam Wilson", Email = "liamwilson@protonmail.com", PhoneNumber = "3213214321", LoanHistory = [] },
            new LibraryMember { Id = 10, Name = "Mia Johnson", Email = "mia.johnson@gmail.com", PhoneNumber = "9998887777", LoanHistory = [] },
            new LibraryMember { Id = 11, Name = "Noah Davis", Email = "noahdavis@yahoo.com", PhoneNumber = "8887776666", LoanHistory = [] },
            new LibraryMember { Id = 12, Name = "Ava Martinez", Email = "ava_martinez@hotmail.com", PhoneNumber = "1010101010", LoanHistory = [] },
            new LibraryMember { Id = 13, Name = "William Garcia", Email = "willg@librarymail.com", PhoneNumber = "2020202020", LoanHistory = [] },
            new LibraryMember { Id = 14, Name = "Charlotte Hall", Email = "charlotte.hall@live.com", PhoneNumber = "3030303030", LoanHistory = [] },
            new LibraryMember { Id = 15, Name = "Benjamin Walker", Email = "ben.walker@gmail.com", PhoneNumber = "4040404040", LoanHistory = [] }
        };

        foreach (var member in members)
        {
            await _libraryService.AddMemberAsync(member);
        }
    }
}
