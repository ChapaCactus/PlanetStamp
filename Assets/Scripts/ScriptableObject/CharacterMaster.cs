using System;

using UnityEngine;

namespace PlanetStamp
{
	[CreateAssetMenu]
	public class CharacterMaster : ScriptableObject
	{
		[SerializeField]
		private CharacterVO m_data;

		public string ID { get { return ""; } }

		public CharacterVO GetVO()
		{
			return m_data;
		}
	}
}
