using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetStamp
{
	public class CharacterController : MonoBehaviour
	{
		private Character m_character = null;

		private void Update()
		{
			if (!m_character.IsPlayer) return;

			InputCheck();
		}

		public void Setup(Character character)
		{
			m_character = character;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if(collision.gameObject.tag == "Planet")
			{
				m_character.Landing();
			}
		}

		private void InputCheck()
		{
			if(Input.GetButtonDown("Jump"))
			{
				m_character.Jump(1, new Vector2(0, 1));
			}
		}
	}
}
