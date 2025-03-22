using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.ViewModels.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels.BaseViewModels;

/// <summary>
/// A base ViewModel for popup dialogs that collect or edit data and return it to the caller.
/// Intended to be inherited by specific popup implementations (e.g. AddBookPopupViewModel).
/// </summary>
/// <typeparam name="TModel">The core data model type (e.g., Book, Member).</typeparam>
/// <typeparam name="TEntry">The view model or DTO used to bind data within the popup UI.</typeparam>
public abstract class PopupWindowViewModel<TModel, TEntry> : ViewModelBase
{
    /// <summary>
    /// The action to invoke when the popup is submitted. Typically used to pass back a result to the caller and close the popup.
    /// </summary>
    protected readonly Action<TEntry> CloseAction;

    /// <summary>
    /// Initializes a new instance of the <see cref="PopupWindowViewModel{TModel, TEntry}"/> class.
    /// </summary>
    /// <param name="closeAction">
    /// An action to execute when the popup's submission logic completes.
    /// This is usually used to return the completed <typeparamref name="TEntry"/> to the caller and trigger popup closure.
    /// </param>
    protected PopupWindowViewModel(Action<TEntry> closeAction)
    {
        CloseAction = closeAction;

        SubmitCommand = new RelayCommand(Submit);
    }

    /// <summary>
    /// Gets the command that is executed when the user submits the popup (e.g., clicks "OK" or "Save").
    /// </summary>
    public ICommand SubmitCommand { get; }

    /// <summary>
    /// Executes the popup's submission logic and passes the result to the <see cref="CloseAction"/>.
    /// This method must be implemented by derived classes to define how data is collected and finalized.
    /// </summary>
    protected abstract void Submit();
}

