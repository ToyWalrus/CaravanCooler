using HarmonyLib;
using System.Reflection;
using Verse;

namespace CaravanCooler
{
    [StaticConstructorOnStartup]
    public class CaravanCooler
    {
        static CaravanCooler()
        {
            var harmony = new Harmony("com.github.toywalrus.caravancooler");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.Message("Caravan cooler init");
        }
    }
}