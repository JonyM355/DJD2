using Unity.Multiplayer.Center.Common;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
public class SolarSystemManager : MonoBehaviour
{
    public Animator animator;
    private static readonly int[] Solution = { 0, 1, 0, 0 };
    private int[] UserAnswer = { 0, 0, 0, 0 };

    private bool[] SlotManager = { false, false, false, false }; //false - Slot Free, True - Slot Occupied

    
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
        if (position < 3 && planet < 4 && position >= 0 && planet > 0)
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
        Debug.Log(UserAnswer);
        Debug.Log(Solution);
        if (UserAnswer.SequenceEqual(Solution))
        {
            animator.SetTrigger("OpenLamp");
        }
        else
        {
            animator.SetTrigger("CloseLamp");
        }
    }
}
