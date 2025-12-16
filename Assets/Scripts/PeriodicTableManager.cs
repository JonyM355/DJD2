using UnityEngine;

public class PeriodicTableManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int value;
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
       
    }
    public void Reset()
    {
        value=0;
    }
}
