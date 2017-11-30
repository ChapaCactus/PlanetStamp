using System;

using UnityEngine;

using PlanetStamp;

namespace PlanetStamp
{
	[CreateAssetMenu]
	public class PlanetMaster : ScriptableObject
	{
		[SerializeField]
		private PlanetVO m_data;

		public PlanetVO GetVO()
		{
			return m_data;
		}
	}
}