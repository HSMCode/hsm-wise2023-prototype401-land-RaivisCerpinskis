using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    public void Gameover()
    {
        SceneManager.LoadScene("SampleScene");
    }

}