using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CreditsScroll : MonoBehaviour
{
    public RectTransform creditsContainer;
    public float scrollSpeed = 90f;
    public string menuSceneName = "MainMenu";

    [Header("Fade")]
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1.5f;
    public float fadeExtraDistance = 200f; // quanto passa depois do último texto

    RectTransform canvasRect;
    bool fading = false;

    void Start()
    {
        canvasRect = creditsContainer.GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        // Força cálculo correto do layout
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(creditsContainer);

        if (fadeCanvas != null)
            fadeCanvas.alpha = 0f;
    }

    void Update()
    {
        if (fading) return;

        creditsContainer.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Posição do fundo do container
        float creditsBottom =
            creditsContainer.anchoredPosition.y - creditsContainer.rect.height;

        // Topo visível do canvas
        float canvasTop = canvasRect.rect.height / 2f;

        // Começa fade quando o conteúdo já saiu mesmo do ecrã
        if (creditsBottom > canvasTop + fadeExtraDistance)
        {
            StartCoroutine(FadeAndExit());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }

    IEnumerator FadeAndExit()
    {
        fading = true;

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = t / fadeDuration;
            yield return null;
        }

        fadeCanvas.alpha = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}