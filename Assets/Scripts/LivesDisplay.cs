using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField]
    float baseLives = 5;

    float lives = 5;

    Text livesText;

    void Start()
    {
        lives = baseLives - (PlayerPrefsController.GetDifficulty() * 2);
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
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
