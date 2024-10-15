using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControll : MonoBehaviour
{
    [SerializeField] private GameObject _cannonTurret;
    [SerializeField] private GameObject _gatlingTurret;
    [SerializeField] private GameObject _rocketTurret;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActionManager.OnUnChoosingTower();
            ActionManager.OnChoosingTower(_cannonTurret);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ActionManager.OnUnChoosingTower();
            ActionManager.OnChoosingTower(_gatlingTurret);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActionManager.OnUnChoosingTower();
            ActionManager.OnChoosingTower(_rocketTurret);
        }
    }
}
