if ($args.Length -eq 0) {
    Write-Host "Error: You must provide a migration name."
    exit 1
}

$MigrationName = $args[0]

# Add migration with the provided name
dotnet ef migrations add $MigrationName

# Update the database
dotnet ef database update