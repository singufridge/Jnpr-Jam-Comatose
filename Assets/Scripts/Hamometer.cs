using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hamometer : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 0.0f; // The maximum speed of the target ** IN KM/H **

    public float minSpeedAngle;
    public float maxSpeedAngle;

    [Header("UI")]
    public RectTransform meterPaw; // The meterPaw in the speedometer

    private float speed = 0.0f;
    private void Update()
    {
        // 3.6f to convert in kilometers
        // ** The speed must be clamped by the car controller **
        speed = target.linearVelocity.magnitude * 3.6f;

        if (meterPaw != null)
            meterPaw.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedAngle, maxSpeedAngle, speed / maxSpeed));
    }
}
