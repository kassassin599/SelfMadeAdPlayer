using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float consumptionRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Play)
        {
            InputMethod();
        }
    }

    private void InputMethod()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            FuelManager.Instance.fuel -= consumptionRate;
        }
    }
}
