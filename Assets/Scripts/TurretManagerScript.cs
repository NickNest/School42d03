using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _turret;

    [SerializeField] private Text _textWait;
    [SerializeField] private Text _textDamage;
    [SerializeField] private Text _textRange;
    [SerializeField] private Text _textEnergy;

    private float _wait;
    private int _damage;
    private float _range;
    private int _energy;

    void Start()
    {
        var _turretStats = _turret.GetComponent<towerScript>();
        _wait = _turretStats.fireRate;
        _damage = _turretStats.damage;
        _range = _turretStats.range;
        _energy = _turretStats.energy;

        _textWait.text = _wait.ToString();
        _textDamage.text = _damage.ToString();
        _textRange.text = _range.ToString();
        _textEnergy.text = _energy.ToString();

        ActionManager.UnChoosingTower += OnUnChoosingTower;
    }
    void Update()
    {

    }

    public void OnTurretClick()
    {
        ActionManager.OnChoosingTower(_turret);
    }

    public void OnUnChoosingTower()
    {
        
    }
}
