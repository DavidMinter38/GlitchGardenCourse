using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField]
    int lives = 5;

    Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void ReduceLives(int amount)
    {
        lives -= amount;
        if(lives < 0) { lives = 0; }
        UpdateDisplay();

        if(lives == 0)
        {
            FindObjectOfType<LevelLoad>().LoadGameOver();
        }
    }
}
