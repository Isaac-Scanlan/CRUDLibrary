using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.ViewModels.Inventory;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.ViewModels.Loans;

public class LoanTableEntry : IEquatable<LoanTableEntry>
{
    public string Book { get; set; } = string.Empty;

    public string Borrower { get; set; } = string.Empty;

    public string LoanID { get; set; } = string.Empty;

    public string LoanDate { get; set; } = string.Empty;

    public string DueDate { get; set; } = string.Empty;

    public string ReturnDate { get; set; } = string.Empty;

    /// <summary>
    /// Converts a <see cref="Book"/> object into a <see cref="BookTableEntry"/>.
    /// </summary>
    /// <param name="loan">The loan to convert.</param>
    /// <returns>A new instance of <see cref="BookTableEntry"/> populated with loan details.</returns>
    public static LoanTableEntry ToLoanTableEntry(Loan loan)
    {
        var name = loan.Borrower is null ? "------" : loan.Borrower.Name;
        return new LoanTableEntry
        {
            Book = loan.Book.Title ,
            Borrower = name,
            LoanID = loan.LoanID.ToString() ,
            LoanDate = loan.LoanDate.ToString() ,
            DueDate = loan.DueDate.ToString() ,
            ReturnDate = loan.ReturnDate.ToString() ?? " - - - "
        };
    }

    /// <summary>
    /// Converts a list of <see cref="Loan"/> objects into <see cref="BookTableEntry"/> objects
    /// and adds them to the specified <see cref="ObservableCollection{BookTableEntry}"/>.
    /// </summary>
    /// <param name="loans">The list of loans to convert.</param>
    /// <param name="table">The collection to which the converted entries will be added.</param>
    public static void ToLoanTableEntry(List<Loan> loans, ObservableCollection<LoanTableEntry> table)
    {
        foreach (var loan in loans)
        {
            table.Add(ToLoanTableEntry(loan));
        }
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is BookTableEntry other && Equals(other);
    }

    /// <summary>
    /// Determines whether the specified <see cref="BookTableEntry"/> is equal to the current instance.
    /// </summary>
    /// <param name="other">The loan entry to compare with the current instance.</param>
    /// <returns><c>true</c> if both loan entries are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(LoanTableEntry? other)
    {
        if (other is null)
        {
            return false;
        }
        
        return Book == other.Book &&
               Borrower == other.Borrower &&
               LoanID == other.LoanID &&
               LoanDate == other.LoanDate &&
               DueDate == other.DueDate &&
               ReturnDate == other.ReturnDate;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Book, Borrower, LoanID, LoanDate, DueDate, ReturnDate);
    }

}
