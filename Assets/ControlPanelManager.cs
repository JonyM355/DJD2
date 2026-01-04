using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlPanelManager : MonoBehaviour
{
    private const string Solution = "5104";
    private string UserAnswer = "";

    public TMP_Text label;

    bool canInput = true;

    //public AudioSource AudioSource;
    //public AudioClip ButtonPress;
    //public AudioClip RightAnswer;

    public CanvasGroup fadePanel;   // <-- arrasta o FadePanel aqui no Inspector

    void Start()
    {
        label.text = "";
    }

    public void ChangeAnswer(string value)
    {
        if (!canInput)
            return;

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
                StartCoroutine(WinSequence());
            }
            else
            {
                label.color = Color.red;
                StartCoroutine(ResetAfterDelay());
            }
        }
    }

    System.Collections.IEnumerator ResetAfterDelay()
    {
        canInput = false;
        yield return new WaitForSeconds(1f);

        UserAnswer = "";
        label.text = "";
        label.color = Color.white;

        canInput = true;
    }

    System.Collections.IEnumerator WinSequence()
    {
        canInput = false;

        yield return new WaitForSeconds(1f); // espera antes do fade

        // Fade out
        float t = 0f;
        while (t < 2f)
        {
            t += Time.deltaTime;
            fadePanel.alpha = t;
            yield return null;
        }

        SceneManager.LoadScene("EndScene");   // <-- nome exato da cena
    }
}