using HarmonyLib;
using Verse;
using RimWorld;

namespace CaravanCooler
{
    [HarmonyPatch(typeof(Dialog_FormCaravan))]
    [HarmonyPatch("MostFoodWillRotSoon", MethodType.Getter)]
    public static class CaravanInfoWindowChanges
    {
        [HarmonyPostfix]
        public static void WillFoodRot(Dialog_FormCaravan __instance, ref bool __result)
        {
            Log.Message("Postfix ran!");            
        }
    }
}
