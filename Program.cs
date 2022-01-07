using System.CommandLine;

// Create some options:
var intOption = new Option<int>(
        "--int-option",
        getDefaultValue: () => 42,
        description: "An option whose argument is parsed as an int");
var boolOption = new Option<bool>(
        "--bool-option",
        "An option whose argument is parsed as a bool");
var fileOption = new Option<FileInfo>(
        "--file-option",
        "An option whose argument is parsed as a FileInfo");

// Add the options to a root command:
var rootCommand = new RootCommand
{
    intOption,
    boolOption,
    fileOption
};

rootCommand.Description = "My sample app";

rootCommand.SetHandler((int i, bool b, FileInfo f) =>
{
    Console.WriteLine($"The value for --int-option is: {i}");
    Console.WriteLine($"The value for --bool-option is: {b}");
    Console.WriteLine($"The value for --file-option is: {f?.FullName ?? "null"}");
}, intOption, boolOption, fileOption);

// Parse the incoming args and invoke the handler
return rootCommand.Invoke(args);
