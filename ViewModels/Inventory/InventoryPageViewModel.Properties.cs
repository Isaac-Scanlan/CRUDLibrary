using CRUDLibrary.Models.Enums;

namespace CRUDLibrary.ViewModels.Inventory;

public partial class InventoryPageViewModel
{
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
