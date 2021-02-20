using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_UIPlayerHealthBar : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_UIPlayerHealthBar() : base(typeof(UIPlayerHealthBar)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UIPlayerHealthBar)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UIPlayerHealthBar)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_UIPlayerHealthBarArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_UIPlayerHealthBarArray() : base(typeof(UIPlayerHealthBar[]), ES3UserType_UIPlayerHealthBar.Instance)
		{
			Instance = this;
		}
	}
}