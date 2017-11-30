using System;

using UnityEngine;

namespace PlanetStamp
{
	[Serializable]
	public class PlanetVO
	{
		[SerializeField]
		private string m_id;

		[SerializeField]
		private string m_name;

		[SerializeField]
		private Enums.PlanetType m_type;

		[SerializeField]
		private string m_prefabPath;

		public string ID { get { return m_id; } }

		public string Name { get { return m_name; } }

		public Enums.PlanetType Type { get { return m_type; } }

		/// <summary>
		/// Resources以下のパス
		/// </summary>
		public string PrefabPath { get { return m_prefabPath; } }
	}
}
