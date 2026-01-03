using UnityEngine;
using TMPro;

public class ControlPanelManager : MonoBehaviour
{
    private const string Solution = "5104";
    private string UserAnswer = "";

    public TMP_Text label;

    bool canInput = true;

    public AudioSource AudioSource;
    public AudioClip ButtonPress;
    public AudioClip RightAnswer;


    void Start()
    {
        label.text = "";
    }

    public void ChangeAnswer(string value)
    {
        if (!canInput)
            return;   // BLOQUEIA a introdução enquanto espera
        //AudioSource.PlayOneShot(ButtonPress);
        UserAnswer += value;
        label.text = UserAnswer;

        CheckResult();
    }

    public void CheckResult()
    {
        if (UserAnswer.Length == 4)
        {
            if (UserAnswer == Solution)
            {
                label.color = Color.green;
                //AudioSource.PlayOneShot(RightAnswer);
            }
            else
            {
                label.color = Color.red;

                // espera 1 segundo e desbloqueia
                StartCoroutine(ResetAfterDelay());
            }
        }
    }

    System.Collections.IEnumerator ResetAfterDelay()
    {
        canInput = false;      // bloqueia
        yield return new WaitForSeconds(1f);

        UserAnswer = "";
        label.text = "";
        label.color = Color.white;

        canInput = true;       // desbloqueia
    }
}