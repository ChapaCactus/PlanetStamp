﻿using System.Collections;
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
				m_character.Landing(col.transform);
			}
		}

		private void InputCheck()
		{
			if(Input.GetButtonDown("Jump"))
			{
				m_character.Jump(13);
			}
		}
	}
}
