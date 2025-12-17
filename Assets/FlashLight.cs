using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 3f))
        {
            if (hit.collider.CompareTag("HiddenTexture"))
            {
                hit.collider.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
