using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    private float levelTime = 10f;
    private int totalPoints;
    private bool roundOver;

    [SerializeField]
    private Transform gameMenu;

    [SerializeField]
    private BaddieSpawner spawner;

    [SerializeField]
    private TextMeshProUGUI gameMenuText;

    [SerializeField]
    private Bases bases;

    [SerializeField]
    private TextMeshProUGUI timer;

    
    // Update is called once per frame
    void Update()
    {
        this.levelTime -= Time.deltaTime;
        if (this.levelTime <= 0 && !roundOver)
        {
            // end round
            CompleteRound();
        }

        timer.text = levelTime.ToString("00");
    }

    private void CompleteRound()
    {
        roundOver = true;
        this.totalPoints += bases.BaseCount * Random.Range(1, 100);
        spawner.Stop();
        gameMenu.gameObject.SetActive(true);
        gameMenuText.text = string.Format("{0} bases remaining\n{1} total points", bases.BaseCount, this.totalPoints);
        Time.timeScale = 0;
    }

    public void StartNextRound()
    {
        roundOver = false;
        Time.timeScale = 1;
        levelTime = 10f;
        StartCoroutine(spawner.StartSpawning());
        gameMenu.gameObject.SetActive(false);
    }
}
