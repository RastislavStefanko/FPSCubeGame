using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonUserControl))]
public class ThirdPersonInput : MonoBehaviour {

    protected ThirdPersonUserControl control;
    
    /// <summary>
    /// Control buttons
    /// </summary>
    public FixedButton CrouchButton;
    public FixedButton FireButton;
    public FixedButton JumpButton;
    public FixedButton WeaponButton;
    public FixedJoystick joystick;
    public FixedTouchField TouchField;

    protected float CameraAngleX;
    protected float CameraAngleY;
    protected float CameraAngleSpeedX = 0.2f;
    protected float CameraAngleSpeedY = 0.1f;

    void Start () {
        control = GetComponent<ThirdPersonUserControl>();
	}

	void Update () {

        if (control.useMobileInput)
        {
            control.m_Jump = JumpButton.Pressed;
            control.crouch = CrouchButton.Pressed;
            control.Hinput = joystick.Horizontal;
            control.Vinput = joystick.Vertical;
        }

        if (FireButton.Pressed)
        {
            // rotate player to the aim angle
            transform.rotation = Quaternion.AngleAxis(CameraAngleX + 180, Vector3.up);
        }


        // rotate player based on the touch
        CameraAngleX += TouchField.TouchDist.x * CameraAngleSpeedX;
        //CameraAngleX = Mathf.Clamp(CameraAngleX + TouchField.TouchDist.x * CameraAngleSpeedX, -20, 20);
        CameraAngleY = Mathf.Clamp(CameraAngleY - TouchField.TouchDist.y * CameraAngleSpeedY, 0.5f, 5);

        // rotate camera around player
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleX, Vector3.up) * new Vector3(0, CameraAngleY, 5);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2.5f - Camera.main.transform.position, Vector3.up);
    }
}
