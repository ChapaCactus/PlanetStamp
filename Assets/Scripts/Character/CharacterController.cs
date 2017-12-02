using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetStamp
{
	public class CharacterController : MonoBehaviour
	{
		private Character m_character = null;

		public void Setup(Character character)
		{
			m_character = character;
		}

		public void Jump(float acceleration, Vector2 direction)
		{
			if (m_character.IsJumping) return;
		}
	}
}
