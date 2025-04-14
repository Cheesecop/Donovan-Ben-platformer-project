using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public CharController charController;
    
    public TMP_Text livesText;


    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + charController.lives; //Lives text is set to the number of lives


    }

    public void PlayPressed(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitPressed()
    {
        Application.Quit();
    }

}