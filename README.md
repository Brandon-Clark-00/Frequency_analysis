# Frequency Analysis

Frequency Analysis is a command-line tool that analyzes the frequency of characters in a given text file. It outputs a list of the top 10 most frequently occurring characters and their counts.

## Getting Started

These instructions will guide you through using the Frequency Analysis tool.

## Prerequisites
.NET Core 3.1 SDK
## Installation
Clone the repository
```posh
git clone https://github.com/username/Frequency-Analysis.git
```
In the project directory, run the following command to build the project:
```posh
dotnet build
```

## Usage
### Syntax
```posh
dotnet run <file_path> [<case_sensitive>]
```

file_path: The path of the text file to analyze.
case_sensitive: Optional argument. If set to "false", the analysis will not consider case sensitivity.
### Examples
```posh
dotnet run C:\mydir\input.txt
```

Analyze the frequency of characters in C:\mydir\input.txt, considering case sensitivity.

```posh
dotnet run C:\mydir\input.txt false
```

Analyze the frequency of characters in C:\mydir\input.txt, not considering case sensitivity.

## To do

- [ ] Test on different platforms
- [ ] Use linq to make mapping function cleaner
- [ ] Add more error handling
