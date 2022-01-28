using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    [SerializeField] private Text scoreText;

    private void Start() {}
    private void Update() {
        scoreText.text = "SCORE: " + ScoreKeeper.instance.GetScore();
    }
}
