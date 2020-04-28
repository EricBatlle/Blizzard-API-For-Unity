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
			/// Coroutine that retrieves a WoW battle pet.
			/// </summary>
			/// <param name="petId">The ID of the pet.</param>
			/// <param name="action_Result">Action to execute with the data once retrieved and converted.</param>
			/// <param name="ifModifiedSince">Adds a request header to check if the document has been modified since this date (in HTML format), which will return an empty response body if it's older.</param>
			/// <param name="action_LastModified">Action to execute with the date of the last server-side modification to the document.</param>
			/// <param name="region">The region of the data to retrieve.</param>
			/// <returns></returns>
			public static IEnumerator GetPet(int petId, Action<WowPet_JSON> action_Result, string ifModifiedSince = null, Action<string> action_LastModified = null, BattleNetRegion region = BattleNetRegion.UnitedStates)
			{
				string path = string.Format("/data/wow/pet/{0}", petId);
				yield return SendRequest(region, namespaceStatic, path, action_Result, ifModifiedSince, action_LastModified);
			}
		}
	}
}

namespace ZeShmouttsAssets.BlizzardAPI.JSON
{
	/// <summary>
	/// JSON structure for World of Warcraft battle pets.
	/// </summary>
	[Serializable]
	public class WowPet_JSON : Object_Json
	{
		public LinkStruct _links;

		public int id;
		public LocalizedString name;
		public TypeNameStruct battle_pet_type;
		public LocalizedString description;
		public bool is_capturable;
		public bool is_tradable;
		public bool is_battlepet;
		public bool is_alliance_only;
		public bool is_horde_only;

		[Serializable]
		public struct PetAbility
		{
			public RefNameIdStruct ability;
			public int slot;
			public int required_level;
		}
		public PetAbility[] abilities;

		public TypeNameStruct source;
		public string icon;
		public RefNameIdStruct creature;
		public bool is_random_creature_display;
	}
}