using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;

    public float minIntensity = 0.2f;
    public float maxIntensity = 1.5f;

    public float flickerSpeed = 0.05f; // lower = faster flicker

    void Start()
    {
        if (flickerLight == null)
        {
            flickerLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        float randomIntensity = Random.Range(minIntensity, maxIntensity);
        flickerLight.intensity = Mathf.Lerp(flickerLight.intensity, randomIntensity, Time.deltaTime / flickerSpeed);
    }
}