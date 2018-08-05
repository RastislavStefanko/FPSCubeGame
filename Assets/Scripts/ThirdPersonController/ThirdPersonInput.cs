using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour {

    protected ThirdPersonUserControl control;
    public FixedJoystick joystick;
    public FixedTouchField TouchField;
    public FixedButton CrouchButton;
    public FixedButton FireButton;
    public FixedButton JumpButton;

    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    // Use this for initialization
    void Start () {
        control = GetComponent<ThirdPersonUserControl>();
	}

	// Update is called once per frame
	void Update () {
        if (control.useMobileInput)
        {
            control.m_Jump = JumpButton.Pressed;
            control.crouch = CrouchButton.Pressed;
            control.Hinput = joystick.Horizontal;
            control.Vinput = joystick.Vertical;
        }

        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 3, 4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

    }
}
