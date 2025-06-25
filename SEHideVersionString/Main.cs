using HarmonyLib;
using System.Reflection;
using VRage.Plugins;

namespace HideVersionString
{
    public class Main : IPlugin
    {     
        public Main()
        {
            Harmony harmony = new Harmony("HideVersionString");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void Dispose()
        {
            
        }
      
        public void Init(object gameInstance)
        { 
            
        }
       
        public void Update()
        {
            
        }
    }
}
