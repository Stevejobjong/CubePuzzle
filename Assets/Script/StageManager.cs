using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    GameObject clear_UI;

    [SerializeField]
    GameObject pause_UI;

    [SerializeField]
    GameObject[] stages;
    int currentStage = 0;

    [SerializeField]
    GameObject[] Map;


    [SerializeField]
    Rigidbody cubeRigid;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text txt;
    public void Start()
    {
        SetStageTxt();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_UI.SetActive(true);
        }
    }
    private void SetStageTxt()
    {
        txt.text = "Stage " + (currentStage + 1).ToString();
    }
    public void ShowClearUI()
    {
        clear_UI.SetActive(true);
    }

    public void NextBtn()
    {
        if (currentStage < stages.Length - 1)
        {
            clear_UI.SetActive(false);
            stages[currentStage++].SetActive(false);

            //
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].transform.localPosition = new Vector3(0, 2, 0);
            }
            cubeRigid.gameObject.transform.position = new Vector3(0, 0, 0);
            //
            
            stages[currentStage].SetActive(true);
            if (cubeRigid.gameObject.transform.position == new Vector3(0, 0, 0))
            {
                Invoke("BuildMap", 0.05f);
            }
            SetStageTxt();

        }
        else
        {
            Debug.Log("모든 스테이지 클리어");
        }
    }

    public void RestartBtn()
    {

        clear_UI.SetActive(false);
        pause_UI.SetActive(false);
        //
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.localPosition = new Vector3(0, 2, 0);
        }
        cubeRigid.gameObject.transform.position = new Vector3(0, 0, 0);
        int count = Map[currentStage].transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Map[currentStage].transform.GetChild(i).gameObject.SetActive(false);
        }


        if (cubeRigid.gameObject.transform.position == new Vector3(0, 0, 0))
        {
            BuildMap();
            Invoke("BuildMap", 0.05f);
        }

        SetStageTxt();
    }
    public void ResumeBtn()
    { 
        pause_UI.SetActive(false);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
    public void BuildMap()
    {
        int count = Map[currentStage].transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Map[currentStage].transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
