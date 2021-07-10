using HarmonyLib;

namespace SolastaDruidClass.Patches
{
    internal static class GameManagerPatcher
    {
        [HarmonyPatch(typeof(GameManager), "BindPostDatabase")]
        internal static class GameManager_BindPostDatabase_Patch
        {
            internal static void Postfix()
            {
                Main.OnGameReady();
            }
        }
    }
}
