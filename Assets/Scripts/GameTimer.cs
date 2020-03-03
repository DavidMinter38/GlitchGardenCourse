using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("The amount of time a level lasts for in seconds.")]
    [SerializeField]
    float levelTime = 30;
    bool triggerFinish = false;

    void Update()
    {
        if(triggerFinish) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timeFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timeFinished)
        {
            FindObjectOfType<LevelController>().TimerFinished();
            triggerFinish = true;
        }
    }
}
