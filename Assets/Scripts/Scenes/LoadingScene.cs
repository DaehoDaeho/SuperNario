using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "SampleScene";

    [SerializeField]
    private TMP_Text loadingText;

    [SerializeField]
    private Image progressFillImage;

    private AsyncOperation op;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneTransition.instance != null)
        {
            SceneTransition.instance.FadeInEvent += StartLoadGameScene;
            SceneTransition.instance.FadeIn();
        }
    }

    void StartLoadGameScene()
    {
        // 코루틴 함수를 호출해서 비동기로 다음 씬을 로딩하고, 로딩 진행률을 UI에 표시한다.
        StartCoroutine(LoadGameScene());
    }

    private IEnumerator LoadGameScene()
    {
        // 백그라운드에서 비동기로 씬을 로딩.
        op = SceneManager.LoadSceneAsync(gameSceneName);

        // 로딩이 끝났을 때 바로 씬 전환을 할 지 여부.
        op.allowSceneActivation = false;

        // isDond : 씬 로딩이 끝났는지 여부.
        while(op.isDone == false)
        {
            float raw = op.progress;    // 0.0f ~ 0.9f

            // Clamp01 : 파라미터로 전달한 값이 0 ~ 1 사이의 범위를 벗어나지 않게 보정해주는 함수.
            float normalized = Mathf.Clamp01(raw / 0.9f); // 0.0f ~ 1.0f

            if(progressFillImage != null)
            {
                progressFillImage.fillAmount = normalized;                
            }

            if(loadingText != null)
            {
                // RoundToInt : 파라미터로 전달된 값을 반올림 해서 정수형 값으로 반환해주는 함수.
                int percent = Mathf.RoundToInt(normalized * 100.0f);
                loadingText.text = "로딩 중... " + percent.ToString() + "%";
            }

            // 조건이 만족하면 로딩이 완료된 것으로 간주.
            if (raw >= 0.9f)
            {
                if (SceneTransition.instance != null)
                {
                    // 개선의 여지가 있는 코드.
                    // 게임 씬 뿐만 아니라 어느 씬이든 이동이 가능하도록 코드를 개선할 필요가 있다.
                    SceneTransition.instance.FadeOutEvent += LoadToGameScene;
                    SceneTransition.instance.StartFadeOut();
                }
            }

            yield return null;
        }
    }

    void LoadToGameScene()
    {
        op.allowSceneActivation = true;
    }
}
