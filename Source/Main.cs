using HarmonyLib;
using RimWorld;
using Verse;

namespace LagFix
{
	public class LagFix_Main : Mod
	{
		public LagFix_Main(ModContentPack content) : base(content)
		{
			var harmony = new Harmony("net.pardeike.lagfix");
			harmony.PatchAll();
		}
	}

	[HarmonyPatch(typeof(Alert_NoBabyFeeders), nameof(Alert_NoBabyFeeders.MapWithNoBabyFeeder))]
	static class Alert_NoBabyFeeders_MapWithNoBabyFeeder_Patch
	{
		static bool Prefix(ref Map __result)
		{
			__result = null;
			return false;
		}
	}

	[HarmonyPatch(typeof(Alert_LowBabyFood), nameof(Alert_LowBabyFood.LowBabyFoodNutrition))]
	static class Alert_LowBabyFood_LowBabyFoodNutrition_Patch
	{
		static bool Prefix(ref bool __result)
		{
			__result = false;
			return false;
		}
	}
}