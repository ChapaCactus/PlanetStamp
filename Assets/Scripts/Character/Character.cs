using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class Character : MonoBehaviour
	{
		private CharacterDTO m_characterDTO = null;

		public static void Create(string id, Transform parent, Action<Character> callback)
		{
			var dto = new CharacterDTO();
			MasterManager.I.GetCharacterMasterRow(id, (vo) =>
			{
				dto.SetVO(vo);

				var prefab = Resources.Load(dto.PrefabPath) as GameObject;
				var go = Instantiate(prefab, parent);
				var character = go.GetComponent<Character>();
				character.Setup(dto);

				callback(character);
			});
		}

		public void Setup(CharacterDTO dto)
		{
			m_characterDTO = dto;
		}
	}
}
