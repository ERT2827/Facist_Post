using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    private const float MAX_SPEED_ANGLE = -30;
    private const float ZERO_SPEED_ANGLE = 220;

    public Transform needleTransform;
    public Transform speedLabelTemplateTransform;
    public Rigidbody sphere; 

    public float maxSpeed;
    public float speed;



    private void Awake()
    {
        speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;
        maxSpeed = 240f;

        CreateSpeedLabels();
    }




    void Update()
    {
        //HandlePlayerInput();

        speed = sphere.velocity.magnitude * 3.6f;

        //speed += 30f * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        if (speed < 0)
        {
            speed = 0;
        }

        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }



    private void CreateSpeedLabels()
    {
        int labelAmount = 12;
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        for (int i = 0; i <= labelAmount; i++)
        {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalised = (float)i / labelAmount;
            float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalised * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
            speedLabelTransform.Find("speedText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalised * maxSpeed).ToString();
            speedLabelTransform.Find("speedText").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);
        }
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalised = speed / maxSpeed;

        return ZERO_SPEED_ANGLE - speedNormalised * totalAngleSize;
    }
}
