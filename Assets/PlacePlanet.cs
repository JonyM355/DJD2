using UnityEngine;
using UnityEngine.UIElements;

public class PlacePlanet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] SolarSystemManager SolarSystemManager;
    public Transform hand;
    private int Location;

    void Start()
    {
        if (int.TryParse(gameObject.name, out Location))
            Debug.Log(Location); // 123
        else
            Debug.Log("Invalid number");


    }

    void OnEnable()
    {
        Transform child = hand.GetChild(0);

        if (child != null)
        {
            child.position = transform.position;
            //child.rotation = transform.rotation;
            Debug.Log(int.Parse(child.name));
            child.SetParent(transform);
            SolarSystemManager.ChangeSlot(Location);
            SolarSystemManager.ChangeAnswer(Location, int.Parse(child.name));
            SolarSystemManager.CheckResult();
        }
        else
        {
            Debug.LogError("Filho não encontrado!");
        }
    }
    
    void OnDisable()
    {

        SolarSystemManager.ChangeSlot(Location);
        SolarSystemManager.ChangeAnswer(Location, 0);
        SolarSystemManager.CheckResult();
    }
}
