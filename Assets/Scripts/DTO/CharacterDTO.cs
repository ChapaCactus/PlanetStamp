using System.Collections;
using System.Collections.Generic;

namespace PlanetStamp
{
	public class CharacterDTO
	{
		private CharacterVO m_vo;

		private static readonly string PREFAB_PATH_HEADER = "Prefabs/Character/";

		public string ID { get { return "";  } }

		public string Name { get { return m_vo.Name; } }

		public string PrefabPath { get { return PREFAB_PATH_HEADER + ID; } }

		public void SetVO(CharacterVO vo)
		{
			m_vo = vo;
		}
	}
}
