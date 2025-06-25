using HarmonyLib;
using SpaceEngineers.Game.GUI;

namespace HideVersionString.Patches
{
    [HarmonyPatch(typeof(MyGuiScreenOptionsSpace), "RecreateControls")]
    internal class MyGuiScreenOptionsSpace_RecreateControls_Patch
    {
        private static void Postfix(MyGuiScreenOptionsSpace __instance)
        {
            __instance.Controls.Add(new BuildInfoControl());
        }
    }
}
