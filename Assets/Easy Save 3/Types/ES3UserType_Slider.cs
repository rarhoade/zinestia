using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_FillRect", "m_HandleRect", "m_Direction", "m_MinValue", "m_MaxValue", "m_WholeNumbers", "m_Value", "m_OnValueChanged", "m_FillImage", "m_FillTransform", "m_FillContainerRect", "m_HandleTransform", "m_HandleContainerRect", "m_Offset", "m_Tracker", "m_DelayedUpdateVisuals", "s_Selectables", "s_SelectableCount", "m_EnableCalled", "m_Navigation", "m_Transition", "m_Colors", "m_SpriteState", "m_AnimationTriggers", "m_Interactable", "m_TargetGraphic", "m_GroupsAllowInteraction", "m_CurrentIndex", "<isPointerInside>k__BackingField", "<isPointerDown>k__BackingField", "<hasSelection>k__BackingField")]
	public class ES3UserType_Slider : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Slider() : base(typeof(UnityEngine.UI.Slider)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Slider)obj;
			
			writer.WritePrivateFieldByRef("m_FillRect", instance);
			writer.WritePrivateFieldByRef("m_HandleRect", instance);
			writer.WritePrivateField("m_Direction", instance);
			writer.WritePrivateField("m_MinValue", instance);
			writer.WritePrivateField("m_MaxValue", instance);
			writer.WritePrivateField("m_WholeNumbers", instance);
			writer.WritePrivateField("m_Value", instance);
			writer.WritePrivateField("m_OnValueChanged", instance);
			writer.WritePrivateFieldByRef("m_FillImage", instance);
			writer.WritePrivateFieldByRef("m_FillTransform", instance);
			writer.WritePrivateFieldByRef("m_FillContainerRect", instance);
			writer.WritePrivateFieldByRef("m_HandleTransform", instance);
			writer.WritePrivateFieldByRef("m_HandleContainerRect", instance);
			writer.WritePrivateField("m_Offset", instance);
			writer.WritePrivateField("m_Tracker", instance);
			writer.WritePrivateField("m_DelayedUpdateVisuals", instance);
			writer.WritePrivateField("s_Selectables", instance);
			writer.WritePrivateField("s_SelectableCount", instance);
			writer.WritePrivateField("m_EnableCalled", instance);
			writer.WritePrivateField("m_Navigation", instance);
			writer.WritePrivateField("m_Transition", instance);
			writer.WritePrivateField("m_Colors", instance);
			writer.WritePrivateField("m_SpriteState", instance);
			writer.WritePrivateField("m_AnimationTriggers", instance);
			writer.WritePrivateField("m_Interactable", instance);
			writer.WritePrivateFieldByRef("m_TargetGraphic", instance);
			writer.WritePrivateField("m_GroupsAllowInteraction", instance);
			writer.WritePrivateField("m_CurrentIndex", instance);
			writer.WritePrivateField("<isPointerInside>k__BackingField", instance);
			writer.WritePrivateField("<isPointerDown>k__BackingField", instance);
			writer.WritePrivateField("<hasSelection>k__BackingField", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Slider)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_FillRect":
					reader.SetPrivateField("m_FillRect", reader.Read<UnityEngine.RectTransform>(), instance);
					break;
					case "m_HandleRect":
					reader.SetPrivateField("m_HandleRect", reader.Read<UnityEngine.RectTransform>(), instance);
					break;
					case "m_Direction":
					reader.SetPrivateField("m_Direction", reader.Read<UnityEngine.UI.Slider.Direction>(), instance);
					break;
					case "m_MinValue":
					reader.SetPrivateField("m_MinValue", reader.Read<System.Single>(), instance);
					break;
					case "m_MaxValue":
					reader.SetPrivateField("m_MaxValue", reader.Read<System.Single>(), instance);
					break;
					case "m_WholeNumbers":
					reader.SetPrivateField("m_WholeNumbers", reader.Read<System.Boolean>(), instance);
					break;
					case "m_Value":
					reader.SetPrivateField("m_Value", reader.Read<System.Single>(), instance);
					break;
					case "m_OnValueChanged":
					reader.SetPrivateField("m_OnValueChanged", reader.Read<UnityEngine.UI.Slider.SliderEvent>(), instance);
					break;
					case "m_FillImage":
					reader.SetPrivateField("m_FillImage", reader.Read<UnityEngine.UI.Image>(), instance);
					break;
					case "m_FillTransform":
					reader.SetPrivateField("m_FillTransform", reader.Read<UnityEngine.Transform>(), instance);
					break;
					case "m_FillContainerRect":
					reader.SetPrivateField("m_FillContainerRect", reader.Read<UnityEngine.RectTransform>(), instance);
					break;
					case "m_HandleTransform":
					reader.SetPrivateField("m_HandleTransform", reader.Read<UnityEngine.Transform>(), instance);
					break;
					case "m_HandleContainerRect":
					reader.SetPrivateField("m_HandleContainerRect", reader.Read<UnityEngine.RectTransform>(), instance);
					break;
					case "m_Offset":
					reader.SetPrivateField("m_Offset", reader.Read<UnityEngine.Vector2>(), instance);
					break;
					case "m_Tracker":
					reader.SetPrivateField("m_Tracker", reader.Read<UnityEngine.DrivenRectTransformTracker>(), instance);
					break;
					case "m_DelayedUpdateVisuals":
					reader.SetPrivateField("m_DelayedUpdateVisuals", reader.Read<System.Boolean>(), instance);
					break;
					case "s_Selectables":
					reader.SetPrivateField("s_Selectables", reader.Read<UnityEngine.UI.Selectable[]>(), instance);
					break;
					case "s_SelectableCount":
					reader.SetPrivateField("s_SelectableCount", reader.Read<System.Int32>(), instance);
					break;
					case "m_EnableCalled":
					reader.SetPrivateField("m_EnableCalled", reader.Read<System.Boolean>(), instance);
					break;
					case "m_Navigation":
					reader.SetPrivateField("m_Navigation", reader.Read<UnityEngine.UI.Navigation>(), instance);
					break;
					case "m_Transition":
					reader.SetPrivateField("m_Transition", reader.Read<UnityEngine.UI.Selectable.Transition>(), instance);
					break;
					case "m_Colors":
					reader.SetPrivateField("m_Colors", reader.Read<UnityEngine.UI.ColorBlock>(), instance);
					break;
					case "m_SpriteState":
					reader.SetPrivateField("m_SpriteState", reader.Read<UnityEngine.UI.SpriteState>(), instance);
					break;
					case "m_AnimationTriggers":
					reader.SetPrivateField("m_AnimationTriggers", reader.Read<UnityEngine.UI.AnimationTriggers>(), instance);
					break;
					case "m_Interactable":
					reader.SetPrivateField("m_Interactable", reader.Read<System.Boolean>(), instance);
					break;
					case "m_TargetGraphic":
					reader.SetPrivateField("m_TargetGraphic", reader.Read<UnityEngine.UI.Graphic>(), instance);
					break;
					case "m_GroupsAllowInteraction":
					reader.SetPrivateField("m_GroupsAllowInteraction", reader.Read<System.Boolean>(), instance);
					break;
					case "m_CurrentIndex":
					reader.SetPrivateField("m_CurrentIndex", reader.Read<System.Int32>(), instance);
					break;
					case "<isPointerInside>k__BackingField":
					reader.SetPrivateField("<isPointerInside>k__BackingField", reader.Read<System.Boolean>(), instance);
					break;
					case "<isPointerDown>k__BackingField":
					reader.SetPrivateField("<isPointerDown>k__BackingField", reader.Read<System.Boolean>(), instance);
					break;
					case "<hasSelection>k__BackingField":
					reader.SetPrivateField("<hasSelection>k__BackingField", reader.Read<System.Boolean>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_SliderArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SliderArray() : base(typeof(UnityEngine.UI.Slider[]), ES3UserType_Slider.Instance)
		{
			Instance = this;
		}
	}
}