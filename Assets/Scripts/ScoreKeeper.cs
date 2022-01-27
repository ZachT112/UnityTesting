using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;

    private void Start() {}
    private void Update() {}

    public void SetScore(int score) {
        this.score = score;
    }
    public int GetScore() {
        return score;
    }

    public void Log() {
        Debug.Log(score);
    }

    public static ScoreKeeper operator ++(ScoreKeeper scoreKeeper) {
        scoreKeeper.score++;
        return scoreKeeper;
    }
    public static ScoreKeeper operator --(ScoreKeeper scoreKeeper) {
        scoreKeeper.score--;
        return scoreKeeper;
    }
    public static ScoreKeeper operator +(ScoreKeeper scoreKeeper, int score) {
        scoreKeeper.score += score;
        return scoreKeeper;
    }
    public static ScoreKeeper operator -(ScoreKeeper scoreKeeper, int score) {
        scoreKeeper.score -= score;
        return scoreKeeper;
    }
}
