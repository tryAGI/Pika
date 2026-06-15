#nullable enable

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static class DeveloperApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"developer", @"Developer endpoint commands.");
                         command.Subcommands.Add(DeveloperCreateTopupCommandApiCommand.Create());
                         command.Subcommands.Add(DeveloperGetDeveloperBalanceCommandApiCommand.Create());
                         command.Subcommands.Add(DeveloperGetTopupProductsCommandApiCommand.Create());
        return command;
    }
}