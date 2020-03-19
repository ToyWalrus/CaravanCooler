using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld.Planet;
using Verse;
using System;
using RimWorld;

namespace CaravanCooler
{
    [HarmonyPatch(typeof(DaysUntilRotCalculator))]
    [HarmonyPatch("ApproxDaysUntilRot", new Type[] {typeof(List<Thing>), typeof(int), typeof(WorldPath), typeof(float), typeof(int)})]
    public static class WorldCaravanInfo
    {
        [HarmonyPostfix]
        public static void NoRotIfCoolerPresent(List<Thing> potentiallyFood, ref float __result)
        {
            if (CaravanCooler.HasCoolerInListOfThings(potentiallyFood))
            {
                __result = float.PositiveInfinity;
            }
        }
    }

    [HarmonyPatch(typeof(Caravan))]
    [HarmonyPatch("Tick")]
    public static class WorldCaravanTick
    {        
        [HarmonyPostfix]
        static void SetRotValuesToZero(Caravan __instance)
        {
            if (CaravanCooler.HasCoolerInListOfThings(__instance.AllThings.ToList()))
            {
                List<Thing> items = __instance.AllThings.ToList();
                for (int i = 0; i < items.Count; ++i)
                {
                    CompRottable comp = items[i].TryGetComp<CompRottable>();
                    if (comp != null)
                    {
                        comp.RotProgress = 0;
                    }
                }
            }
        }
    }
}
