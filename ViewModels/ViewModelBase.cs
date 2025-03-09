using System.ComponentModel;
namespace CRUDLibrary.ViewModels;

/// <summary>
/// Serves as a base class for all ViewModels, providing property change notifications.
/// Implements <see cref="INotifyPropertyChanged"/> to support data binding.
/// </summary>
public class ViewModelBase : INotifyPropertyChanged
{
    /// <summary>
    /// Occurs when a property value changes.
    /// Used for notifying the UI of changes in bound properties.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Notifies subscribers that a property value has changed.
    /// Triggers the <see cref="PropertyChanged"/> event to update the UI.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
