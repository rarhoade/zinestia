using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("isDragging", "dragColor", "image", "amountText", "isPointerOver", "normalColor", "disabledColor", "_item", "_amount")]
	public class ES3UserType_ItemSlot : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ItemSlot() : base(typeof(ItemSlot)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ItemSlot)obj;
			
			writer.WritePrivateField("isDragging", instance);
			writer.WritePrivateField("dragColor", instance);
			writer.WritePrivateFieldByRef("image", instance);
			writer.WritePrivateFieldByRef("amountText", instance);
			writer.WritePrivateField("isPointerOver", instance);
			writer.WritePrivateField("normalColor", instance);
			writer.WritePrivateField("disabledColor", instance);
			writer.WritePrivateFieldByRef("_item", instance);
			writer.WritePrivateField("_amount", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ItemSlot)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "isDragging":
					reader.SetPrivateField("isDragging", reader.Read<System.Boolean>(), instance);
					break;
					case "dragColor":
					reader.SetPrivateField("dragColor", reader.Read<UnityEngine.Color>(), instance);
					break;
					case "image":
					reader.SetPrivateField("image", reader.Read<UnityEngine.UI.Image>(), instance);
					break;
					case "amountText":
					reader.SetPrivateField("amountText", reader.Read<UnityEngine.UI.Text>(), instance);
					break;
					case "isPointerOver":
					reader.SetPrivateField("isPointerOver", reader.Read<System.Boolean>(), instance);
					break;
					case "normalColor":
					reader.SetPrivateField("normalColor", reader.Read<UnityEngine.Color>(), instance);
					break;
					case "disabledColor":
					reader.SetPrivateField("disabledColor", reader.Read<UnityEngine.Color>(), instance);
					break;
					case "_item":
					reader.SetPrivateField("_item", reader.Read<Item>(), instance);
					break;
					case "_amount":
					reader.SetPrivateField("_amount", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ItemSlotArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ItemSlotArray() : base(typeof(ItemSlot[]), ES3UserType_ItemSlot.Instance)
		{
			Instance = this;
		}
	}
}