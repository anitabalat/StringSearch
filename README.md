# StringSearch

## Prerequisites
[.NET Core 2.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.1)

## Instructions 
Open PowerShell or Windows Command and run the following commands.

### To build/publish: 
`dotnet publish [Project/Solution] -o [Output] -c [Configuration] -r [Runtime]`

Refer to [dotnet publish documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish) for parameter details.

#### Example: 
`dotnet publish C:\Users\anita\source\repos\StringSearch\StringSearch.sln -o C:\Users\anita\Desktop\StringSearch -c Release -r win-x64 `

### To run program: 
`dotnet [DLL Path] [text file] [search file] [search type] [program] [delay] [threads]`
  - #### Arguments
    - text file: file to search through
    - search file: file that contains our search string
    - search type: 1, 2, or 3 (based on your search types)
    - program: 1 for sequential, 2 for threaded, 3 for parallel
    - delay: 0 for no delay, 1 for delay ( this is to do with delay in charcmp)
    - threads: Only necessary for how many threads you want if using Threaded version. Must be minimum of 1
    
#### Example: 
`dotnet C:\Users\anita\Desktop\StringSearch\StringSearch.dll src pat2 1 1 1 1`
 
### To run tests: 
`dotnet vstest [DLL Path]`

#### Example: 
`dotnet vstest C:\Users\anita\Desktop\StringSearch\StringSearchTest.dll`
