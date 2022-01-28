using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelDisplay : MonoBehaviour {
    [SerializeField] private Text levelText;
    private int level;

    void Start() {
        level = SceneManager.GetActiveScene().buildIndex + 1;
        levelText.text = "LEVEL: " + level;
    }
    void Update() {}
}
