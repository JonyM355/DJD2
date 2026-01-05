using UnityEngine;

public class PressButton : MonoBehaviour
{
    public ControlPanelManager ControlPanelManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callAnimationEvent()
    {
        ControlPanelManager.ChangeAnswer(this.name);
    }
}
