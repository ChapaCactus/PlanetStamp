using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace PlanetStamp
{
	[RequireComponent(typeof(CharacterView))]
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(BoxCollider2D))]
	public class Character : MonoBehaviour
	{
		private CharacterDTO m_characterDTO = null;

		public CharacterView View { get; private set; } = null;
		public CharacterController Controller { get; private set; } = null;

		public Rigidbody2D Rigid2D { get; private set; } = null;

		// Flags
		public bool IsPlayer { get; private set; } = false;
		public bool IsJumping { get; private set; } = false;

		public static void Create(string id, Transform parent, bool isPlayer, Action<Character> callback)
		{
			var dto = new CharacterDTO();
			MasterManager.I.GetCharacterMasterRow(id, (vo) =>
			{
				dto.SetVO(vo);

				var prefab = Resources.Load(dto.PrefabPath) as GameObject;
				var go = Instantiate(prefab, parent);
				var character = go.GetComponent<Character>();
				character.Setup(dto, isPlayer);

				callback(character);
			});
		}

		public void Jump(float acceleration, Vector2 direction)
		{
			if (IsJumping) return;

			IsJumping = true;

			Rigid2D.velocity = Vector2.zero;
			var force = (direction * acceleration);
			Rigid2D.AddForce(force, ForceMode2D.Impulse);
		}

		public void Landing()
		{
			IsJumping = false;
			Rigid2D.velocity = Vector2.zero;
			transform.position = transform.position;
		}

		private void Setup(CharacterDTO dto, bool isPlayer)
		{
			m_characterDTO = dto;

			IsPlayer = isPlayer;

			View = GetComponent<CharacterView>();

			Controller = GetComponent<CharacterController>();
			Controller.Setup(this);

			Rigid2D = GetComponent<Rigidbody2D>();
		}
	}
}
