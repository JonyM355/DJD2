using UnityEngine;
using TMPro;


public class DoubleDoorInteractive : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip doorOpenAnimation;
    [SerializeField] private AnimationClip doorCloseAnimation;
    [SerializeField] private AudioSource doorAudioSource;
    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorCloseSound;

    [Header("Interaction Settings")]
    [SerializeField] private float interactDistance = 1.5f;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private Camera playerCamera;

    private bool isOpen = false;

    private void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Verifica se o jogador está olhando para a porta
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject == gameObject || hit.collider.transform.parent.gameObject == gameObject)
            {
                // Mostra texto de interação
                interactText.gameObject.SetActive(true);

                // Muda a mensagem conforme a porta
                if (isOpen)
                    interactText.text = "Press E to Close";
                else
                    interactText.text = "Press E to Open";

                // Verifica input
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isOpen) CloseDoor();
                    else OpenDoor();
                }
            }
            else
            {
                interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        animator.Play(doorOpenAnimation.name);
        doorAudioSource.PlayOneShot(doorOpenSound);
        isOpen = true;
    }

    private void CloseDoor()
    {
        animator.Play(doorCloseAnimation.name);
        doorAudioSource.PlayOneShot(doorCloseSound);
        isOpen = false;
    }
}
