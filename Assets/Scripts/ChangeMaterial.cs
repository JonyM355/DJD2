using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material myMaterial;
    public Material myMaterial1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Object;
    void OnEnable()
    {
        Debug.Log("Teste");
         Object.GetComponent<MeshRenderer> ().material = myMaterial1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
