using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame2");
    }
}
