using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void OnClickTitleScreen()
    {
        if(SceneTransition.instance != null)
        {
            // 이벤트 함수 등록.
            SceneTransition.instance.FadeOutEvent += LoadToLoadingScene;
            SceneTransition.instance.StartFadeOut();
        }
    }

    void OnDisable()
    {
        if (SceneTransition.instance != null)
        {
            // 이벤트 함수 등록 해제.
            SceneTransition.instance.FadeOutEvent -= LoadToLoadingScene;
        }
    }

    void OnDestroy()
    {
        if (SceneTransition.instance != null)
        {
            // 이벤트 함수 등록 해제.
            SceneTransition.instance.FadeOutEvent -= LoadToLoadingScene;
        }
    }

    void LoadToLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
