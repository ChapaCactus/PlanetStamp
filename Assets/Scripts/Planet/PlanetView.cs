using UnityEngine;
using UnityEngine.Assertions;

namespace PlanetStamp
{
	public class PlanetView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer m_mainRenderer;

		[SerializeField]
		private ParticleSystem m_landingEffect;

		private void Awake()
		{
			Assert.IsNotNull(m_mainRenderer);
			Assert.IsNotNull(m_landingEffect);
		}

		public void PlayLandingEffect(Vector2 landingPos)
		{
			if (m_landingEffect == null) return;

			m_landingEffect.transform.localPosition = landingPos;
			m_landingEffect.Play();
		}
	}
}
