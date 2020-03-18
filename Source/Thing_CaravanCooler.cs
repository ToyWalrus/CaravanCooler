using RimWorld;
using Verse;

namespace CaravanCooler
{
    public class ThingDef_CaravanCooler : ThingDef
    {
    }

    public class Thing_CaravanCooler : ThingWithComps
    {
        public ThingDef_CaravanCooler Def => this.def as ThingDef_CaravanCooler;
    }
}
