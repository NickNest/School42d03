using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class mouseControll : MonoBehaviour
{

    private GameObject _currentChoosingTurret;

    private GameObject _currentTurret;
    private towerScript _towerScript;
    private SpriteRenderer _towerRenderer;

    private Vector3 mouseWorldPosition;
    void Start()
    {

    }
    private void OnEnable() {
        ActionManager.ChoosingTower += OnChoosingTower; 
    }
    private void OnDisable() {
        ActionManager.ChoosingTower -= OnChoosingTower; 
    }

    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        if (_currentTurret != null)
        {
            _currentTurret.transform.position = mouseWorldPosition;
            if (_towerScript.energy <= gameManager.gm.playerEnergy)
            {
                _towerRenderer.color = Color.green;
            }
            else _towerRenderer.color = Color.red;
        }

        if (Input.GetMouseButtonDown(0) && _currentTurret != null)
        {
            if (gameManager.gm.playerEnergy >= _currentTurret.GetComponent<towerScript>().energy)
            {
                _towerRenderer.color = Color.white;
                ActionManager.OnPlacingTower(_currentTurret, mouseWorldPosition);
            }
        }

        if (Input.GetMouseButtonDown(1) && _currentTurret != null)
        {
            Destroy(_currentTurret);
            ActionManager.OnUnChoosingTower();

        }
    }

    public void OnChoosingTower(GameObject choosingTurret)
    {
        ActionManager.OnUnChoosingTower();
        _currentChoosingTurret = choosingTurret;
        _currentTurret = Instantiate(_currentChoosingTurret, transform.parent);
        _towerScript = _currentTurret.GetComponent <towerScript>();
        _towerRenderer = _currentTurret.GetComponent<SpriteRenderer>();
        Collider2D[] colliders = _currentTurret.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider2d in colliders)
        {
            collider2d.enabled = false;
        }
        _currentTurret.gameObject.GetComponent<towerScript>().isPlacing = false;
    }


}
