using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class StageController : MonoBehaviour
	{
		private IEnumerator Start()
		{
			yield return new WaitForSeconds(0.3f);

			Character.Create("PLAYER", null, true, (player) =>
			{
			});
		}
	}
}
