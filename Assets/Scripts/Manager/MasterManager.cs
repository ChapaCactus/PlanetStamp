using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class MasterManager : MonoBehaviour
	{
		private static readonly string MASTER_EXTENSION_NAME = "*.asset";

		private static readonly string RESOURCES_DIR = "Resources/";
		private static readonly string PLANET_RESOURCES_PATH = "Master/Planet";

		public string PlanetMasterDirFullPath { get { return Application.dataPath + "/" + RESOURCES_DIR + PLANET_RESOURCES_PATH; } }

		public Dictionary<string, PlanetMaster> PlanetMasters { get; private set; } = new Dictionary<string, PlanetMaster>();

		private void Awake()
		{
			LoadAllMasters();
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

				if (PlanetMasters.ContainsKey(master.ID))
				{
					Debug.LogWarning("ID: " + master.ID + " は既に追加されているIDです。");
				}
				else
				{
					PlanetMasters.Add(master.ID, master);
				}

				yield return null;
			}
		}
	}
}
