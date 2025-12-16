using UnityEngine;

public class Increment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject periodicTable;
    void OnEnable()
    {
        PeriodicTableManager periodicTableManager = periodicTable.GetComponent<PeriodicTableManager>();
        periodicTableManager.Increment();
    }
    void OnDisable()
    {
        PeriodicTableManager periodicTableManager = periodicTable.GetComponent<PeriodicTableManager>();
        periodicTableManager.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
