using ModularPipelines.Context;
using ModularPipelines.DotNet;
using ModularPipelines.DotNet.Extensions;
using ModularPipelines.DotNet.Options;
using ModularPipelines.Enums;
using ModularPipelines.Git.Extensions;
using ModularPipelines.Models;
using ModularPipelines.Modules;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Pipeline.Modules;

public class RunUnitTestsModule : Module<List<CommandResult>>
{
    protected override async Task<List<CommandResult>?> ExecuteAsync(IPipelineContext context, CancellationToken cancellationToken)
    {
        var results = new List<CommandResult>();

        foreach (var unitTestProjectFile in context
                     .Git().RootDirectory!
                     .GetFiles(file => file.Path.EndsWith("Tests.csproj", StringComparison.OrdinalIgnoreCase)))
        {
            results.Add(await context.DotNet().Test(new DotNetTestOptions
            {
                ProjectSolutionDirectoryDllExe = unitTestProjectFile.Path,
                CommandLogging = CommandLogging.Input | CommandLogging.Error,
            }, cancellationToken));
        }

        return results;
    }
}
