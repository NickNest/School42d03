using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacingScript : MonoBehaviour
{

    void Start()
    {
        ActionManager.PlacingTower += OnPlacingTower;
    }

    public void OnPlacingTower(GameObject currentTurret, Vector3 mouseWorldPosition)
    {
        Vector2 point = mouseWorldPosition;
        Collider2D collider = Physics2D.OverlapPoint(point);
            Debug.Log(collider.name);
        if (collider != null && collider.CompareTag("empty"))
        {
            var turret = Instantiate(currentTurret, collider.gameObject.transform.position, Quaternion.identity);
            turret.GetComponent<towerScript>().isPlacing = true;
            Collider2D[] colliders = turret.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D collider2d in colliders)
            {
                collider2d.enabled = true;
            }
        }
    }
}
