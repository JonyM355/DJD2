using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    private Light[] lights;
    public GameObject obj;
    void Awake()
    {
        lights = FindObjectsByType<Light>(FindObjectsSortMode.None);
        TurnOnAllLights();
    }
    public void TurnOffAllLights()
    {
        foreach (Light light in lights)
            light.enabled = !light.enabled;
        if (!obj.activeSelf)
            obj.SetActive(true);
    }

    public void TurnOnAllLights()
    {
        foreach (Light light in lights)
            light.enabled = !light.enabled;
        if (obj.activeSelf)
            obj.SetActive(false);
    }
}
