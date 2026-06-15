#nullable enable

using System.CommandLine;
using Pika.CLI;
using Pika.CLI.Commands;

var rootCommand = new RootCommand(@"CLI tool for the Pika SDK.");
rootCommand.Options.Add(CliOptions.ApiKey);
rootCommand.Options.Add(CliOptions.BaseUrl);
rootCommand.Options.Add(CliOptions.Json);
rootCommand.Options.Add(CliOptions.Output);
rootCommand.Options.Add(CliOptions.OutputDirectory);
rootCommand.Subcommands.Add(AuthCommand.Create());
rootCommand.Subcommands.Add(AvatarApiGroupCommand.Create());
rootCommand.Subcommands.Add(DeveloperApiGroupCommand.Create());
rootCommand.Subcommands.Add(SessionsApiGroupCommand.Create());
rootCommand.Subcommands.Add(VoiceApiGroupCommand.Create());

return await rootCommand.Parse(args).InvokeAsync().ConfigureAwait(false);