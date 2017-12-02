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

		public string ID { get { return m_id; } }

		public string Name { get { return m_name; } }
	}
}
