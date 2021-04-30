using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public bool isOn = false;
    public bool onFlag = false;
    public bool isClear = false;
    RaycastHit hitInfo;
    // Start is called before the first frame update
    [SerializeField]
    StageManager SM;

    void OnEnable()
    {
        isOn = false;
        onFlag = false;
        isClear = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isClear)
        {
            Checking();
            CheckingOn();
        }
    }
    private void Checking()
    {
        if (Physics.Raycast(this.transform.position, new Vector3(0, 1, 0), out hitInfo))         //큐브가 발판위에 있을 때
        {
            isOn = true;
            onFlag = true;

            if (GameObject.Find("Paint_Red") == gameObject)
                hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            else if (GameObject.Find("Paint_Blue") == gameObject)
                hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.blue;
            else if (GameObject.Find("Floor_Start") == gameObject)
                hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.black;

            if (GameObject.Find("Floor_Red") == gameObject)
            {
                if (hitInfo.transform.GetComponent<MeshRenderer>().material.color == Color.red)
                {
                    GameObject.Find("Obstacle_Red").SetActive(false);
                    hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.black;
                }
            }
            else if (GameObject.Find("Floor_Blue") == gameObject)
            {
                if (hitInfo.transform.GetComponent<MeshRenderer>().material.color == Color.blue)
                {
                    GameObject.Find("Obstacle_Blue").SetActive(false);
                    hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.black;
                }
            }

            if (GameObject.Find("Goal") == gameObject && hitInfo.collider.gameObject == GameObject.Find("Cube") && !isClear)
            {
                Debug.Log("클리어");
                isClear = true;
                SM.ShowClearUI();
            }
        }
        else                                                                        //큐브가 발판위에 없을 때
            isOn = false;
    }
    private void CheckingOn()
    {
        if (isOn == false && onFlag == true && GameObject.Find("Goal") != gameObject)                                        //큐브가 발판위에 있다가 다른 곳으로 이동할 때
        {
            gameObject.SetActive(false);                    //발판 제거
            isOn = true;
            onFlag = true;
        }
    }
}
