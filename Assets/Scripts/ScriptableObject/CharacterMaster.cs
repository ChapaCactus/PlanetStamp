using System;

using UnityEngine;

namespace PlanetStamp
{
	[CreateAssetMenu]
	public class CharacterMaster : ScriptableObject
	{
		[SerializeField]
		private CharacterVO m_characterVO;

		public string ID { get { return m_characterVO.ID; } }

		public CharacterVO GetVO() { return m_characterVO; }
	}
}
