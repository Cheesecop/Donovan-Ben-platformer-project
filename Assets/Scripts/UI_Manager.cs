using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public PlayerMove PlayerMove;

    public TMP_Text livesText;


    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + PlayerMove.lives; //Lives text is set to the number of lives


    }
}