using HarmonyLib;
using Oxide.Core;
using Oxide.Core.Plugins;
using Rust.Platform.Steam;
using Steamworks;

namespace Oxide.Plugins
{
    [Info("SteamReconnect", "aced", "1.0.1")]
    [Description("If the server loses connection to Steam, it will reconnect.")]
    public class SteamReconnect : RustPlugin
    {
        [AutoPatch]
        [HarmonyPatch(typeof(SteamPlatform), "OnSteamConnectionFailure")]
        public static class ReconnectPatch
        {
            [HarmonyPostfix]
            public static void PostFix(ref bool stilltrying)
            {
                if (stilltrying == false)
                {
                    Interface.Oxide.GetLibrary<Oxide.Core.Libraries.Timer>().Repeat(30f, 0, SteamServer.LogOnAnonymous);
                }
            }
        }
    }
}
