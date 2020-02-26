using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        if(defender != null)
        {
            AttemptToPlaceDefender();
        } 
    }

    public void SelectDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefender()
    {
        var starsDisplay = FindObjectOfType<StarsDisplay>();
        float defenderCost = defender.GetStarCost() * (0.8f + (PlayerPrefsController.GetDifficulty() * 0.2f));
        if(starsDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender();
            starsDisplay.RemoveStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender()
    {
        Vector2 placeToSpawn = GetSquareClicked();
        Defender newDefender = Instantiate(defender, placeToSpawn, transform.rotation) as Defender;
    }
}
