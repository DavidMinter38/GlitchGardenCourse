using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{

    [SerializeField]
    float stars = 200;

    Text starsText;

    void Start()
    {
        starsText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starsText.text = stars.ToString();
    }

    public bool HaveEnoughStars(float amount)
    {
        return stars >= amount;
    }

    public void AddStars(float amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void RemoveStars(float amount)
    {
        if(stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }
}
