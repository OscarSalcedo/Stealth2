using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {

    public float fadeSpeed = 2f;
    public float highIntensity = 2f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;
    public bool alarmOn;

    private float targetIntensity;


    void Awake()
    {
        Light light = GetComponent<Light>();
        light.intensity = 0f;
        targetIntensity = highIntensity;
    }
    
    void Update()
    {
        Light light = GetComponent<Light>();
        if (alarmOn)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity();
        }
        else
        {
            light.intensity = Mathf.Lerp(light.intensity, 0f, fadeSpeed*Time.deltaTime);
        }
    }

    void CheckTargetIntensity()
    {
        Light light = GetComponent<Light>();

        if (Mathf.Abs(targetIntensity - light.intensity)<changeMargin)
        {
            targetIntensity = lowIntensity;
        }
        else
        {
            targetIntensity = highIntensity;
        }
    }
}
