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

		private void OnCollisionEnter2D(Collision2D col)
		{
			if(col.gameObject.tag == "Planet")
			{
				Debug.Log("axasdsadpin");
				m_character.Landing();
			}
		}

		private void InputCheck()
		{
			if(Input.GetButtonDown("Jump"))
			{
				m_character.Jump(5, new Vector2(0, 1));
			}
		}
	}
}
