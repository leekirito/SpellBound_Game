using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gmScript : MonoBehaviour
{
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject box5;
    public GameObject box6;
    public GameObject box7;
    public GameObject box8;
    public GameObject box9;
    public GameObject lineRenderer;
    public static string currentWord = "";
    public Transform spelledWord;

    string[] words = {"LEAP","PALE", "APE"};

    // Update is called once per frame
    void Update()
    {
        spelledWord.GetComponent<TextMesh>().text = currentWord;
        checkedWord();
    }

    public void checkedWord(){
        for(int i = 0; i < words.Length; i++){
            if(currentWord.Equals(words[i])){
                if(currentWord.Equals("LEAP")){
                    box1.SetActive(true);
                    box2.SetActive(true);
                    box3.SetActive(true);
                    box4.SetActive(true);
                }else if(currentWord.Equals("APE")){
                    box6.SetActive(true);
                    box8.SetActive(true);
                    box9.SetActive(true);
                }else if(currentWord.Equals("PALE")){
                    box7.SetActive(true);
                    box6.SetActive(true);
                    box5.SetActive(true);
                    box2.SetActive(true);
                }
                currentWord = "";
                lineRenderer.GetComponent<LineRenderController>().ClearLine();
            }
        }
    }
}
