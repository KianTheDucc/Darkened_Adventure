using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentTBScript : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color(1f, 1f, 1f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
