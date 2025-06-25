using HarmonyLib;
using System.Reflection;
using System.Windows.Forms;
using VRage.Plugins;

namespace HideVersionString
{
    public class Main : IPlugin
    {     
        public Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
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
