using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour {

    public class sceneThing
    {
        public Vector3 playerPosition;
        public int cameraDepth;//进入场景时，给这个场景的摄像机设置深度。比player的相机深度低。这个摄像机用于切换场景时显示加载场景进度
        public bool isMake=false;//判断这个场景是否进行了操作
    }
    public static Dictionary<string, sceneThing> sceneThings = new Dictionary<string, sceneThing>();
    private GameObject player;
    private GameObject _camera;

    void Start()
    {
        addSceneThing("Demo",new Vector3(-83.42f, 1.81f, 35.95f),-2);
        addSceneThing("Other",new Vector3(-80f, 2.17f, 30f),-2);
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    void Update()
    {
        _camera = GameObject.Find("loadCamera");
        if (sceneThings.ContainsKey(SceneManager.GetActiveScene().name)&&!sceneThings[SceneManager.GetActiveScene().name].isMake)
        {
            print("场景初始化");
            print(SceneManager.GetActiveScene().name);
            player.transform.position = sceneThings[SceneManager.GetActiveScene().name].playerPosition;
            _camera.GetComponent<Camera>().depth = sceneThings[SceneManager.GetActiveScene().name].cameraDepth;
            sceneThings[SceneManager.GetActiveScene().name].isMake = true;         
        }
    }


    private void addSceneThing(string sceneName,Vector3 position,int depth)
    {
        if (sceneThings.ContainsKey(sceneName))
        {
            sceneThings[sceneName] = new sceneThing { playerPosition = position ,cameraDepth=depth};
        }else
        {
            sceneThings.Add(sceneName,new sceneThing { playerPosition = position,cameraDepth=depth });
        }
    }
}
