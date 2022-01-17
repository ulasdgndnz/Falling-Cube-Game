using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameManager instance;

    void Awake() {
        if (instance == null)
            instance = this;
    }

    public void RestartGame() {
        //SceneManager.LoadScene("Gameplay");
    }
}