using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject player;
    public GameObject Center;
    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    [SerializeField]
    private int step = 9;
    bool input = true;
    bool isNext = true;                     //이동할 방향에 발판의 유무
    public float speed = 0.01f;
    private RaycastHit hitinfo;
    // Update is called once per frame

    void Update()
    {
        if (input == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                StartCoroutine("MoveUp");
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine("MoveDown");
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine("MoveLeft");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine("MoveRight");
            }
        }
    }

    //큐브 이동

    //위로 이동
    IEnumerator MoveUp()
    {
        input = false;
        for (int i = 0; i <= (90 / step); i++)                                              //90도 회전
        {
            player.transform.RotateAround(Up.transform.position, Vector3.right, step);      //x축기준으로 Up
            yield return new WaitForSeconds(speed);
            if (i == 2)
            {
                if (Physics.Raycast(player.transform.position, player.transform.forward, 4))
                {
                    input = true;
                    PositionSet();
                    RotationSet();
                    yield break;
                }
            }
            if (i > (45 / step))
            {
                if (!Physics.Raycast(player.transform.position, player.transform.forward, 4))
                {
                    isNext = false;
                    break;
                }
            }
        }
        if (!isNext)
        {
            for (int i = 0; i <= (45 / step); i++)
            {
                player.transform.RotateAround(Up.transform.position, Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }
            isNext = true;
        }
        player.transform.position = new Vector3(player.transform.position.x, 2, player.transform.position.z);
        Center.transform.position = player.transform.position;
        yield return new WaitForSeconds(0.1f);
        input = true;
        PositionSet();
        RotationSet();
    }
    IEnumerator MoveDown()
    {
        input = false;
        for (int i = 0; i <= (90 / step); i++)
        {
            player.transform.RotateAround(Down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
            if (i == 2)
            {
                if (Physics.Raycast(player.transform.position, player.transform.forward * (-1), 4))
                {
                    input = true;
                    PositionSet();
                    RotationSet();
                    yield break;
                }
            }
            if (i > (45 / step))
            {
                if (!Physics.Raycast(player.transform.position, player.transform.forward * (-1), 4))
                {
                    isNext = false;
                    break;
                }
            }
        }
        if (!isNext)
        {
            for (int i = 0; i <= (45 / step); i++)
            {
                player.transform.RotateAround(Down.transform.position, Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }
            isNext = true;
        }
        player.transform.position = new Vector3(player.transform.position.x, 2, player.transform.position.z);
        Center.transform.position = player.transform.position;
        yield return new WaitForSeconds(0.1f);
        input = true;
        PositionSet();
        RotationSet();
    }
    IEnumerator MoveLeft()
    {
        input = false;
        
        for (int i = 0; i <= (90 / step); i++)
        {
            player.transform.RotateAround(Left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
            if (i == 2)
            {
                if (Physics.Raycast(player.transform.position, player.transform.right * (-1), 4))
                {
                    input = true;
                    PositionSet();
                    RotationSet();
                    yield break;
                }
            }
            if (i > (45 / step))
            {
                if (!Physics.Raycast(player.transform.position, player.transform.right * (-1), 4))
                {
                    isNext = false;
                    break;
                }
            }
        }
        if (!isNext)
        {
            for (int i = 0; i <= (45 / step); i++)
            {
                player.transform.RotateAround(Left.transform.position, Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }
            isNext = true;
        }
        player.transform.position = new Vector3(player.transform.position.x, 2, player.transform.position.z);
        Center.transform.position = player.transform.position;
        yield return new WaitForSeconds(0.1f);
        input = true;
        PositionSet();
        RotationSet();
    }
    IEnumerator MoveRight()
    {
        input = false;
        for (int i = 0; i <= (90 / step); i++)
        {
            player.transform.RotateAround(Right.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed);
            if (i == 2)
            {
                if (Physics.Raycast(player.transform.position, player.transform.right, 4))
                {
                    input = true;
                    PositionSet();
                    RotationSet();
                    yield break;
                }
            }
            if (i > (45 / step))
            {
                if (!Physics.Raycast(player.transform.position, player.transform.right, 4))
                {
                    isNext = false;
                    break;
                }
            }
        }
        if (!isNext)
        {
            for (int i = 0; i <= (45 / step); i++)
            {
                player.transform.RotateAround(Right.transform.position, Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }
            isNext = true;
        }
        player.transform.position = new Vector3(player.transform.position.x, 2, player.transform.position.z);
        Center.transform.position = player.transform.position;
        yield return new WaitForSeconds(0.1f);
        input = true;
        PositionSet();
        RotationSet();
    }
    //바닥과 x좌표 z좌표 일치
    private void PositionSet()
    {
        if (Physics.Raycast(player.transform.position, new Vector3(0, -1, 0), out hitinfo, 4))
        {
            player.transform.position = new Vector3(hitinfo.transform.position.x, 2, hitinfo.transform.position.z);
        }
    }
    //rotaition값 (0,0,0)
    private void RotationSet()
    {
        if (Physics.Raycast(player.transform.position, new Vector3(0, -1, 0), out hitinfo, 4))
        {
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
