using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

    public string sceneName;
    public  Image progress;
    public GameObject panel;
    public Text text;
    private AsyncOperation async;
    private int currentProgress;

    void Start()
    {
        panel.SetActive(false);
        progress.fillAmount = 0;
    }
    void Update()
    {
        if (async==null)
        {
            return;
        }
        /* if (async.progress<0.9)
         {
             progress.fillAmount = async.progress / 0.9f;
         }else
         {
             progress.fillAmount = 1;
         }*/
        if (progress.fillAmount<async.progress)
        {
            progress.fillAmount += Time.deltaTime;
            text.text =(int)( progress.fillAmount / 0.9 * 100) + "%";
        }
        if (async.progress==0.9f)
        {
            progress.fillAmount =1;
            text.text ="100%";
            async.allowSceneActivation = true;
        }
    }
    /*
     * 按钮点击事件
     * */
    public void startGame()
    {
        StartCoroutine(load());
        panel.SetActive(true);
    }

    IEnumerator load()
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        yield return async;
    }


}
