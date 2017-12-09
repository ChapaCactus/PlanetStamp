using System;

using UnityEngine;

namespace PlanetStamp
{
	[Serializable]
	public class ItemDTO
	{
		[SerializeField]
		private ItemVO m_vo;

		private static readonly string PREFAB_PATH_HEADER = "Prefabs/Item/";

		public string ID { get { return m_vo.ID; } }

		public string PrefabPath { get { return PREFAB_PATH_HEADER + ID; } }

		public void SetVO(ItemVO vo)
		{
			m_vo = vo;
		}
	}
}
