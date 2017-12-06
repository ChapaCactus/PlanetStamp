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
		[SerializeField]
		private Transform m_head = null;

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

		private void Update()
		{
			Walk();
		}

		public void Walk()
		{
			var LookTransform = GameObject.FindWithTag("Planet").transform;

			Vector3 forward = Vector3.Cross(transform.up, -LookTransform.right).normalized;
			Vector3 right = Vector3.Cross(transform.up, LookTransform.forward).normalized;

			Vector3 targetVelocity;

			if (false)
			{

				//if (AutoMoveRight)
				//{
				//	targetVelocity = (forward + right) * speed;

				//	if (!facingRight)
				//	{
				//		Flip();
				//	}

				//}
				//else
				//{
				//	targetVelocity = (forward + -right) * speed;

				//	if (facingRight)
				//	{
				//		Flip();
				//	}
				//}


			}
			else
			{
				targetVelocity = (forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal")) * 	5;
			}

			Vector3 velocity = transform.InverseTransformDirection(GetComponent<Rigidbody2D>().velocity);

			velocity.y = 0;
			velocity = transform.TransformDirection(velocity);
			Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);

			velocityChange.x = Mathf.Clamp(velocityChange.x, -10, 10);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -10, 10);
			velocityChange.y = 0;

			velocityChange = transform.TransformDirection(velocityChange);

			// You need the MaxVelocityChange variable if you change the AddForde to Force instead Impulse
			GetComponent<Rigidbody2D>().AddForce(velocityChange, ForceMode2D.Impulse);
		}

		public void Jump(float acceleration)
		{
			if (IsJumping) return;

			IsJumping = true;

			Rigid2D.velocity = Vector2.zero;
			var direction = (m_head.position - transform.position).normalized;
			var force = (direction * acceleration);
			Rigid2D.AddForce(force, ForceMode2D.Impulse);
		}

		public void Landing(Transform land)
		{
			IsJumping = false;
			Rigid2D.velocity = Vector2.zero;
			transform.position = transform.position;

			View.OnLandingRotation(land);
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
