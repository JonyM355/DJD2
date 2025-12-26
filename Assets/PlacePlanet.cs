using UnityEngine;
using UnityEngine.UIElements;

public class PlacePlanet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] SolarSystemManager SolarSystemManager;
    public Transform hand;
    private int Location;
    private InteractionManager  _interactionManager;
    private PlayerInventory     _playerInventory;
    void Start()
    {
        if (int.TryParse(gameObject.name, out Location))
            Debug.Log(Location); // 123
        else
            Debug.Log("Invalid number");


    }
    void Awake()
    {
        _interactionManager = FindObjectOfType<InteractionManager>();
        _playerInventory    = _interactionManager.playerInventory;
    }

    void OnEnable()
    {
        Transform activeChild = null;
        for (int i = 0; i < hand.childCount; i++)
        {
            Transform child = hand.GetChild(i);

            if (child.gameObject.activeSelf)   // ou activeInHierarchy
            {
                activeChild = child;
                break;
            }
        }

        Interactive requirement = _playerInventory.GetSelected();
        if (activeChild != null)
        {
            activeChild.position = transform.position;
            //child.rotation = transform.rotation;
            Debug.Log(int.Parse(activeChild.name));
            activeChild.SetParent(transform);
            _playerInventory.Remove(requirement);
            SolarSystemManager.ChangeSlot(Location);
            SolarSystemManager.ChangeAnswer(Location, int.Parse(activeChild.name));
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
