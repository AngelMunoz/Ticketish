# Ticketish


Don't forget to add `appsettings.Development.json` with your connection string next to the `appsettings.json` file
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "ConnectionStrings": {
    "ConnectionStr": "Server=localhost;database=tck_tickets;uid=root;pwd=Admin123;"
  }
}
```
- `cd ExoInvento`
- `dotnet restore`
- `dotnet run`
