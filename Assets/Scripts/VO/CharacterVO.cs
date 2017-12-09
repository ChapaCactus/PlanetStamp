using System;

using UnityEngine;

namespace PlanetStamp
{
	[Serializable]
	public class CharacterVO
	{
		[SerializeField]
		private string m_id = "";

		[SerializeField]
		private string m_name = "";

		[SerializeField]
		private bool m_isAutoMove = false;

		public string ID { get { return m_id; } }

		public string Name { get { return m_name; } }

		public bool IsAutoMove { get { return m_isAutoMove; } }
	}
}
