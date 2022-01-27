using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    [SerializeField] private ScoreKeeper scoreKeeper;
    [SerializeField] Text scoreText;

    void Start() {}
    void Update() {
        scoreText.text = "SCORE: " + scoreKeeper.GetScore();
    }
}
