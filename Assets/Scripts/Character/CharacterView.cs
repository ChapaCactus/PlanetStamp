using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer m_mainRenderer;

		public Transform Transform { get; private set; } = null;

		private void Awake()
		{
			Transform = transform;
		}

		public void SetSprite(Sprite sprite)
		{
			m_mainRenderer.sprite = sprite;
		}

		public void OnLandingRotation(Transform land)
		{
			SetRotate(Vector3.down, land);
		}

		private void SetRotate(Vector3 from, Transform target)
		{
			var to = (target.transform.position - Transform.position).normalized;
			Transform.rotation = Quaternion.FromToRotation(from, to);
		}
	}
}
