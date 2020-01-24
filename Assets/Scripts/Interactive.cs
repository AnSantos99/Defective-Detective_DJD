using UnityEngine;

public class Interactive : MonoBehaviour
{
    /// <summary>
    /// Enum that contains states of interactable states
    /// </summary>
    public enum InteractiveType { PICKABLE, INTERACT_ONCE, INTERACT_MULTIPLE, INDIRECT, WRITE_CODE };

    // variable to check states
    public bool isActive;

    // variable of type InteractiveType to get state of enumerator
    public InteractiveType type;

    // 
    public string inventoryName;

    // To get the icons of the inventory
    public Sprite inventoryIcon;

    // 
    public string requirementText;


    public string interactionText;

    // Array of interactivable objects 
    public Interactive[] inventoryRequirements;
    public Interactive[] activationChain;
    public Interactive[] interactionChain;

    private GameObject view;

    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        isActive = true;
    }

    /// <summary>
    /// Function that checks the objects who are interactivable
    /// </summary>
    public void Interact()
    {
        // To check if the animator is enabled
        if (_animator != null)
        {
            _animator.SetTrigger("Interact");
        }

        // If this is active
        if (isActive)
        {
            // 
            ProcessActivationChain();
            ProcessInteractionChain();

            // Objects can only interact once
            if (type == InteractiveType.INTERACT_ONCE)
            {
                GetComponent<Collider>().enabled = false;
            }

            // check where to change this to so it works
            if (type == InteractiveType.WRITE_CODE)
            {
                // Get the game object with the corresponding tag
                view = GameObject.FindGameObjectWithTag("viewManager");

                // Get the view controller component
                ViewController viewScript = view.GetComponent<ViewController>();
                
                // Set the view to true
                viewScript.ToggleInputPanel(true);
                //viewScript.ToggleInputPanel(true);
            }
        }
    }

    /// <summary>
    ///   
    /// </summary>
    private void ProcessActivationChain()
    {
        if (activationChain != null)
        {
            for (int i = 0; i < activationChain.Length; ++i)
                activationChain[i].Activate();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void ProcessInteractionChain()
    {
        if (interactionChain != null)
        {
            for (int i = 0; i < interactionChain.Length; ++i)
                interactionChain[i].Interact();
        }
    }
}