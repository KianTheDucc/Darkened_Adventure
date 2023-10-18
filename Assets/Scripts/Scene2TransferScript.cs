using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2TransferScript : MonoBehaviour
{
    private bool CanMoveOn;

    private void Start()
    {
        CanMoveOn = false;
    }
    private void Update()
    {
        if (CanMoveOn)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("The_Dark_Revival");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanMoveOn = true;
    }
}
