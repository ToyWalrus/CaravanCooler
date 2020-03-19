using System.Collections.Generic;
using HarmonyLib;
using RimWorld.Planet;
using Verse;
using System;

namespace CaravanCooler
{
    [HarmonyPatch(typeof(DaysUntilRotCalculator))]
    [HarmonyPatch("ApproxDaysUntilRot", new Type[] {typeof(List<Thing>), typeof(int), typeof(WorldPath), typeof(float), typeof(int)})]
    public static class WorldCaravanInfo
    {
        [HarmonyPostfix]
        public static void ApproxDaysUntilRot(List<Thing> caravanItems, ref float __result)
        {
            for (int i = 0; i < caravanItems.Count; ++i)
            {
                if (caravanItems[i].def == CaravanCoolerDefOf.CaravanCooler)
                {
                    __result = float.PositiveInfinity;
                    return;
                }
            }
        }
    }
}
