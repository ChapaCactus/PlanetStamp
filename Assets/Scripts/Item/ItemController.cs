using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class ItemController : MonoBehaviour
	{
		private Item m_item = null;

		public void Setup(Item item)
		{
			m_item = item;
		}
	}
}
