using HarmonyLib;
using Sandbox.Game.Screens;


namespace HideVersionString.Utill
{
    internal class MainMenuPatch
    {
         [HarmonyPatch(typeof(MyGuiScreenMainMenuBase), "DrawAppVersion")]
         public class Patch_MainMenu
         {
             
             public static bool Prefix()
             {
                return false;
             }
             
            
             public static void Postfix()
             {
                 
             }
         }
    }
}