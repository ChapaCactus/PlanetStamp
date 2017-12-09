using System;

using UnityEngine;

namespace PlanetStamp
{
	[Serializable]
	public class ItemVO
	{
		[SerializeField]
		private string m_id;

		public string ID { get { return m_id; } }
	}
}
