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
        }

        public static bool WillFoodRot(List<TransferableOneWay> items)
        {
            return !HasCoolerInTransferableItems(items);
        }

        public static bool HasCoolerInTransferableItems(List<TransferableOneWay> items)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                TransferableOneWay item = items[i];
                if (item.CountToTransfer > 0 && item.ThingDef == CaravanCoolerDefOf.CaravanCooler)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool HasCoolerInListOfThings(List<Thing> items)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                if (items[i].def == CaravanCoolerDefOf.CaravanCooler)
                {
                    return true;
                }
            }
            return false;
        }
    }
}