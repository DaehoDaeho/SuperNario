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

    void LoadToLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
