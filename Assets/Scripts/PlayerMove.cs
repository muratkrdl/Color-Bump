using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float restartGameDelay = 1f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowness = 20f;
    [SerializeField] Rigidbody myRigid;

    Vector2 lastMousePos;
    bool isCollide = false;

    void Update()
    {
        if(isCollide) { return; }

        Move();
    }

    void Move()
    {
        Vector2 deltaPos = Vector2.zero;

        if(Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;

            if(lastMousePos == Vector2.zero)
            {
                lastMousePos = currentMousePos;
            }

            deltaPos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;

            Vector3 force = new Vector3(deltaPos.x, 0, deltaPos.y) * moveSpeed * Time.fixedDeltaTime;
            myRigid.AddForce(force);
        }
        else
        {
            lastMousePos = Vector2.zero;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Line"))
        {
            if(FindObjectOfType<CameraFollow>().moveable != true)
                FindObjectOfType<CameraFollow>().moveable = true;
        }

        if(other.gameObject.CompareTag("FinishLine"))
        {
            Time.timeScale = 0;
            GameManager.Instance.ShowWinUI();
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            isCollide = true;
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime /= slowness;

        yield return new WaitForSeconds(restartGameDelay / slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime *= slowness;

        Time.timeScale = 0;

        GameManager.Instance.ShowLoseUI();
    }

}
