using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class gamemanager : MonoBehaviour
{
    public GameObject startbutton;
    public GameObject creditbutton;
    public GameObject click;
    public GameObject PlayerShip;
    public GameObject enemyspawner;
    public GameObject gemober;
    public GameObject scorecount;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                gemober.SetActive(false);

                startbutton.SetActive(true);
                creditbutton.SetActive(true);

                break;

            case GameManagerState.Gameplay:
                scorecount.GetComponent<gamescore>().Score = 0;

                startbutton.SetActive(false);
                creditbutton.SetActive(false);
                click.SetActive(false);

                PlayerShip.GetComponent<shipcontrol>().Init();

                enemyspawner.GetComponent<enemyspawner>().ScheduleEnemySpawner();

                break;

            case GameManagerState.GameOver:
                enemyspawner.GetComponent<enemyspawner>().UnscheduleEnemySpawner();

                gemober.SetActive(true);

                Invoke("ChangeToOpeningState", 3f);

                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGame()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

}
