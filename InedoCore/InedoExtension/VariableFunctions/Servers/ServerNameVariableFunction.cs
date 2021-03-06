using System.ComponentModel;
using System.Linq;
using Inedo.Extensibility;
using Inedo.Documentation;
using Inedo.Extensibility.VariableFunctions;

namespace Inedo.Extensions.VariableFunctions.Server
{
    [ScriptAlias("ServerName")]
    [Description("name of the current server in context")]
    [Tag("servers")]
    [AppliesTo(InedoProduct.BuildMaster | InedoProduct.Hedgehog | InedoProduct.Otter)]
    public sealed class ServerNameVariableFunction : ScalarVariableFunction
    {
        protected override object EvaluateScalar(IVariableFunctionContext context)
        {
            int? serverId = (context as IStandardContext)?.ServerId;
            if (serverId != null)
                return SDK.GetServers(true).FirstOrDefault(s => s.Id == serverId)?.Name;
            else
                return string.Empty;
        }
    }
}
