using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    public string sceneName = "GameStage";
    [SerializeField]
    GameObject cube;
    
    // Update is called once per frame
    void Update()
    {
        cube.transform.Rotate(new Vector3(10f, 20f, 30f) * Time.deltaTime, Space.World);
        
    }
    public void ClickPlay()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ClickQuit()
    {
        Application.Quit();
    }
}
