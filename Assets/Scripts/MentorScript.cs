using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MentorScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI messageText;

    public string[] stringArray;

    [SerializeField] float timeBtwnChars;

    [SerializeField] float timeBtwnWords;

    public bool enableWriting;

    int i = 0;

    private void Awake()
    {
        messageText = transform.Find("messageText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        stringArray[0] = "Wait! (Press R)";
        stringArray[1] = "The land of Zarakorch still needs you.";
        stringArray[2] = "Come with me and you have a chance to save everyone.";
        stringArray[3] = "A chance to save everyone from the tyrant that is the abyssal king...";



    }
    private void Update()
    {
        if (enableWriting && Input.GetKeyDown(KeyCode.R))
        {
            
            Debug.Log("button pressed");
            EndCheck();

        }
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

        enableWriting = true;
        //EndCheck();


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enableWriting = false;
    }

}

