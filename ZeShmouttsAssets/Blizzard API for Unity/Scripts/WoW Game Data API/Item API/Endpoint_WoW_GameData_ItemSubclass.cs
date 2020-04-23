﻿using System;
using System.Collections;
using ZeShmouttsAssets.BlizzardAPI.JSON;

namespace ZeShmouttsAssets.BlizzardAPI
{
	/// <summary>
	/// Interface for working with the Blizzard API inside Unity.
	/// </summary>
	public static partial class BlizzardAPI
	{
		/// <summary>
		/// API endpoints related to World of Warcraft game data (items, spells, etc.).
		/// Reference : https://develop.battle.net/documentation/world-of-warcraft/game-data-apis
		/// </summary>
		public static partial class WowGameData
		{
			/// <summary>
			/// Coroutine that retrieves a WoW item subclass.
			/// </summary>
			/// <param name="itemClassId">The ID of the item class.</param>
			/// <param name="itemSubclassId">The ID of the item subclass.</param>
			/// <param name="action_Result">Action to execute with the data once retrieved and converted.</param>
			/// <param name="action_LastModified">Action to execute with the date of the last server-side modification to the document.</param>
			/// <param name="region">The region of the data to retrieve.</param>
			/// <returns></returns>
			public static IEnumerator GetItemSubclass(int itemClassId, int itemSubclassId, Action<WoWAchievement_JSON> action_Result, string ifModifiedSince = null, Action<string> action_LastModified = null, BattleNetRegion region = BattleNetRegion.UnitedStates)
			{
				string path = string.Format("/data/wow/item-class/{0}/item-subclass/{1}", itemClassId, itemSubclassId);
				yield return SendRequest(region, namespaceStatic, path, action_Result, ifModifiedSince, action_LastModified);
			}
		}
	}
}

namespace ZeShmouttsAssets.BlizzardAPI.JSON
{
	/// <summary>
	/// JSON structure for World of Warcraft item subclasses.
	/// </summary>
	[Serializable]
	public class WowItemSubclass_JSON : Object_Json
	{
		public LinkStruct _links;

		public int class_id;
		public int subclass_id;
		public LocalizedString display_name;
		public bool hide_subclass_in_tooltips;
	}
}