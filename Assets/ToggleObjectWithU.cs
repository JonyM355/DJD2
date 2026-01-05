using UnityEngine;

public class ToggleObjectWithU : MonoBehaviour
{
    public GameObject alvo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {

            BoxCollider box = alvo.GetComponent<BoxCollider>();
            if (box != null)
                box.enabled = true;
            foreach (Transform filho in alvo.transform)
            {
                filho.gameObject.SetActive(true);
            }
        }
    }
}
