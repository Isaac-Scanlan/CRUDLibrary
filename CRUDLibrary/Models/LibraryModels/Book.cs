using CRUDLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.Models.LibraryModels;

public record Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public BookStatus status {get; set;}
    public DateTime PublicationDate { get; set; }

    public ICollection<Loan> Loans { get; set; }
}
