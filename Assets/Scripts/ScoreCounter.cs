using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score;
    private float updateInterval = 0.1f;
    private float timer;
    private bool counting = true;

    void Start()
    {
        score = 0;
        timer = 0f;
        UpdateScoreText();
    }

    void Update()
    {
        if (counting)
        {
            timer += Time.deltaTime;
            if (timer >= updateInterval)
            {
                score++;
                UpdateScoreText();
                timer = 0f;
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString("D9");
    }

    public void StopCounting()
    {
        counting = false;
    }
}
