using UnityEngine;

public class PeriodicTableManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int value;
    public Animator targetAnimator;

    void Start()
    {
        value = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Increment()
    {
        value++;
        if(value >= 3)
            targetAnimator.SetTrigger("Open");
       
    }
    public void Reset()
    {
        value=0;
    }
}
