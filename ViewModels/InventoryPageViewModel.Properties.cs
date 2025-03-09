using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CRUDLibrary.Models.Enums;
using System.Collections.ObjectModel;

namespace CRUDLibrary.ViewModels;

public partial class InventoryPageViewModel
{
    /// <summary>
    /// Gets or sets the collection of book entries displayed in the inventory table.
    /// Notifies the UI when the collection is updated.
    /// </summary>
    public ObservableCollection<BookTableEntry> BookTableCollection
    {
        get => _bookTableCollection;
        set
        {
            _bookTableCollection = value;
            OnPropertyChanged(nameof(BookTableCollection));
        }
    }

    /// <summary>
    /// Gets or sets the new book entry created via the popup.
    /// Notifies the UI when the value changes.
    /// </summary>
    public BookTableEntry? NewBookTableEntry
    {
        get => _bookTableEntry;
        set
        {
            _bookTableEntry = value;
            OnPropertyChanged(nameof(NewBookTableEntry));
        }
    }

    /// <summary>
    /// Gets or sets the search query for filtering books.
    /// Notifies the UI when the value changes.
    /// </summary>
    public string Book
    {
        get => _book;
        set
        {
            _book = value;
            OnPropertyChanged(nameof(Book));
        }
    }

    /// <summary>
    /// Gets or sets the currently selected book in the inventory table.
    /// Notifies the UI when the selected book changes.
    /// </summary>
    public BookTableEntry SelectedBook
    {
        get => _selectedBook;
        set
        {
            _selectedBook = value;
            OnPropertyChanged(nameof(SelectedBook));
        }
    }

    /// <summary>
    /// A dictionary mapping string representations of genres to their corresponding <see cref="BookGenre"/> enum values.
    /// Used for converting genre names from user input into the correct enumeration type.
    /// </summary>
    private Dictionary<string, BookGenre> genres = new()
    {
        {"Fiction", BookGenre.Fiction},
        {"NonFiction", BookGenre.NonFiction},
        {"Children", BookGenre.Children},
        {"GraphicNovel", BookGenre.GraphicNovel},
        {"Advice", BookGenre.Advice},
        {"Business", BookGenre.Business},
        {"Fitness", BookGenre.Fitness},
        {"Science", BookGenre.Science},
        {"Travel", BookGenre.Travel},
        {"Fantasy", BookGenre.Fantasy},
        {"Dystopian", BookGenre.Dystopian},
        {"Classic", BookGenre.Classic},
        {"Romance", BookGenre.Romance},
        {"Adventure", BookGenre.Adventure},
        {"Historical", BookGenre.Historical},
        {"Gothic", BookGenre.Gothic},
        {"Thriller", BookGenre.Thriller},
        {"Horror", BookGenre.Horror},
    };
}
