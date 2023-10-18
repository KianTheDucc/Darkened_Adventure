using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_Assistant : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI messageText;

    public string[] stringArray;

    [SerializeField] float timeBtwnChars;

    [SerializeField] float timeBtwnWords;

    int i = 0;


    
    private void Awake()
    {
        messageText = transform.Find("messageText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        stringArray[0] = "";
        

        
    }

    public void EndCheck()
    {
        if (i <= stringArray.Length - 1)
        {
            messageText.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible()
    {
        messageText.ForceMeshUpdate();
        int totalVisibleCharacters = messageText.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            
            messageText.maxVisibleCharacters = visibleCount;
            
            if (visibleCount >= totalVisibleCharacters)
            {
                i++;
                break;
            }

            counter++;

            
            yield return new WaitForSeconds(timeBtwnChars);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stringArray[0] = "You contemplate jumping out the window, to do it, press E";
        EndCheck();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {

            ScenesManager.instance.LoadDeathScreen();

        }
    }

}
