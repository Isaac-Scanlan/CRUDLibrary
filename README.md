# 📚 CRUDLibrary

A full-featured WPF desktop application for managing a library's book inventory, members, and loan records. Built using the **MVVM architecture**, **Entity Framework Core**, and **SQLite**, the application demonstrates modern WPF development practices including **dependency injection**, **custom controls**, and **animations**.

---

## ✨ Features

- 📖 **Books Inventory**  
  - Add, edit, delete, and search books
  - Genre, status, and description fields
  - Styled custom `DataGrid` display

- 👥 **Member Management**  
  - Register new members
  - Track members with active loans

- 🔄 **Loan Tracking**
  - Issue and return books
  - Manage due dates and overdue loans

- 🖼️ **Custom Controls**
  - `RoundButton`, `AddButton`, `EditButton`, `ClearableTextBox`, and more
  - All styled via XAML `ResourceDictionaries`

- 📦 **Entity Framework Core (EF Core)**
  - Code-first approach using SQLite database
  - Fully managed migrations with CLI script support

- 🧩 **MVVM + Dependency Injection**
  - Clean separation of UI and logic
  - ViewModels injected via `Microsoft.Extensions.DependencyInjection`

---

## 🛠️ Project Structure

```plaintext
CRUDLibrary/
│
├── Models/                   // Domain models (Book, Loan, Member)
│   ├── DBModels/             // EF Core context and annotations
│
├── Views/                   // WPF pages & controls
│   ├── Controls/            // Custom reusable controls (RoundButton, DisplayTable, etc.)
│   └── Themes/              // XAML style resources
│
├── ViewModels/             // All page-level view models (InventoryPageViewModel, etc.)
├── Services/               // Business logic (LibraryService)
├── Resources/              // Shared resources and converters
│
├── Migrations/             // EF Core migration history
├── App.xaml.cs             // App startup and DI configuration
├── MainWindow.xaml         // Shell container for navigation
└── library.db              // SQLite database file (auto-created)
```

___


## Project progress
[![Login Screen Preview](Images/Login%20Screen.png)](Images/Login%20Screen.png)


### ✅ Completed Milestones

- ✔️ **WPF Project Setup**
  - Initialized project structure with MVVM pattern
  - Configured startup, dependency injection, and main window

- ✔️ **Entity Framework Core Integration**
  - Configured SQLite with `DbContext` and code-first migrations
  - Implemented `Book`, `LibraryMember`, and `Loan` models with proper relationships
  - Setup migration pipeline using CLI & PowerShell script

- ✔️ **Book Inventory Management**
  - Add, edit, delete, and search functionality for books
  - `ObservableCollection` bound to custom `DisplayTable` with 2-way binding
  - Auto-generates unique IDs and syncs changes with database

- ✔️ **Custom WPF Controls**
  - Created reusable components:
    - `RoundButton`
    - `ClearableTextBox`
    - `DisplayTable`
  - Defined styles in XAML resource dictionaries
  - Added interaction logic with animation and styling triggers

- ✔️ **ViewModel Architecture**
  - Built `InventoryPageViewModel` with commands (search, add, edit, delete)
  - Integrated popup handling via `IWindowService` and custom modal windows

### 🔄 In Progress

- Member and loan page logic and styling
- Row selection styling and visual enhancements
- Validation and error handling improvements

### 🧠 Planned

- Implement overdue loan tracking
- Create full loan issuance flow
- Add member registration and filtering
- Export reports (CSV/PDF)

---