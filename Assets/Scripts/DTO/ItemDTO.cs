using System;

using UnityEngine;

namespace PlanetStamp
{
	[Serializable]
	public class ItemDTO
	{
		[SerializeField]
		private ItemVO m_vo;

		public void SetVO(ItemVO vo)
		{
			m_vo = vo;
		}
	}
}
