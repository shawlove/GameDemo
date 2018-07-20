using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toOtherPlace : MonoBehaviour {
    public string sceneName;
    public Image progress;
    public GameObject panel;
    public Text text;
    public Camera _camera;
    private int currentProgress;
    private GameObject player;
    private AsyncOperation async;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        panel.SetActive(false);
        progress.fillAmount = 0;
    }

    void Update()
    {
        if (async == null)
        {
            return;
        }
        if (progress.fillAmount < async.progress)
        {
            
            progress.fillAmount += Time.deltaTime;
            text.text = (int)(progress.fillAmount / 0.9 * 100) + "%";
        }
        if (async.progress == 0.9f)
        {
            progress.fillAmount = 1;
            text.text = "100%";
            async.allowSceneActivation = true;
            if (sceneController.sceneThings.ContainsKey(SceneManager.GetActiveScene().name))
            {
                sceneController.sceneThings[SceneManager.GetActiveScene().name].isMake = false;
            }
            async = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            
            //_camera.depth = 0;
            StartCoroutine(load());
            panel.SetActive(true);
            _camera.depth = 0;
        }

    }


    IEnumerator load()
    {

        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        yield return async;
    }
}
