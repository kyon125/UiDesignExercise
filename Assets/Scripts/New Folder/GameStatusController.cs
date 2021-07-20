using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusController : MonoBehaviour
{
    public static GameStatusController gameStatusController;
    // Start is called before the first frame update
    public GameStatus gameStatus;
    private void Awake()
    {
        gameStatusController = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
public enum GameStatus
{
    isGameing,
    isSpeaking
}
