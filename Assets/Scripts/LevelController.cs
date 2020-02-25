using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject winBanner;

    [SerializeField]
    GameObject loseBanner;

    [SerializeField]
    float timeToWait = 4f;

    int remainingAttackers = 0;
    bool timerExpired = false;

    void Start()
    {
        winBanner.SetActive(false);
        loseBanner.SetActive(false);
    }

    public void SpawnAttacker()
    {
        remainingAttackers++;
    }

    public void KillAttacker()
    {
        remainingAttackers--;
        if(remainingAttackers <= 0 && timerExpired)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winBanner.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeToWait);
        FindObjectOfType<LevelLoad>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseBanner.SetActive(true);
        Time.timeScale = 0;
    }

    public void TimerFinished()
    {
        timerExpired = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
