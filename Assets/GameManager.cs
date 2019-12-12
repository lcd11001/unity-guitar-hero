using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int multiplier = 2;
    int streak = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy(other.gameObject);
    }

    public int GetScore()
    {
        return 100 * multiplier;
    }

    public void AddStreak()
    {
        streak++;
        multiplier = (streak / 4) + 1;
    }

    public void ResetStreak()
    {
        streak = 0;
        multiplier = 1;
    }
}
