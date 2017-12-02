using System;

using UnityEngine;

namespace PlanetStamp
{
	[Serializable]
	public class CharacterVO
	{
		[SerializeField]
		private string m_name;

		[SerializeField]
		private string m_prefabPath;

		public string Name { get { return m_name; } }

		public string PrefabPath { get { return m_prefabPath; } }
	}
}
