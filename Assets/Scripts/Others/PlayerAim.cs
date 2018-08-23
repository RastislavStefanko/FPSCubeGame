using UnityEngine;

public class PlayerAim : MonoBehaviour {

    /// <summary>
    /// set rotation of aim object
    /// </summary>
    /// <param name="amountX"> amount of x angle </param>
    /// <param name="amountY"> amount of y angle </param>
	public void SetRotation(float amountX, float amountY)
    {
        transform.eulerAngles = new Vector3(amountX, amountY, transform.eulerAngles.z);
    }
	
    /// <summary>
    /// get x angle
    /// </summary>
    /// <returns> x angle </returns>
    public float GetAngleX()
    {
        return transform.eulerAngles.x;
    }

    /// <summary>
    /// get y angle with angle check
    /// </summary>
    /// <returns> y angle </returns>
    public float GetAngleY()
    {
        return CheckAngle(transform.eulerAngles.y);
    }

    /// <summary>
    /// transform value from 180 - 360 to the -180 - 0
    /// </summary>
    /// <param name="value"> value to transform </param>
    /// <returns> transformed value </returns>
    public float CheckAngle(float value)
    {
        float angle = value - 180;

        if(angle > 0)
        {
            return angle - 180;
        }

        return angle + 180;

    }
}
