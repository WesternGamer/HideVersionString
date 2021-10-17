using HarmonyLib;
using Sandbox.Engine.Networking;
using Sandbox.Game.Screens;
using Sandbox.Graphics.GUI;
using System;
using System.Reflection;
using VRage.Game;
using VRage.Utils;
using VRageMath;

namespace HideVersionString.Patches
{
    [HarmonyPatch(typeof(MyGuiScreenMainMenuBase), "DrawAppVersion")]
    internal class Patch_DrawAppVersion
    {
        private static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch]
    internal class Patch_RecreateControls
    {
        private static MyGuiControlLabel m_versionLabel;
        private static void Postfix(MyGuiScreenBase __instance, Vector2? ___m_size)
        {
            m_versionLabel = new MyGuiControlLabel(new Vector2(-1.73f, 0.93f) * ___m_size.Value, null, "Version: " + MyFinalBuildConstants.APP_VERSION_STRING_DOTS.ToString() + " Branch: " + MyGameService.BranchName, null, 0.8f, "Blue", MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_CENTER);
            __instance.Controls.Add(m_versionLabel);
        }

        private static MethodBase TargetMethod()
        {
            Type type = Type.GetType("SpaceEngineers.Game.GUI.MyGuiScreenOptionsSpace, SpaceEngineers.Game");
            var method = type.GetMethod("RecreateControls");
            return method;
        }
    }
}