using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ListChildren : MonoBehaviour
{
    public List<Transform> childrenList = new List<Transform>();
    public GameObject group;
    public GameObject ErrorBox;
    public GameObject SuccessBox;
    public TextMeshProUGUI Error;
    public TextMeshPro ButtonText;
    public Button ButtonBody;
    public bool buttonClicked;
    private string ErrorMessage;
    public VideoPlayer video;

    void Start()
    {
        // Loop through all children and add them to the list
        for (int i = 0; i < group.transform.childCount; i++)
        {
            Transform child = group.transform.GetChild(i);
            childrenList.Add(child);
        }
        ErrorBox.SetActive(false);
        SuccessBox.SetActive(false);
        video.Pause();
        StartCoroutine(WaitForButtonPress());
    }

    public void OnButtonClick(){
        buttonClicked = true;
    }

    private IEnumerator WaitForButtonPress()
    {   
        buttonClicked = false;
        yield return new WaitUntil(() => ButtonBody.isButtonPressed);
        video.Play();
        yield return new WaitForSeconds(3f);
        buttonClicked = false;
        ButtonText.text = "Continuer";
        for(int i = 0; i < 5; i++)
        {   
            int randomID = Random.Range(0,childrenList.Count);
            serverRack server = childrenList[randomID].GetComponent<serverRack>();
            
            ErrorBox.SetActive(true);
            video.Pause();
            ErrorMessage = "Erreur : Téléchargement bloqué. Redémarrer Serveur " + server.rackNumber + " pour continuer";
            Error.text = ErrorMessage;
            server.errorTrigger = true;
            yield return new WaitUntil(() => server.buttonPressed);
            ErrorBox.SetActive(false);
            buttonClicked = false;
            yield return new WaitUntil(() => ButtonBody.isButtonPressed);
            buttonClicked = false;
            video.Play();
            yield return new WaitForSeconds(3f);
        } 
            SuccessBox.SetActive(true);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("End");
    }
}
