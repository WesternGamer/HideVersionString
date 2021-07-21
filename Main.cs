using HarmonyLib;
using Sandbox.Game;
using System.Reflection;
using VRage.Plugins;

namespace HideVersionString
{
    public class Main : IPlugin
    {     
        public void Startup()
        {
            
        }

        public void Dispose()
        {
            
        }
      
        public void Init(object gameInstance)
        { 
            Harmony harmony = new Harmony("SEPluginTemplate");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            MyPerGameSettings.GUI.MainMenu = typeof(MyCustomMainMenu);
        }
       
        public void Update()
        {
            
        }
    }
}
