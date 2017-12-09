using System;

using UnityEngine;

namespace PlanetStamp
{
	[CreateAssetMenu]
	public class ItemMaster : ScriptableObject
	{
		[SerializeField]
		private ItemVO m_itemVO;

		public string ID { get { return m_itemVO.ID; }}

		public ItemVO GetVO() { return m_itemVO; }
	}
}
