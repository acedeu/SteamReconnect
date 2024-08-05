using JetBrains.Annotations;
using Oxide.Core.Plugins;
using Steamworks;

namespace Oxide.Plugins
{
    [Info("SteamReconnect", "aced", "1.0.0")]
    [Description("If the server loses connection to Steam, it will attempt to reconnect every 60 seconds.")]
    public class SteamReconnect : RustPlugin
    {
        [UsedImplicitly]
        [HookMethod(nameof(Init))]
        private void Init()
        {
            timer.Every(60f, () =>
            {
                if (SteamServer.LoggedOn == false)
                {
                    SteamServer.LogOnAnonymous();
                }
            });
        }
    }
}