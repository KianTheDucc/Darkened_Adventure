using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MentorTalk2 : MonoBehaviour
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
        stringArray[0] = "We both know how powerful your magic is by your staff's magical aura.";
        stringArray[1] = "It is much stronger than anything i've ever seen. ";
        stringArray[2] = "If we're able to find the Abyssal King, I have no doubt you'll be able to seal him.";
        stringArray[3] = "And the kingdom will be free at last!";




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

