using System;
using UnityEngine;

[System.Serializable, ES3Serializable]
public class ItemTuple {
	public Item Item;
	public int Amount;

	public ItemTuple(Item item, int amount) {
		this.Item = item;
		this.Amount = amount;
	}

	public ItemTuple() {
		Item = null;
		Amount = 0;
	}
}

[ES3Serializable]
public class Inventory : ItemContainer
{

	[SerializeField] protected ItemTuple[] startingItems;
	[SerializeField] protected Transform itemsParent;
	public static Action<ItemTuple> OnItemAdd;
	public static Action<Item> OnItemRemove;
	protected override void OnValidate()
	{
		if (itemsParent != null)
			itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

		if (!Application.isPlaying) {
			SetStartingItems();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		SetStartingItems();
	}

	private void SetStartingItems()
	{
		Clear();
		foreach(ItemTuple tuple in startingItems) {
			AddItem(tuple.Item.GetCopy(), tuple.Amount);
		}
	}

}
