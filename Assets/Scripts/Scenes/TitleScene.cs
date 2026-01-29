using UnityEngine;

public class TitleScene : MonoBehaviour
{
    public void OnClickTitleScreen()
    {
        if(SceneTransition.instance != null)
        {
            SceneTransition.instance.LoadNextScene("SampleScene");
        }
    }
}
