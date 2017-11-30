using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class MasterManager : MonoBehaviour
	{
		private static readonly string RESOURCES_DIR_NAME = "Resources";
		private static readonly string MASTER_DIR_PATH = "Master";
		private static readonly string PLANET_MASTER_DIR_NAME = "Planet";

		private static readonly string MASTER_EXTENSION_NAME = "*.asset";

		public string PlanetMasterDirPath { get { return Application.dataPath + RESOURCES_DIR_NAME + "/" + MASTER_DIR_PATH + "/" + PLANET_MASTER_DIR_NAME; } }

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
			DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/" + "Resources/Master/Planet");
			FileInfo[] infos = dir.GetFiles(MASTER_EXTENSION_NAME);

			foreach (var info in infos)
			{
				var master = Resources.Load<PlanetMaster>("Master/Planet/" + Path.GetFileNameWithoutExtension(info.Name));
				Debug.Log(info.Name);

				if (PlanetMasters.ContainsKey(master.ID))
				{
					Debug.LogWarning("ID: " + master.ID + " は既に追加されています。 MasterのIDが重複しているかも？");
				}
				else
				{
					PlanetMasters.Add(master.ID, master);
					Debug.Log("追加したMaster ID: " + master.ID);
				}

				yield return null;
			}
		}
	}
}
