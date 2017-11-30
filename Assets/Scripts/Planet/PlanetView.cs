using UnityEngine;
using UnityEngine.Assertions;

namespace PlanetStamp
{
	public class PlanetView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer m_mainRenderer;

		private void Awake()
		{
			Assert.IsNotNull(m_mainRenderer);
		}
	}
}
