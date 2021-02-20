using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Item", "Amount")]
	public class ES3UserType_ItemTuple : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ItemTuple() : base(typeof(ItemTuple)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (ItemTuple)obj;
			
			writer.WritePropertyByRef("Item", instance.Item);
			writer.WriteProperty("Amount", instance.Amount, ES3Type_int.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (ItemTuple)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Item":
						instance.Item = reader.Read<Item>();
						break;
					case "Amount":
						instance.Amount = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new ItemTuple();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_ItemTupleArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ItemTupleArray() : base(typeof(ItemTuple[]), ES3UserType_ItemTuple.Instance)
		{
			Instance = this;
		}
	}
}