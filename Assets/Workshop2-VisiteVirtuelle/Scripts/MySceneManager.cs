using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine.UI;
using System.Collections;

public class MySceneManager : MonoBehaviour
{   
    public Canvas canvas;
    public NetworkManager networkManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void startHost()
    {
        networkManager.StartHost();
        SceneManager.LoadScene("Lab", LoadSceneMode.Single);
        //StartCoroutine(LoadSceneAndStartHost());

        Debug.Log("Host started");

    }
    IEnumerator LoadSceneAndStartHost()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Lab");

        // Wait until the scene is loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Debug.Log("Host startedz");

        // Start the server/host
        networkManager.StartHost();

    }
    public void startClient()
    {
        SceneManager.LoadScene("Lab", LoadSceneMode.Single);
        NetworkManager.Singleton.StartClient();
    }

}
