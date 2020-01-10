using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject interactionPanel;
    public Text interactionText;
    public Image[] inventoryIcons;

    public void Start()
    {
        HideInteractionPanel();
    }

    public void ShowInteractionPanel(string interactionMessage)
    {
        interactionText.text = interactionMessage;
        interactionPanel.SetActive(true);
    }

    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }


    public void ClearInventoryIcons()
    {
        for (int i = 0; i < inventoryIcons.Length; ++i)
        {
            inventoryIcons[i].sprite = null;
            inventoryIcons[i].color = Color.clear;
        }
    }

    public void SetInventoryIcon(int i, Sprite icon)
    {
        inventoryIcons[i].sprite = icon;
        inventoryIcons[i].color = Color.white;
    }
}
