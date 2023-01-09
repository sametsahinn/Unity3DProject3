using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;

    PlayerInputManager playerInputManager;
    int playerIndex;

    void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.playerPrefab = prefabs[playerIndex];
    }

    void OnEnable()
    {
        StartCoroutine(LoadPlayersAsync());
    }

    IEnumerator LoadPlayersAsync()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        for (int i = 0; i < GameManager.Instance.PlayerCount; i++)
        {
            playerInputManager.JoinPlayer(playerIndex);
            yield return waitForSeconds;
        }
    }

    public void HandleOnJoin()
    {
        playerIndex++;

        if (playerIndex >= prefabs.Length) playerIndex = prefabs.Length - 1;

        playerInputManager.playerPrefab = prefabs[playerIndex];

        playerInputManager.splitScreen = true;
    }

    public void HandleOnLeft()
    {
        playerIndex--;

        if (playerIndex < 0) playerIndex = 0;

        playerInputManager.playerPrefab = prefabs[playerIndex];

        playerInputManager.splitScreen = false;
    }
}
