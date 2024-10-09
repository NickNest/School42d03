using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class ActionManager
{
    public static event Action <GameObject> ChoosingTower;
    public static event Action UnChoosingTower;
    public static event Action <GameObject, Vector3> PlacingTower;

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
