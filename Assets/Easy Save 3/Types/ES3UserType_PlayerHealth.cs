using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("uIPlayerHealthBar", "healthPoints", "maxHealth", "canTakeDamage")]
	public class ES3UserType_PlayerHealth : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PlayerHealth() : base(typeof(PlayerHealth)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PlayerHealth)obj;
			
			writer.WritePropertyByRef("uIPlayerHealthBar", instance.uIPlayerHealthBar);
			writer.WritePrivateField("healthPoints", instance);
			writer.WritePrivateField("maxHealth", instance);
			writer.WritePrivateField("canTakeDamage", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerHealth)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "uIPlayerHealthBar":
						instance.uIPlayerHealthBar = reader.Read<UIPlayerHealthBar>(ES3UserType_UIPlayerHealthBar.Instance);
						break;
					case "healthPoints":
					reader.SetPrivateField("healthPoints", reader.Read<System.Int32>(), instance);
					break;
					case "maxHealth":
					reader.SetPrivateField("maxHealth", reader.Read<System.Int32>(), instance);
					break;
					case "canTakeDamage":
					reader.SetPrivateField("canTakeDamage", reader.Read<System.Boolean>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerHealthArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerHealthArray() : base(typeof(PlayerHealth[]), ES3UserType_PlayerHealth.Instance)
		{
			Instance = this;
		}
	}
}