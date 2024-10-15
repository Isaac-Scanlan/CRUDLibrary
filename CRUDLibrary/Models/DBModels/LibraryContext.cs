using CRUDLibrary.Models.LibraryModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLibrary.Models.DBModels;

public class LibraryContext: DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Book> Members { get; set; }
    public DbSet<Book> Loans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }
}
