using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private const float MAX_INTERACTION_DISTANCE = 2f;
    private const string PICK_UP_MESSAGE = "Pick up ";

    public CanvasManager canvasManager;

    private Transform _cameraTransform;
    private Interactive _currentInteractive;
    private bool _hasRequirements;
    private List<Interactive> _inventory;

    public void Start()
    {
        _cameraTransform = GetComponentInChildren<Camera>().transform;
        _currentInteractive = null;
        _inventory = new List<Interactive>();
    }

    public void Update()
    {
        CheckForInteractive();
        CheckForInteraction();
    }

    private void CheckForInteractive()
    {
        if (Physics.Raycast(_cameraTransform.position,
                            _cameraTransform.forward,
                            out RaycastHit hitInfo,
                            MAX_INTERACTION_DISTANCE))
        {
            Interactive newInteractive = hitInfo.collider.GetComponent<Interactive>();

            if (newInteractive != null && newInteractive != _currentInteractive)
                SetCurrentInteractive(newInteractive);
            else if (newInteractive == null)
                ClearCurrentInteractive();
        }
        else
            ClearCurrentInteractive();
    }

    private void SetCurrentInteractive(Interactive newInteractive)
    {
        _currentInteractive = newInteractive;

        if (_currentInteractive.type == Interactive.InteractiveType.PICKABLE)
            canvasManager.ShowInteractionPanel(PICK_UP_MESSAGE + _currentInteractive.inventoryName);
        else if (HasInteractionRequirements())
        {
            _hasRequirements = true;
            canvasManager.ShowInteractionPanel(_currentInteractive.interactionText);
        }
        else
        {
            _hasRequirements = false;
            canvasManager.ShowInteractionPanel(_currentInteractive.requirementText);
        }
    }

    private bool HasInteractionRequirements()
    {
        if (_currentInteractive.inventoryRequirements == null)
            return true;

        for (int i = 0; i < _currentInteractive.inventoryRequirements.Length; ++i)
            if (!HasInInventory(_currentInteractive.inventoryRequirements[i]))
                return false;

        return true;
    }

    private void ClearCurrentInteractive()
    {
        _currentInteractive = null;
        canvasManager.HideInteractionPanel();
    }

    private void CheckForInteraction()
    {
        if (Input.GetMouseButtonDown(0) && _currentInteractive != null)
        {
            if (_currentInteractive.type == Interactive.InteractiveType.PICKABLE)
                Pick();
            else
                Interact();
        }
    }

    private void Pick()
    {
        AddToInventory(_currentInteractive);
        _currentInteractive.gameObject.SetActive(false);
    }

    private void Interact()
    {
        if (_hasRequirements)
        {
            for (int i = 0; i < _currentInteractive.inventoryRequirements.Length; ++i)
                RemoveFromInventory(_currentInteractive.inventoryRequirements[i]);

            _currentInteractive.Interact();
        }
    }

    private void AddToInventory(Interactive item)
    {
        _inventory.Add(item);
    }

    private void RemoveFromInventory(Interactive item)
    {
        _inventory.Remove(item);
    }

    private bool HasInInventory(Interactive item)
    {
        return _inventory.Contains(item);
    }

    private void UpdateInventoryIcons()
    {
        canvasManager.ClearInventoryIcons();

        for (int i = 0; i < _inventory.Count; ++i)
            canvasManager.SetInventoryIcon(i, _inventory[i].inventoryIcon);
    }

}
