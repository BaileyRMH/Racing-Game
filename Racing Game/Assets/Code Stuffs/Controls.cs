using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    public string currentControlScheme { get; }

    public float moveSpeed;
    public float maxSpeed;
    public float reverseSpeed;
    public float turnSpeed;
    public float brakeForce;

    public float steeringInput;
    private Vector3 velocity = Vector3.zero;

    private InputAction joystickThrottle;
    private InputAction keyboardThrottle;
    private InputAction joystickBrake;
    private InputAction keyboardBrake;
    private InputAction steeringAction;

    public Rigidbody rb;

    private void OnEnable()
    {
        joystickThrottle = new InputAction(type: InputActionType.Value, binding: "<Joystick>/z");
        keyboardThrottle = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/w");
        
        joystickBrake = new InputAction(type: InputActionType.Value, binding: "<Joystick>/rz");
        keyboardBrake = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/s");

        steeringAction = new InputAction(type: InputActionType.Value);
        steeringAction.AddBinding("<Joystick>/stick/x");
        steeringAction.AddCompositeBinding("1DAxis")
            .With("negative", "<Keyboard>/a")
            .With("positive", "<Keyboard>/d");

        joystickThrottle.Enable();
        keyboardThrottle.Enable();
        joystickBrake.Enable();
        keyboardBrake.Enable();
        steeringAction.Enable();
    }

    private void OnDisable()
    {
        joystickThrottle.Disable();
        keyboardThrottle.Disable();
        joystickBrake.Disable();
        keyboardBrake.Disable();
        steeringAction.Disable();
    }

    private void Update()
    {
        bool joystickConnected = Joystick.current != null;
        float joyThrottle = 0f;
        float joyBrake = 0f;

        if (joystickConnected)
        {
            float rawJoyThrottle = joystickThrottle.ReadValue<float>();
            float rawJoyBrake = joystickBrake.ReadValue<float>();
            // Convert to usable range and apply deadzones
            joyThrottle = rawJoyThrottle < 0.99f ? Mathf.Clamp01(1f - rawJoyThrottle) : 0f;
            if (joyThrottle < 0.05f) joyThrottle = 0f;
            joyBrake = rawJoyBrake < 0.99f ? 1f - rawJoyBrake : 0f;

        }


       
        

        float keyThrottle = keyboardThrottle.ReadValue<float>();
        float keyBrake = keyboardBrake.ReadValue<float>();

        float throttleInput = Mathf.Max(joyThrottle, keyThrottle);
        float brakeInput = Mathf.Max(joyBrake, keyBrake);
        steeringInput = steeringAction.ReadValue<float>();

        Vector3 moveDirection = Vector3.zero;

        if (throttleInput > 0.1f)
        {
            moveDirection = transform.forward * throttleInput * moveSpeed;
        }
        else if (brakeInput > 0.1f)
        {
            moveDirection = -transform.forward * brakeInput * reverseSpeed;
        }
        else
        {
            velocity = Vector3.Lerp(velocity, Vector3.zero, brakeForce * Time.deltaTime);
        }

        if (moveDirection != Vector3.zero)
        {
            velocity = moveDirection;
        }


        //transform.Translate(velocity * Time.deltaTime, Space.World);
        rb.AddForce(velocity * Time.deltaTime, ForceMode.Impulse);
        //rb.AddExplosionForce(1000f, this.transform.position, 10);

        float turn = steeringInput * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, turn, 0f);

        Debug.Log(currentControlScheme);

        Debug.Log(velocity);
        //Debug.Log(throttleInput);
        //Debug.Log(brakeInput);
        //Debug.Log(brakeInput);

    }



}
