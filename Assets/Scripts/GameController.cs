using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public int currentScore = 0;
    public bool isPlaying = true;
    [Header("Player")]
    public Player player;
    public PlayerAI playerAI;
    [Header("Ball")]
    public Ball ball;
    [Header("Walls")]
    public Wall leftWall;
    public Wall rightWall;
    public Wall topWall;
    public Wall bottomWall;
    [Header("Blocks")]
    public List<Block> blocks = new List<Block>();

    private Camera _currentCamera;
    private static GameController _instance = null;

    [HideInInspector]
    public int blockCountLeft = 0;

    public static GameController GetInstance(){

        if(_instance==null){
            _instance = GameObject.FindObjectOfType<GameController>();
        }
        return _instance;
    }

    private void Awake() {

        _currentCamera = Camera.main;
        blockCountLeft = blocks.Count;
        
        playerAI.Init();


    }

    private void FixedUpdate(){

        if(isPlaying){
            playerAI.UpdateStep();
            player.UpdateStep();
            ball.UpdateStep();

            scoreText.text = currentScore.ToString();
        }
        
    }

}
