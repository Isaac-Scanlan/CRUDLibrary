using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.Models.LibraryModels;

public record Loan
{
    public int LoanID { get; set; }
    public int BookID { get; set; }
    public int BorrowerID { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Book Book { get; set; }
    public LibraryMember Borrower { get; set; }
}
