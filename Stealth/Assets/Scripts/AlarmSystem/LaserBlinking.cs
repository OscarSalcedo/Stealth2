using UnityEngine;
using System.Collections;

public class LaserBlinking : MonoBehaviour {


    public float onTime;
    public float offTime;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        Renderer renderer = GetComponent<Renderer>(); 
        
        if (renderer.enabled && timer >=onTime)
        {
            SwitchBeam();
        }
        if (!renderer.enabled && timer >=onTime)
        {
            SwitchBeam();
        }
    }

    void SwitchBeam()
    {
        timer = 0f;

        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = !renderer.enabled;

        Light light = GetComponent<Light>();
        light.enabled = !light.enabled;
    }
}
