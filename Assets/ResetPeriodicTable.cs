using UnityEngine;

public class ResetPeriodicTable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator button1, button2, button3;
    void OnEnable()
    {

        button1.SetTrigger("Reset");
        button2.SetTrigger("Reset");
        button3.SetTrigger("Reset");
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
