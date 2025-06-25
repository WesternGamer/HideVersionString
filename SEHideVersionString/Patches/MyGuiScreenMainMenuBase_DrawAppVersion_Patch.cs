using HarmonyLib;
using Sandbox.Game.Screens;

namespace HideVersionString.Patches
{
    [HarmonyPatch(typeof(MyGuiScreenMainMenuBase), "DrawAppVersion")]
    internal class MyGuiScreenMainMenuBase_DrawAppVersion_Patch
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}