using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer m_mainRenderer;

		public void SetSprite(Sprite sprite)
		{
			m_mainRenderer.sprite = sprite;
		}
	}
}
