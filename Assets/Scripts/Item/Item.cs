using System;

using UnityEngine;

namespace PlanetStamp
{
	[RequireComponent(typeof(ItemView))]
	[RequireComponent(typeof(ItemController))]
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(CircleCollider2D))]
	public class Item : MonoBehaviour, IItem
	{
		[SerializeField]
		private ItemDTO m_itemDTO;

		public static void Create(string id, Transform parent, Action<Item> callback)
		{
			var dto = new ItemDTO();
			MasterManager.I.GetItemMasterRow(id, (vo) =>
			{
				dto.SetVO(vo);

				var prefab = Resources.Load(dto.PrefabPath) as GameObject;
				var go = Instantiate(prefab, parent);
				var item = go.GetComponent<Item>();
				item.Setup(dto);

				callback(item);
			});
		}

		public void Setup(ItemDTO dto)
		{
			m_itemDTO = dto;
		}

		public void Use(Character user)
		{
		}
	}
}
