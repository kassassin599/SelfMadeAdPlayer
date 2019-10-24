using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    public static FuelManager Instance;

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

    public float fuel = 100f;

    private void Update()
    {
        if (fuel<=0)
        {
            GameManager.Instance.gameState = GameManager.GameState.Pause;
        }
    }
}
