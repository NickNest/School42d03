using System;
using UnityEngine;

public class ActionManager
{
    public static event Action<GameObject> ChoosingTower;
    public static event Action UnChoosingTower;
    public static event Action<GameObject, Vector3> PlacingTower;
    public static event Action<bool> EndGame;
    public static event Action<GameObject> SelectingPlacedTower;
    public static event Action UnSelectingPlacedTower;

    public static void OnUnselectingPlacedTower()
    {
        UnSelectingPlacedTower?.Invoke();
    }

    public static void OnSelectingPlacedTower(GameObject tower)
    {
        SelectingPlacedTower?.Invoke(tower);
    }

    public static void OnEndGame(bool isWinning)
    {
        EndGame?.Invoke(isWinning);
    }

    public static void OnChoosingTower(GameObject choosingTower)
    {
        ChoosingTower?.Invoke(choosingTower);
    }

    public static void OnUnChoosingTower()
    {
        UnChoosingTower?.Invoke();
    }

    public static void OnPlacingTower(GameObject placingTower, Vector3 mouseWorldPosition)
    {
        PlacingTower?.Invoke(placingTower, mouseWorldPosition);
    }
}
