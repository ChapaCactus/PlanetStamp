using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class MasterManager : SingletonMonoBehaviour<MasterManager>
	{
		private Dictionary<string, PlanetMaster> m_planetMasters = new Dictionary<string, PlanetMaster>();

		private static readonly string MASTER_EXTENSION_NAME = "*.asset";

		private static readonly string RESOURCES_DIR = "Resources/";
		private static readonly string PLANET_RESOURCES_PATH = "Master/Planet";

		public string PlanetMasterDirFullPath { get { return Application.dataPath + "/" + RESOURCES_DIR + PLANET_RESOURCES_PATH; } }

		private void Awake()
		{
			LoadAllMasters();
		}

		public void GetPlaneMasterRow(string id, Action<PlanetVO> callback)
		{
			if (m_planetMasters.ContainsKey(id))
			{
				var vo = m_planetMasters[id].GetVO();
				callback(vo);
			}
			else
			{
				Debug.LogError("Master ID: " + id + " が存在しません。");
				callback(null);
			}
		}

		public void LoadAllMasters()
		{
			StartCoroutine(LoadAllMastersCoroutine());
		}

		private IEnumerator LoadAllMastersCoroutine()
		{
			yield return LoadPlanetMasters();
		}

		private IEnumerator LoadPlanetMasters()
		{
			DirectoryInfo dir = new DirectoryInfo(PlanetMasterDirFullPath);
			FileInfo[] infos = dir.GetFiles(MASTER_EXTENSION_NAME);

			foreach (var info in infos)
			{
				var fileName = Path.GetFileNameWithoutExtension(info.Name);
				var master = Resources.Load<PlanetMaster>(PLANET_RESOURCES_PATH + "/" + fileName);

				if (m_planetMasters.ContainsKey(master.ID))
				{
					Debug.LogWarning("ID: " + master.ID + " は既に追加されているIDです。");
				}
				else
				{
					m_planetMasters.Add(master.ID, master);
				}

				yield return null;
			}
		}
	}
}
