using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    private Light[] lights;
    public GameObject obj;
    public GameObject Buttons;
    public Material On;
    public Material Off;
    Renderer rend;
    void Awake()
    {
        lights = FindObjectsByType<Light>(FindObjectsSortMode.None);
        rend = Buttons.GetComponent<Renderer>();
        TurnOnAllLights();
    }
    public void TurnOffAllLights()
    {
        foreach (Light light in lights)
            light.enabled = !light.enabled;
        if (!obj.activeSelf)
        {
            obj.SetActive(true);
            rend.material = Off;
        }
        Debug.Log("Teste");
    }

    public void TurnOnAllLights()
    {
        foreach (Light light in lights)
            light.enabled = !light.enabled;
        if (obj.activeSelf)
        {
            obj.SetActive(false);
            rend.material = On;
        }
    }
}
