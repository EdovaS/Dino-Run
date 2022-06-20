using UnityEngine;
using UnityEngine.UI;

namespace DinoRunGame.Managers.ScoreManager
{
    public class Score : MonoBehaviour
    {
        public Text HighScoreText;
        [SerializeField] private Text scoreGameOverText;
        private int score;
        private Text scoreText;

        public int GetScore() { return score;}

        private float timer;
        private float maxTime;
        [SerializeField] private GameObject _buttonAndScreen;

        private void Start()
        {
            HighScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString("00000");
            score = 0;
            scoreText = GetComponent<Text>();
            maxTime = 0.1f;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                if (_buttonAndScreen.activeSelf == false)
                {
                    score++;
                    scoreText.text = score.ToString("00000");
                    scoreGameOverText.text = scoreText.text;
                    timer = 0;    
                }
                
            }

            if (_buttonAndScreen.activeSelf)
            {
                if (score > PlayerPrefs.GetInt("highscore", 0))
                {
                    PlayerPrefs.SetInt("highscore", score);
                    HighScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString("00000");

                }
            }
        }
    }
}
