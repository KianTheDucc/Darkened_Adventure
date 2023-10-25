using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOutWindowScript : MonoBehaviour
{
    public bool jumpOutWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpOutWindow && Input.GetKeyDown(KeyCode.E))
        {
            ScenesManager.instance.LoadDeathScreen();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        jumpOutWindow = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        jumpOutWindow = false;
    }
}
