using System.Collections.Generic;
using UnityEngine;

public class ExamineObjects : MonoBehaviour
{
    public GameObject offset;

    public bool IsExamining = false;
    public PlayerMovement playerMovement;
    private Vector3 LastMousePosition;
    private bool lastState;
    private Transform ExaminedObject;
    private Collider MyCollider;
    public Vector3 customOffset;
    private Dictionary<Transform, Vector3> OriginalPosition = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> OriginalRotation = new Dictionary<Transform, Quaternion>();
    
    void Start()
    {
        MyCollider = GetComponent<Collider>();
    }


    void Update()
    {
      
        if (IsExamining && Input.anyKeyDown)
            IsExamining = false;

      
        if (IsExamining && !lastState)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    ExaminedObject = hit.transform;
                    StartExamination();
                }
            }
        }

   
        if (IsExamining)
        {
            Examine();
        }


        if (!IsExamining && lastState)
        {
            StopExamination();
        }

        
        if (!IsExamining && ExaminedObject != null)
        {
            NonExamine();
        }

        lastState = IsExamining;
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

        Debug.Log(ExaminedObject.rotation);
        if (ExaminedObject != null)
        {
            if (!OriginalPosition.ContainsKey(ExaminedObject))
            {
                OriginalPosition[ExaminedObject] = ExaminedObject.position;
                OriginalRotation[ExaminedObject] = ExaminedObject.localRotation;
            }
        }
        if (MyCollider != null)
            MyCollider.enabled = false;
        lastState = IsExamining;
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
        Debug.Log(OriginalPosition[ExaminedObject]);
        Debug.Log(OriginalRotation[ExaminedObject]);
    }

    

    void Examine()
    {
        if (ExaminedObject != null)
        {
            Vector3 targetPos = offset.transform.position + customOffset;
            ExaminedObject.position = Vector3.Lerp(ExaminedObject.position, targetPos, 0.2f);

            Vector3 DeltaMouse = Input.mousePosition - LastMousePosition;
            float RotationSpeed = 0.2f;
            ExaminedObject.Rotate(DeltaMouse.x * RotationSpeed * Vector3.up, Space.Self);
            ExaminedObject.Rotate(DeltaMouse.y * RotationSpeed * Vector3.left, Space.Self);
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
            if (MyCollider != null)
                MyCollider.enabled = true;
        }
    }
}
