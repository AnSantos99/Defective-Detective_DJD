using UnityEngine;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { PICKABLE, INTERACT_ONCE, INTERACT_MULTIPLE, INDIRECT, WRITE_CODE };

    public bool isActive;
    public InteractiveType type;
    public string inventoryName;
    public Sprite inventoryIcon;
    public string requirementText;
    public string interactionText;
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

    public void Interact()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("Interact");
        }

        if (isActive)
        {
            ProcessActivationChain();
            ProcessInteractionChain();

            if (type == InteractiveType.INTERACT_ONCE)
            {
                GetComponent<Collider>().enabled = false;
            }

            // check where to change this to so it works
            if (type == InteractiveType.WRITE_CODE)
            {
              
                view = GameObject.FindGameObjectWithTag("viewManager");
                ViewController viewScript = view.GetComponent<ViewController>();
                    
                    viewScript.ToggleInputPanel(true);
                //viewScript.ToggleInputPanel(true);
            }
        }
    }

    private void ProcessActivationChain()
    {
        if (activationChain != null)
        {
            for (int i = 0; i < activationChain.Length; ++i)
                activationChain[i].Activate();
        }
    }

    private void ProcessInteractionChain()
    {
        if (interactionChain != null)
        {
            for (int i = 0; i < interactionChain.Length; ++i)
                interactionChain[i].Interact();
        }
    }
}