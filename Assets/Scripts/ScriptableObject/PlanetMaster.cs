using System;

using UnityEngine;

using PlanetStamp;

namespace PlanetStamp
{
	[CreateAssetMenu]
	public class PlanetMaster : ScriptableObject
	{
		[SerializeField]
		private PlanetVO[] m_rows;

		public PlanetVO[] Rows { get { return m_rows; } }

		public void GetRow(string id, Action<PlanetVO> callback)
		{
			foreach(var row in Rows)
			{
				if(row.ID == id)
				{
					callback(row);
					return;
				}
			}

			// 見つからなかった場合
			callback(null);
		}
	}
}