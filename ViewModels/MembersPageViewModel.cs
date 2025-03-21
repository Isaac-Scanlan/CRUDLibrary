using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Models.Enums;
using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
public partial class MembersPageViewModel : CrudPageViewModel<LibraryMember, MemberTableEntry>
{
    private string _member;

    private ILogger<InventoryPageViewModel> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MembersPageViewModel"/> class.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="windowService">Service for managing windows and popups.</param>
    /// <param name="libraryService"></param>
    public MembersPageViewModel(ILogger<InventoryPageViewModel> logger, IWindowService windowService, LibraryService libraryService)
        : base(windowService, libraryService)
    {
        _logger = logger;

        _member = string.Empty;
        SelectedEntry = null;
        NewEntry = null;
    }

    /// <summary>
    /// Initializes the ViewModel by loading the initial book collection.
    /// </summary>
    public async Task InitializeAsync()
    {
        await ReloadMemberCollectionAsync();
    }

    /// <summary>
    /// Opens a popup for adding or editing a book.
    /// </summary>
    /// <param name="name">The name of the book.</param>
    /// <param name="email">The email of the book.</param>
    /// <param name="phoneNumber">The phoneNumber of the book.</param>
    private void OpenPopup(string name, string email, string phoneNumber)
    {
        _windowService.ShowMemberPopup(name, email, phoneNumber, result =>
        {
            NewEntry = result;
        });
    }

    /// <inheritdoc/>
    protected override async Task AddAsync()
    {
        OpenPopup(string.Empty, string.Empty, string.Empty);

        if (NewEntry is null)
        {
            return;
        }

        int newId = Table.Any()
            ? Table.Max(entry => int.Parse(entry.Id)) + 1
            : 0;

        NewEntry.Id = newId.ToString();
        Table.Add(NewEntry);

        await _libraryService.AddMemberAsync(new LibraryMember
        {
            Id = newId,
            Name = NewEntry.Name,
            Email= NewEntry.Email,
            PhoneNumber = NewEntry.PhoneNumber,
            LoanHistory = []
        });

        await ReloadMemberCollectionAsync();
        NewEntry = null;
    }

    /// <inheritdoc/>
    protected override async Task EditAsync()
    {

        if (SelectedEntry is null || SelectedEntry.Equals(BookTableEntry.Empty))
        {
            return;
        }

        OpenPopup(SelectedEntry.Name, SelectedEntry.Email, SelectedEntry.PhoneNumber);

        if (NewEntry is null)
        {
            return;
        }

        var currentMember = (await _libraryService.GetMembersAsync(int.Parse(SelectedEntry.Id))).FirstOrDefault();

        if (currentMember is null)
        {
            return;
        }


        currentMember.Name = string.IsNullOrWhiteSpace(NewEntry.Name) ? currentMember.Name : NewEntry.Name;
        currentMember.Email = string.IsNullOrWhiteSpace(NewEntry.Email) ? currentMember.Email : NewEntry.Email;
        currentMember.PhoneNumber = string.IsNullOrWhiteSpace(NewEntry.PhoneNumber) ? currentMember.PhoneNumber : NewEntry.PhoneNumber;

        await _libraryService.UpdateMemberAsync(currentMember);
        await ReloadMemberCollectionAsync();

        NewEntry = null;
    }

    /// <inheritdoc/>
    protected override async Task DeleteAsync()
    {

        if (SelectedEntry is null || SelectedEntry.Equals(BookTableEntry.Empty))
        {
            return;
        }

        var currentMember = (await _libraryService.GetMembersAsync(int.Parse(SelectedEntry.Id))).FirstOrDefault();

        if (currentMember is null)
        {
            return;
        }

        await _libraryService.DeleteMemberAsync(currentMember);
        await ReloadMemberCollectionAsync();
    }

    /// <inheritdoc/>
    protected override async Task SearchAsync()
    {

        var memberResults = await _libraryService.GetMemberName(Member);
        Table.Clear();

        MemberTableEntry.ToMemberTableEntry(memberResults, Table);

    }

    /// <summary>
    /// Reloads the book collection from the library service.
    /// </summary>
    private async Task ReloadMemberCollectionAsync()
    {
        Table.Clear();

        var members = await _libraryService.GetMembersAsync();
        MemberTableEntry.ToMemberTableEntry(members, Table);
    }
}
