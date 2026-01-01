using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    public TurnOffLights turnOffLights;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (turnOffLights != null)
            {
                turnOffLights.TurnOffAllLights();
            }
            else
            {
                Debug.LogWarning("TurnOffLights não está atribuído no Player!");
            }
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            if (turnOffLights != null)
            {
                turnOffLights.TurnOnAllLights();
            }
            else
            {
                Debug.LogWarning("TurnOffLights não está atribuído no Player!");
            }
        }
    }
}
