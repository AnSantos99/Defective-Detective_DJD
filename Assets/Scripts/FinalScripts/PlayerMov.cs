using System.Collections;
using UnityEngine;

/// <summary>
/// This class represents the players movement
/// </summary>
public class PlayerMov : MonoBehaviour
{
    // To get the input of the keyboard
    [SerializeField]private string horizontalInputName;
    [SerializeField]private string verticalInputName;

    // get the walk and run speed
    [SerializeField]private float walkSpeed, runSpeed;

    // To calculate the speed
    [SerializeField]private float runBuildUpSpeed;

    // Get the key for run
    [SerializeField]private KeyCode runKey;

    // To calculate the movement speed
    private float movementSpeed;

    // To check the state
    private bool walking;

    // Variable of characterController to acess it
    private CharacterController charController;

    // For the calculations of the jump
    [SerializeField]private AnimationCurve jumpFallOff;

    // For the jump
    [SerializeField]private float jumpMultiplier;

    // Serializedfield to get the keycode for jump
    [SerializeField]private KeyCode jumpKey;

    // bool to check state
    private bool isJumping;

    // Get the animator to be able to acess it
    private Animator _animator;

    /// <summary>
    /// Get Player controler and animator and set the walking to false
    /// </summary>
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        walking = false;
    }

    /// <summary>
    /// Update on each frame the playermovement and if walkinf is not activ
    /// set the walk and run animations to false so the player doesnt have
    /// the animation on idle
    /// </summary>
    private void Update()
    {
        PlayerMovement();

        if(walking == false)
        { 
            _animator.SetBool("Walk", false);
            _animator.SetBool("Run", false);
        }
    }

    /// <summary>
    /// Method to set the player movement by getting the x and y axis to get
    /// the input to be able to move the player
    /// </summary>
    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        SetMovementSpeed();
        JumpInput();
    }

    /// <summary>
    /// Method to set the players movement speed
    /// </summary>
    private void SetMovementSpeed()
    {
        // Run if the input is a run 
        if (Input.GetKey(runKey))
        {
            walking = true;
            _animator.SetBool("Run", true);
            _animator.SetBool("Walk", false);
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
            FindObjectOfType<SoundManager>().Play("Steps");

        }

        // Else if the input is not the input then set the run to false and walk
        else
        {
            _animator.SetBool("Walk", true);
            _animator.SetBool("Run", false);
            walking = true;
            movementSpeed = Mathf.Clamp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
            FindObjectOfType<SoundManager>().Play("Steps");
        }
    }

    /// <summary>
    /// Method that checks players input and if the input is the given jumpkey
    /// they player will jump and follow the event on a Coroutine
    /// </summary>
    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    /// <summary>
    /// Method that calculates the jump and yield returns its value so the jump
    /// is smooth and not a harsh line jump
    /// </summary>
    /// <returns></returns>
    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
