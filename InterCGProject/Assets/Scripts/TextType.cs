using UnityEngine;
using System.Collections;
using TMPro;


public class TextType : MonoBehaviour
{
    public string[] text;
    public TextMeshProUGUI txtUI;
    public float textSpeed = 0.05f;
    public float timeBetweenWords = 0.05f;
    public TankController player;
    public bool canPress = false;
    public CamManager camManager;
    public GameObject ammoBox;

    int i = 0;
    //used this: https://www.youtube.com/watch?v=IqpgJlhtmoo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EndCheck();
    }   

    public void EndCheck()
    {
        if (i == 1)
            camManager.showShells();


        if (i <= text.Length-2)
        {
            txtUI.text= text[i];
            StartCoroutine("makeTextVisible");
        }
        else if (i >=3)
        {
            camManager.stopShowingShells();
            makeTextInvisible();
            ammoBox.SetActive(false);
        }
    }
    private void makeTextInvisible()
    {
        txtUI.gameObject.SetActive(false);
        canPress = false;
        player.isPlayerDisabled = false;
    }

    private IEnumerator makeTextVisible()
    {
        canPress = false;
        txtUI.ForceMeshUpdate();
        int totalVisibleChars = txtUI.textInfo.characterCount;
        int counter = 0;
        while (true)
        {
            player.isPlayerDisabled = true;
            int visibleCount = counter % (totalVisibleChars + 1);
            txtUI.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleChars)
            {
                i++;
                canPress = true;
                break;
                //Invoke("EndCheck",textSpeed);
            }

            counter += 1;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
