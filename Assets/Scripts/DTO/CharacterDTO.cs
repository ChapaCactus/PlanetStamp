using System.Collections;
using System.Collections.Generic;

namespace PlanetStamp
{
	public class CharacterDTO
	{
		private CharacterVO m_vo;

		public string Name { get { return m_vo.Name; } }

		public string PrefabPath { get { return m_vo.PrefabPath; } }

		public void SetVO(CharacterVO vo)
		{
			m_vo = vo;
		}
	}
}
