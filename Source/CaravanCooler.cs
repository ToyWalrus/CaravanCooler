using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Collections.Generic;

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

        public static bool WillFoodRot(List<TransferableOneWay> items)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                TransferableOneWay item = items[i];
                if (item.CountToTransfer > 0 && item.ThingDef == CaravanCoolerDefOf.CaravanCooler)
                {
                    return false;
                }
            }
            return true;
        }
    }
}