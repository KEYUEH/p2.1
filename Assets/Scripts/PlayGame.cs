using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame: MonoBehaviour
{

    public Button mButton;

    // Use this for initialization
    void Start()
    {
        //Gets ButtonMount
        Button btnMount = mButton.GetComponent<Button>();
        //add a listener to ButtonMount, executing TaskOnClick() when click ButtonMount
        btnMount.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Loading Scene1
        //SceneManager.LoadScene(1);
        if ((SceneManager.GetActiveScene().buildIndex) == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if ((SceneManager.GetActiveScene().buildIndex) == 1)
        {
            SceneManager.LoadScene(0);
        }
    
    }
}