using UnityEngine;

public class Player : MonoBehaviour
{
    private const float MAX_FORWARD_ACCELERATION    = 10.0f;
    private const float MAX_BACKWARD_ACCELERATION   = 10.0f;
    private const float MAX_STRAFE_ACCELERATION     = 10.0f;
    private const float JUMP_ACCELERATION           = 350.0f;
    private const float GRAVITY_ACCELERATION        = 20.0f;

    private const float MAX_FORWARD_VELOCITY    = 5.0f;
    private const float MAX_BACKWARD_VELOCITY   = 3.0f;
    private const float MAX_STRAFE_VELOCITY     = 4.0f;
    private const float MAX_JUMP_VELOCITY       = 50.0f;
    private const float MAX_FALL_VELOCITY       = 100.0f;
    private const float ANGULAR_VELOCITY_FACTOR = 2.0f;

    private const float MIN_HEAD_LOOK_ROTATION  = 300.0f;
    private const float MAX_HEAD_LOOK_ROTATION  = 60.0f;

    private const float WALK_VELOCITY_FACTOR    = 1.0f;
    private const float RUN_VELOCITY_FACTOR     = 2.0f;

    private CharacterController _controller;
    private Transform           _cameraTransform;

    private Vector3 _acceleration;
    private Vector3 _velocity;
    private float   _velocityFactor;
    private bool    _jump;

    public void Start()
    {
        _controller         = GetComponent<CharacterController>();
        _cameraTransform    = GetComponentInChildren<Camera>().transform;
        _acceleration       = Vector3.zero;
        _velocity           = Vector3.zero;
        _velocityFactor     = WALK_VELOCITY_FACTOR;
    }

    public void Update()
    {
        UpdateVelocityFactor();
        UpdateJump();
        UpdateRotation();
        UpdateHeadLook();
    }

    private void UpdateVelocityFactor()
    {
        _velocityFactor = Input.GetButton("Fire3") ? RUN_VELOCITY_FACTOR : WALK_VELOCITY_FACTOR;  ///Fire3 -> Run
    }

    private void UpdateJump()
    {
        if (Input.GetButtonDown("Jump") && _controller.isGrounded)
            _jump = true;
    }

    private void UpdateRotation()
    {
        float rotation = Input.GetAxis("Mouse X") * ANGULAR_VELOCITY_FACTOR;

        transform.Rotate(0f, rotation, 0f);
    }

    private void UpdateHeadLook()
    {
        Vector3 cameraRotation = _cameraTransform.localEulerAngles;

        cameraRotation.x -= Input.GetAxis("Mouse Y") * ANGULAR_VELOCITY_FACTOR;

        if (cameraRotation.x > 180.0f)
            cameraRotation.x = Mathf.Max(cameraRotation.x, MIN_HEAD_LOOK_ROTATION);
        else
            cameraRotation.x = Mathf.Min(cameraRotation.x, MAX_HEAD_LOOK_ROTATION);

        _cameraTransform.localEulerAngles = cameraRotation;
    }

    public void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }

    private void UpdateAcceleration()
    {
        _acceleration.z = Input.GetAxis("Vertical");

        _acceleration.z *= (_acceleration.z > 0) ? MAX_FORWARD_ACCELERATION * _velocityFactor : MAX_BACKWARD_ACCELERATION * _velocityFactor;

        _acceleration.x = Input.GetAxis("Horizontal") * MAX_STRAFE_ACCELERATION * _velocityFactor;

        if (_jump)
        {
            _acceleration.y = JUMP_ACCELERATION;
            _jump = false;
        }
        else if (_controller.isGrounded)
            _acceleration.y = 0f;
        else
            _acceleration.y = -GRAVITY_ACCELERATION;
    }

    private void UpdateVelocity()
    {
        _velocity += _acceleration * Time.fixedDeltaTime;

        _velocity.z = _acceleration.z == 0f ? _velocity.z = 0f : Mathf.Clamp(_velocity.z, -MAX_BACKWARD_VELOCITY * _velocityFactor, MAX_FORWARD_VELOCITY * _velocityFactor);

        _velocity.x = _acceleration.x == 0f ? _velocity.x = 0f : Mathf.Clamp(_velocity.x, -MAX_STRAFE_VELOCITY * _velocityFactor, MAX_STRAFE_VELOCITY * _velocityFactor);

        _velocity.y = _acceleration.y == 0f ? _velocity.y = -0.1f : Mathf.Clamp(_velocity.y, -MAX_FALL_VELOCITY, MAX_JUMP_VELOCITY);
    }

    private void UpdatePosition()
    {
        Vector3 motion = _velocity * Time.fixedDeltaTime;

        _controller.Move(transform.TransformVector(motion));
    }
}
