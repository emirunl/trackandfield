using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public GameObject ScoreCheck;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public GameObject player;
    public GameObject player2;
    int p1Score, p2Score;
    public TextMeshProUGUI p1ScoreText, p2ScoreText;
    public bool isP1won = true;
    public static string winnerName;
    Vector3 PlayerOnePos, PlayerTwoPos;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameStart();

    }


    // Update is called once per frame
    void Update()
    {
        PlayerOnePos = player.transform.position;
        PlayerTwoPos = player2.transform.position;
        p1Score = player.GetComponent<PlayerController>().score;
        p2Score = player2.GetComponent<PlayerTwoController>().score;

        if (isGameFnished())
        {
            SceneManager.LoadScene("GameFnished");
        }
        p1ScoreText.text = "P1: " + p1Score.ToString();
        p2ScoreText.text = "P2: " + p2Score.ToString();


    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {

            float waitTime = Random.Range(1f, 2f);

            yield return new WaitForSeconds(waitTime);

            transform.rotation = obstacle.transform.rotation;


            Instantiate(obstacle, spawnPoint.position, transform.rotation);
            Instantiate(obstacle, spawnPoint2.position, transform.rotation);
            Instantiate(ScoreCheck, spawnPoint.position, transform.rotation);

        }

    }

    public void GameStart()
    {
        StartCoroutine("SpawnObstacle");

    }

    bool isGameFnished()
    {

        if (PlayerOnePos.z < -1.9 || p2Score == 100)
        {
            isP1won = false;
            winnerName = "Player Two";
            return true;
        }
        if (PlayerTwoPos.z < -1.9 || p1Score == 100)
        {
            isP1won = true;
            winnerName = "Player One";
            return true;
        }

        // is goal score reached? 100
        // is one of the players were came with same position with camera?

        return false;

    }





}
