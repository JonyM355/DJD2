using System.Collections.Generic;
using UnityEngine;

public class ExamineObjects : MonoBehaviour
{
    public GameObject offset;

    public bool IsExamining = false;
    public PlayerMovement playerMovement;
    private Vector3 LastMousePosition;

    private Transform ExaminedObject;

    private Dictionary<Transform, Vector3> OriginalPosition = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> OriginalRotation = new Dictionary<Transform, Quaternion>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("TEste");
        if (IsExamining)
        {
            Debug.Log("TEste");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == gameObject.GetComponent<Collider>())
                {
                    if (IsExamining)
                    {
                        ExaminedObject = hit.transform;
                        OriginalPosition[ExaminedObject] = ExaminedObject.position;
                        OriginalRotation[ExaminedObject] = ExaminedObject.rotation;

                        Examine();
                        StartExamination();
                    }
                    else
                    {

                    }
                }
            }
        }
        if (IsExamining)
        {
            Examine();
            StartExamination();
        }
        else
        {
            NonExamine();
            StopExamination();
        }
    }
    public void ExamineInteractive()
    {
        ToggleExamination();
        Debug.Log(IsExamining);
    }
    private void ToggleExamination()
    {
        IsExamining = !IsExamining;
    }
    void StartExamination()
    {
        LastMousePosition = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovement.enabled = false;
    }

    void StopExamination()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.enabled = true;
    }

    void Examine()
    {
        if (ExaminedObject != null)
        {
            ExaminedObject.position = Vector3.Lerp(ExaminedObject.position, offset.transform.position, 0.2f);

            Vector3 DeltaMouse = Input.mousePosition - LastMousePosition;
            float RotationSpeed = 1.0f;
            ExaminedObject.Rotate(DeltaMouse.x * RotationSpeed * Vector3.up, Space.World);
            ExaminedObject.Rotate(DeltaMouse.y * RotationSpeed * Vector3.left, Space.World);
            LastMousePosition = Input.mousePosition;

        }
    }
    void NonExamine()
    {
        if (ExaminedObject != null)
        {
            if (OriginalPosition.ContainsKey(ExaminedObject))
            {
                ExaminedObject.position = Vector3.Lerp(ExaminedObject.position, OriginalPosition[ExaminedObject], 0.2f);
            }
            if (OriginalRotation.ContainsKey(ExaminedObject))
            {
                ExaminedObject.rotation = Quaternion.Slerp(ExaminedObject.rotation, OriginalRotation[ExaminedObject], 0.2f);
            }
        }
    }
}
