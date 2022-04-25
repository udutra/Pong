using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    private int paddle1Score, paddle2Score;

    [SerializeField] private GameObject panelWin;
    [SerializeField] private TMP_Text paddle1ScoreText, paddle2ScoreText, panelWinText;
    [SerializeField] private Transform paddle1Transform, paddle2Transform, ballTransform;
    [SerializeField] private int maxScore;

    public static GameManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Start() {
        panelWin.SetActive(false);
    }

    public void Paddle1Scored() {
        paddle1Score++;
        paddle1ScoreText.text = paddle1Score.ToString();
    }

    public void Paddle2Scored() {
        paddle2Score++;
        paddle2ScoreText.text = paddle2Score.ToString();
    }

    public void Restart() {

        if (paddle1Score >= maxScore) {
            FinishedGame("Player 1 Win");
        }
        else if (paddle2Score >= maxScore) {
            FinishedGame("Player 2 Win");
        }
        else {
            ResetPosition();
        }
    }

    private void FinishedGame(string message) {
        panelWinText.text = message;
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }

    private void ResetPosition() {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }

    public void RestartGame() {
        panelWin.SetActive(false);
        Time.timeScale = 1;
        paddle1Score = 0;
        paddle1ScoreText.text = paddle1Score.ToString();
        paddle2Score = 0;
        paddle2ScoreText.text = paddle2Score.ToString();
        ResetPosition();
    }
}
