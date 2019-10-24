using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance!=null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public GameObject GameplayUI;
    public GameObject VideoAssetUI;

    private void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Pause)
        {
            GameplayUI.SetActive(false);
            VideoAssetUI.SetActive(true);
        }
        else if (GameManager.Instance.gameState == GameManager.GameState.Play)
        {
            GameplayUI.SetActive(true);
            VideoAssetUI.SetActive(false);
        }
    }
}
