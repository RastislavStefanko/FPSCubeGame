using UnityEngine;

public class PlayerAim : MonoBehaviour {

	public void SetRotation(float amountX, float amountZ)
    {
        transform.eulerAngles = new Vector3(amountX, amountZ, transform.eulerAngles.z);
    }
	
    public float GetAngleX()
    {
        return transform.eulerAngles.x;
    }

    public float GetAngleZ()
    {
        return CheckAngle(transform.eulerAngles.y);
    }

    public float CheckAngle(float value)
    {
        float angle = value - 180;

        if(angle > 0)
        {
            return angle - 180;
        }

        return angle + 180;

    }

	// Update is called once per frame
	void Update () {
        //Debug.Log(GetAngleZ());
	}
}
