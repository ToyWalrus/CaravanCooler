using HarmonyLib;
using Verse;
using RimWorld;

namespace CaravanCooler
{
    [HarmonyPatch(typeof(Dialog_FormCaravan))]
    [HarmonyPatch("MostFoodWillRotSoon", MethodType.Getter)]
    public static class FormCaravanWarning
    {
        [HarmonyPostfix]
        public static void WillFoodRot(Dialog_FormCaravan __instance, ref bool __result)
        {
            __result = CaravanCooler.WillFoodRot(__instance.transferables);
        }
    }

    public static class CaravanFormingWindowUtility
    {
        // https://github.com/pardeike/Harmony/wiki/Patching
        // https://harmony.pardeike.net/articles/patching-transpiler.html
        // public static void NoRotIfCoolerPresent()
    }
}
