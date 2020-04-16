﻿using System;
using System.Collections;
using System.Collections.Generic;
using ZeShmouttsAssets.BlizzardAPI.JSON;

namespace ZeShmouttsAssets.BlizzardAPI
{
	/// <summary>
	/// API endpoints related to World of Warcraft profile data (characters, account, etc.).
	/// Reference : https://develop.battle.net/documentation/world-of-warcraft/profile-apis
	/// </summary>
	public static class BlizzardAPI_WowProfile
	{
		#region Account Profile API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Achievements API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Appearance API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Collections API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Encounters API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Equipment API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Hunter Pets API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Media API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Mythic Keystone Profile API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Profile API

		/// <summary>
		/// Coroutine that retrieves informations about a WoW character from Blizzard as JSON, then convert the JSON to something easier to handle.
		/// </summary>
		/// <param name="region">The server region to get the character from.</param>
		/// <param name="realm">The realm the character is on.</param>
		/// <param name="name">THe character's name.</param>
		/// <param name="result">Action to execute with the character data once retrieved and converted.</param>
		/// <returns></returns>
		public static IEnumerator CGetCharacterProfileSummary(BlizzardAPI.BattleNetRegion region, string realm, string name, Action<WowCharacterProfileSummary_JSON> result)
		{
			string path = string.Format("/profile/wow/character/{0}/{1}", realm, name);
			yield return BlizzardAPI.SendRequest(region, BlizzardAPI.namespaceProfile, path, result);
		}

		/// <summary>
		/// EXPERIMENTAL FEATURE, USE WITH CAUTION. Same as CGetCharacterProfileSummary except it uses web request headers to send the token and namespace, instead of cramming everything in the url.
		/// </summary>
		/// <param name="region">The server region to get the character from.</param>
		/// <param name="realm">The realm the character is on.</param>
		/// <param name="name">THe character's name.</param>
		/// <param name="result">Action to execute with the character data once retrieved and converted.</param>
		/// <returns></returns>
		public static IEnumerator CGetCharacterProfileSummaryTest(BlizzardAPI.BattleNetRegion region, string realm, string name, Action<WowCharacterProfileSummary_JSON> result)
		{
			Dictionary<string, string> headers = new Dictionary<string, string>()
			{
				{ "Battlenet-Namespace", BlizzardAPI.namespaceProfile + region },
				{ "Authorization", "Bearer " + BlizzardAPI.accessToken.token }
			};

			string path = string.Concat("/profile/wow/character/", realm, "/", name);

			yield return BlizzardAPI.SendRequestHeaders(region, BlizzardAPI.namespaceProfile, path, headers, result);
		}

		#endregion

		#region Character PvP API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Quests API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Reputations API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Specializations API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Statistics API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Character Titles API

		// NOT YET IMPLEMENTED.

		#endregion

		#region Guild API

		// NOT YET IMPLEMENTED.

		#endregion
	}
}