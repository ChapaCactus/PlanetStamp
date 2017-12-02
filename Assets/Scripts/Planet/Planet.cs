using System;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	[RequireComponent(typeof(PlanetView))]
	[RequireComponent(typeof(PlanetController))]
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(CircleCollider2D))]
	public class Planet : MonoBehaviour
	{
		private PlanetDTO m_planetDTO = null;

		public PlanetView View { get; private set; } = null;
		public PlanetController Controller { get; private set; } = null;

		public Rigidbody2D Rigid2D { get; private set; } = null;

		public static void Create(string id, Transform parent, Action<Planet> callback)
		{
			var dto = new PlanetDTO();
			MasterManager.I.GetPlaneMasterRow(id, (vo) =>
			{
				dto.SetVO(vo);

				var prefab = Resources.Load(dto.PrefabPath) as GameObject;
				var go = Instantiate(prefab, parent);
				var planet = go.GetComponent<Planet>();
				planet.Setup(dto);

				callback(planet);
			});
		}

		private void Setup(PlanetDTO dto)
		{
			m_planetDTO = dto;

			View = GetComponent<PlanetView>();
			Controller = GetComponent<PlanetController>();

			Rigid2D = GetComponent<Rigidbody2D>();
		}
	}
}
