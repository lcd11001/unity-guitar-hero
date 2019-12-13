using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int multiplier = 1;
    int streak = 0;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Multiplier", multiplier);
        PlayerPrefs.SetInt("Score", score);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy(other.gameObject);
    }

    int GetScore()
    {
        return 100 * multiplier;
    }

    public void AddScore()
    {
        score += GetScore();
        UpdateGUI();
    }

    public void AddStreak()
    {
        streak++;
        multiplier = (streak / 4) + 1;
        UpdateGUI();
    }

    public void ResetStreak()
    {
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }
}
