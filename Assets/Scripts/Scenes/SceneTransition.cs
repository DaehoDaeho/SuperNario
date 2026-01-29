using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    public static SceneTransition instance;

    private void Awake()
    {
        instance = this;

        // 씬이 파괴돼도 오브젝트가 파괴되지 않도록 해주는 함수.
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextScene(string nextSceneName)
    {
        StartCoroutine(FadeOut(nextSceneName));
    }

    IEnumerator FadeOut(string nextSceneName)
    {
        fadeImage.gameObject.SetActive(true);

        // 무한 반복 처리.
        while(true)
        {
            Color color = fadeImage.color;
            color.a += 0.005f;
            if(color.a >= 1.0f)
            {
                color.a = 1.0f;
                fadeImage.color = color;
                break;
            }

            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }

    public void FadeIn()
    {
        StartCoroutine(CoFadeIn());
    }

    IEnumerator CoFadeIn()
    {
        fadeImage.gameObject.SetActive(true);

        // 무한 반복 처리.
        while (true)
        {
            Color color = fadeImage.color;
            color.a -= 0.005f;
            if (color.a <= 0.0f)
            {
                color.a = 0.0f;
                fadeImage.color = color;
                fadeImage.gameObject.SetActive(false);
                break;
            }

            fadeImage.color = color;
            yield return null;
        }
    }
}
