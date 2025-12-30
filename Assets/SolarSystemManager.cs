using Unity.Multiplayer.Center.Common;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
public class SolarSystemManager : MonoBehaviour
{
    public Animator animator;
    private static readonly int[] Solution = { 0, 1, 2, 3 };
    private int[] UserAnswer = { -1, -1, -1, -1 };

    private bool[] SlotManager = { false, false, false, false }; //false - Slot Free, True - Slot Occupied
    public GameObject Key;
    public GameObject Mars;
    public GameObject Venus;
    public GameObject Uranus;
    public GameObject Jupiter;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSlot(int SlotChanged)
    {
        if (SlotChanged <= 3)
        {
            if(SlotManager[SlotChanged])

            SlotManager[SlotChanged] = !SlotManager[SlotChanged];
            
        }
        else
        {
            Debug.Log("Array out of limit");
        }
    }
    public void ChangeAnswer(int position, int planet)
    {
        Debug.Log("Planet" + planet);
        Debug.Log("Position" + position);
        if (position <= 3 && planet < 4 && position >= 0 && planet >= 0)
        {
            UserAnswer[position] = planet;
        }
        else
        {
            Debug.Log("Array out of limits or that planet dont exist");
        }
    }
    public void CheckResult()
    {
        Debug.Log(string.Join(", ", UserAnswer));
        Debug.Log(string.Join(", ", Solution));
        if (UserAnswer.SequenceEqual(Solution))
        {
            Debug.Log("Answer Right");
            animator.SetTrigger("OpenLamp");
            Key.SetActive(true);
            DisableAllInteractive();
        }
        else
        {
            Debug.Log("Answer Wrong");
        }
    }
    public void DisableAllInteractive()
    {
        DisableInteractiveOn(Mars);
        DisableInteractiveOn(Venus);
        DisableInteractiveOn(Uranus);
        DisableInteractiveOn(Jupiter);
    }

    void DisableInteractiveOn(GameObject go)
    {
        if (go == null) return;

        Interactive interactive = go.GetComponent<Interactive>();

        if (interactive != null)
            interactive.enabled = false;

        BoxCollider box = go.GetComponent<BoxCollider>();
        if (box != null)
            box.enabled = false;
    }
}
