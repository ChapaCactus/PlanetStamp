using System;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class Planet : MonoBehaviour
	{
		private PlanetDTO m_planetDTO;

		private static readonly string PREFAB_PATH = "";

		public static void Create(int id, Transform parent, Action<Planet> callback)
		{
			var prefab = Resources.Load(PREFAB_PATH) as GameObject;
			var go = Instantiate(prefab, parent);

			var planet = go.GetComponent<Planet>();

			var dto = new PlanetDTO();
			var vo = new PlanetVO();// ほんとはMasterからロードする
			dto.SetVO(vo);

			planet.Setup(dto);

			callback(planet);
		}

		private void Setup(PlanetDTO dto)
		{
			m_planetDTO = dto;
		}
	}
}
