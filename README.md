# testing
A repo used to test things out

## Serilog Version Checker

This repository contains a simple .NET console application that queries the latest version of the Serilog NuGet package.

### Latest Serilog Version

The latest stable version of Serilog is: **4.3.0**

### Usage

To check the latest version of Serilog:

1. Navigate to the SerilogVersionChecker directory:
   ```bash
   cd SerilogVersionChecker
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

### How it works

The application uses the NuGet.Protocol package to query the official NuGet API (https://api.nuget.org/v3/index.json) and retrieve the latest stable version of the Serilog package, excluding pre-release versions.

### Requirements

- .NET 8.0 or later
- Internet connection to access NuGet API
