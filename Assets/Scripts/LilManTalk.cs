using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LilManTalk : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI messageText;

    public string[] stringArray;

    [SerializeField] float timeBtwnChars;

    [SerializeField] float timeBtwnWords;

    int i = 0;

    private bool CanMoveOn;

    private void Awake()
    {
        messageText = transform.Find("messageText").GetComponent<TextMeshProUGUI>();
    }


    private void Start()
    {
        CanMoveOn = false;
        stringArray[0] = "Please help me!";
        stringArray[1] = "My family are being help captive in one of the abyssal king's deepest prisons.";
        stringArray[2] = "Oh?";
        stringArray[3] = "You're going there anyway?";
        stringArray[4] = "Perfect!";
        stringArray[5] = "I'll come along with you and maybe I could be of some help!";


    }


    private void Update()
    {
        if (CanMoveOn && Input.GetKeyDown(KeyCode.R))
        {
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
        CanMoveOn = true;
        EndCheck();
    }
}
