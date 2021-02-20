using UnityEngine;

public class InventoryInput : MonoBehaviour
{
	[SerializeField] GameObject characterPanelGameObject;
	[SerializeField] GameObject equipmentPanelGameObject;
	[SerializeField] GameObject pauseMenuGameObject;
	[SerializeField] KeyCode[] toggleCharacterPanelKeys;
	[SerializeField] KeyCode[] toggleInventoryKeys;
	[SerializeField] KeyCode[] togglePauseMenuKeys;
	[SerializeField] bool showAndHideMouse = true;
	[SerializeField] bool enableMenuInput = true;
	[SerializeField] bool loadSaveMenuInput = false; 
	void Update()
	{
		if(enableMenuInput) {
			ToggleCharacterPanel();
			ToggleInventory();
			ToggleEscapeMenu();
		} 
	}

	private void ToggleCharacterPanel()
	{
		for (int i = 0; i < toggleCharacterPanelKeys.Length; i++)
		{
			if (Input.GetKeyDown(toggleCharacterPanelKeys[i]))
			{
				characterPanelGameObject.SetActive(!characterPanelGameObject.activeSelf);

				if (characterPanelGameObject.activeSelf)
				{
					equipmentPanelGameObject.SetActive(true);
					ShowMouseCursor();
				}
				else
				{
					HideMouseCursor();
				}

				break;
			}
		}
	}

	private void ToggleInventory()
	{
		for (int i = 0; i < toggleInventoryKeys.Length; i++)
		{
			if (Input.GetKeyDown(toggleInventoryKeys[i]))
			{
				if (!characterPanelGameObject.activeSelf)
				{
					characterPanelGameObject.SetActive(true);
					equipmentPanelGameObject.SetActive(false);
					ShowMouseCursor();
				}
				else if (equipmentPanelGameObject.activeSelf)
				{
					equipmentPanelGameObject.SetActive(false);
				}
				else
				{
					characterPanelGameObject.SetActive(false);
					HideMouseCursor();
				}
				break;
			}
		}
	}

	private void ToggleEscapeMenu() {
		for (int i = 0; i < togglePauseMenuKeys.Length; i++) {
			if (Input.GetKeyDown(togglePauseMenuKeys[i])) {
				pauseMenuGameObject.GetComponent<PauseMenu>().TogglePause();
			}
		}
	}

	public void ShowMouseCursor()
	{
		if (showAndHideMouse)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void HideMouseCursor()
	{
		if (showAndHideMouse)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	public void ToggleEquipmentPanel()
	{
		equipmentPanelGameObject.SetActive(!equipmentPanelGameObject.activeSelf);
	}

	public void ToggleMenuInput(bool newValue) {
		enableMenuInput = newValue;
	}
}
