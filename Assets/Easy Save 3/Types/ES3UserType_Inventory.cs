using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("startingItems", "itemsParent", "ItemSlots")]
	public class ES3UserType_Inventory : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Inventory() : base(typeof(Inventory)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Inventory)obj;
			
			writer.WritePrivateField("startingItems", instance);
			writer.WritePrivateFieldByRef("itemsParent", instance);
			writer.WriteProperty("ItemSlots", instance.ItemSlots);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Inventory)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "startingItems":
					reader.SetPrivateField("startingItems", reader.Read<ItemTuple[]>(), instance);
					break;
					case "itemsParent":
					reader.SetPrivateField("itemsParent", reader.Read<UnityEngine.Transform>(), instance);
					break;
					case "ItemSlots":
						instance.ItemSlots = reader.Read<System.Collections.Generic.List<ItemSlot>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_InventoryArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_InventoryArray() : base(typeof(Inventory[]), ES3UserType_Inventory.Instance)
		{
			Instance = this;
		}
	}
}