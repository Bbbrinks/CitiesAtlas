using ICities;
using UnityEngine;
using ColossalFramework;
using ColossalFramework.UI;
using System.Collections;
using ColossalFramework.Plugins;

public class CitiesAtlas : IUserMod {
	
	public string Name {
		get { return "Cities Atlas"; }
	}
	
	public string Description {
		get { return "Cities Atlas adds a height map overlay to Cities:Skylines. Now you can plan your cities around those hills:)."; }
	}
}

public class LoadingExtension : LoadingExtensionBase
{

	private bool active;

	public override void OnLevelLoaded(LoadMode mode)
	{
		// Get the UIView object. This seems to be the top-level object for most
		// of the UI.
		var uiView = UIView.GetAView();
		
		// Add a new button to the view.
		var button = (UIButton)uiView.AddUIComponent(typeof(UIButton));
		
		// Set the text to show on the button.
		button.text = "Terrain height!";
		
		// Set the button dimensions.
		button.width = 150;
		button.height = 40;
		
		// Style the button to look like a menu button.
		button.normalBgSprite = "ButtonMenu";
		button.disabledBgSprite = "ButtonMenuDisabled";
		button.hoveredBgSprite = "ButtonMenuHovered";
		button.focusedBgSprite = "ButtonMenuFocused";
		button.pressedBgSprite = "ButtonMenuPressed";
		button.textColor = new Color32(255, 255, 255, 255);
		button.disabledTextColor = new Color32(7, 7, 7, 255);
		button.hoveredTextColor = new Color32(7, 132, 255, 255);
		button.focusedTextColor = new Color32(255, 255, 255, 255);
		button.pressedTextColor = new Color32(30, 30, 44, 255);
		
		// Enable button sounds.
		button.playAudioEvents = true;
		
		// Place the button.
		button.transformPosition = new Vector3(-1.0f, 0.97f);
		
		// Respond to button click.
		button.eventClick += ButtonClick;
	}
	
	private void ButtonClick(UIComponent component, UIMouseEventParameter eventParam)
	{
		if (!active) {
			active = true;
			Singleton<InfoManager>.instance.SetCurrentMode (InfoManager.InfoMode.TerrainHeight, InfoManager.SubInfoMode.Default);
		}else{
			active = false;
			Singleton<InfoManager>.instance.SetCurrentMode (InfoManager.InfoMode.None, InfoManager.SubInfoMode.Default);
	
		}

	}
}