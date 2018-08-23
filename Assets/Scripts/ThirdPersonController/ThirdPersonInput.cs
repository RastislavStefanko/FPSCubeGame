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
    public int rangeAim;

    public bool Zoom { get; set; }
    
    [SerializeField] private int zoomDist;
    [SerializeField] private int unzoomDist;
    [SerializeField] private int smoothZoomMove;

    private float aimRangePoint;
    private bool zoomFirstTime;

    protected float cameraAngleX;
    protected float cameraAngleY;
    protected float cameraAngleSpeedX = 0.2f;
    protected float cameraAngleSpeedY = 0.1f;

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
            transform.rotation = Quaternion.AngleAxis(cameraAngleX + 180, Vector3.up);
        }

        // zooming
        if (TouchField.DoubleClick)
        {
            Zoom = true;

            // if zooming first frame
            if (zoomFirstTime)
            {
                zoomFirstTime = false;

                // rotate player to the aim angle
                transform.rotation = Quaternion.AngleAxis(cameraAngleX + 180, Vector3.up);

                aimRangePoint = cameraAngleX;
            }
            
            // clamp camera to the selected range
            cameraAngleX = Mathf.Clamp(cameraAngleX + GetTouchDistX(), aimRangePoint - rangeAim, aimRangePoint + rangeAim);

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomDist, Time.deltaTime * smoothZoomMove);
        }
        else
        {
            Zoom = false;
            zoomFirstTime = true;

            // rotate player based on the touch
            cameraAngleX += GetTouchDistX();

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, unzoomDist, Time.deltaTime * smoothZoomMove);
        }

        cameraAngleY = Mathf.Clamp(cameraAngleY - TouchField.TouchDist.y * cameraAngleSpeedY, 0.5f, 5);

        // rotate camera around player
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(cameraAngleX, Vector3.up) * new Vector3(0, cameraAngleY, 5);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2.5f - Camera.main.transform.position, Vector3.up);
    }

    /// <summary>
    /// get touch distance multiply by camera angle x
    /// </summary>
    /// <returns> x touch distance </returns>
    public float GetTouchDistX()
    {
        return TouchField.TouchDist.x * cameraAngleSpeedX;
    }
}
