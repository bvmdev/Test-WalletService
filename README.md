# Test-WalletService - v.1.0.0

# Pre-Req

.Net Runtime 8.0
.Net SDK 8.0

# Running Entries API

Open de the terminal
Navigate to WalletService Directory (/src)
Run dotnet restore
Run dotnet build
Run dotnet run

Access the swagger UI from http://localhost:PORT/swagger (port is yout output dotnet run listening on)

Endpoints:

POST /api/entry: Add new Entry
GET /api/entryType: Get Entry Types to use in POST Route


# Running Unit Tests

Open de the terminal

Navigate to UnitTests Directory (/Tests/UnitTests)

Run dotnet restore

Run dotnet build

Run dotnet test
