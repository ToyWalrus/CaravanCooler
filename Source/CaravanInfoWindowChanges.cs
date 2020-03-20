using HarmonyLib;
using Verse;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;

namespace CaravanCooler
{

    public class CaravanInfo
    {
        public static List<TransferableOneWay> transferables = new List<TransferableOneWay>();
    }

    [HarmonyPatch(typeof(Dialog_FormCaravan))]
    [HarmonyPatch("MostFoodWillRotSoon", MethodType.Getter)]
    public static class FormCaravanWarning
    {
        [HarmonyPostfix]
        public static void WillFoodRot(Dialog_FormCaravan __instance, ref bool __result)
        {
            if (CaravanCooler.HasCoolerInTransferableItems(__instance.transferables))
            {
                __result = false;
            }
        }
    }

    [HarmonyPatch(typeof(Dialog_FormCaravan))]
    [HarmonyPatch("DoWindowContents")]
    public static class FormCaravan_EachFrame
    {
        public static void Postfix(Dialog_FormCaravan __instance)
        {
            CaravanInfo.transferables = new List<TransferableOneWay>(__instance.transferables);
        }
    }

    [HarmonyPatch(typeof(Dialog_FormCaravan))]
    [HarmonyPatch("PostClose")]
    public static class FormCaravan_PostClose
    {
        public static void Postfix()
        {
            CaravanInfo.transferables.Clear();
        }
    }

    [HarmonyPatch(typeof(CaravanUIUtility))]
    [HarmonyPatch("GetDaysWorthOfFoodLabel")]
    public static class CaravanFormingWindowUtility
    {
        [HarmonyPostfix]
        public static void ReplaceFoodRotInfo(Pair<float, float> daysWorthOfFood, ref string __result)
        {           
            if (daysWorthOfFood.First < 600f && 
                daysWorthOfFood.Second < 600f && 
                daysWorthOfFood.Second < daysWorthOfFood.First && 
                CaravanCooler.HasCoolerInTransferableItems(CaravanInfo.transferables)
            ) {
                __result = daysWorthOfFood.First.ToString("0.#");
            }
        }
    }
}
