namespace CRUDLibrary.Models.Enums;

/// <summary>
/// Represents the current status of a book in the library.
/// </summary>
public enum BookStatus
{
    /// <summary>
    /// The book is available for borrowing.
    /// </summary>
    Available,

    /// <summary>
    /// The book is reserved by a library member and cannot be borrowed by others.
    /// </summary>
    Reserved,

    /// <summary>
    /// The book is currently checked out by a library member.
    /// </summary>
    Out,

    /// <summary>
    /// The book is overdue and has not been returned by the due date.
    /// </summary>
    Late,

    /// <summary>
    /// The book is reported as lost or missing from the library collection.
    /// </summary>
    Missing
}
