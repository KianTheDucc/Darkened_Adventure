using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JumpOffBridge : MonoBehaviour
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
        stringArray[0] = "You once again contemplate ending it all and jumping off the bridge, to do it, press E";


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
        
        EndCheck();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            SceneManager.LoadScene("Death_Screen");

        }
    }
}
