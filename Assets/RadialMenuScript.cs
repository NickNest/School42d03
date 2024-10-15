using UnityEngine;
using UnityEngine.UI;

public class RadialMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _radialMenuInstance;
    [SerializeField] private Text _upgradeValue;
    [SerializeField] private Text _downgradeValue;

    private Transform _currentTowerTransform;
    private towerScript _currentTowerStats;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        _radialMenuInstance.SetActive(false);
    }

    private void OnEnable()
    {
        ActionManager.SelectingPlacedTower += OnSelectingPlacedTower;
        ActionManager.UnSelectingPlacedTower += OnUnSelectingPlacedTower;
    }

    private void OnDisable()
    {
        ActionManager.SelectingPlacedTower -= OnSelectingPlacedTower;
        ActionManager.UnSelectingPlacedTower -= OnUnSelectingPlacedTower;
    }


    public void OnSelectingPlacedTower(GameObject tower)
    {
        _currentTowerTransform = tower.GetComponentInParent<Transform>();
        _currentTowerStats = tower.GetComponentInParent<towerScript>();

        Vector3 screenPosition = mainCamera.WorldToScreenPoint(_currentTowerTransform.position);
        _radialMenuInstance.GetComponent<RectTransform>().position = screenPosition;

        if (_currentTowerStats.upgrade != null)
        {
            var upgradeValue = _currentTowerStats.upgrade.GetComponent<towerScript>().energy;
            _upgradeValue.text = upgradeValue.ToString();
        }
        else
        {
            _upgradeValue.text = "NuN";
        }
        if (_currentTowerStats.downgrade != null)
        {
            var downgradeValue = _currentTowerStats.downgrade.GetComponent<towerScript>().energy / 2;
            _downgradeValue.text = downgradeValue.ToString();
        }
        else
        {
            var downgradeValue = _currentTowerStats.energy / 2;
            _downgradeValue.text = downgradeValue.ToString();
        }
        _radialMenuInstance.SetActive(true);
    }
    private void OnUnSelectingPlacedTower()
    {
        _radialMenuInstance.SetActive(false);
    }

    public void OnClickUpgrade()
    {
        if (_currentTowerStats == null)
            return;
        if (_currentTowerStats.upgrade == null)
            return;

        var upgradeStats = _currentTowerStats.upgrade.gameObject.GetComponent<towerScript>();

        if (upgradeStats != null && upgradeStats.energy <= gameManager.gm.playerEnergy)
        {
            gameManager.gm.playerEnergy -= upgradeStats.energy;

            var Instanse = Instantiate(_currentTowerStats.upgrade.gameObject,
                _currentTowerTransform.position, Quaternion.identity);
            Instanse.GetComponent<towerScript>().isPlacing = true;
            Destroy(_currentTowerStats.gameObject);
            _currentTowerTransform = null;
            _currentTowerStats = null;
            _radialMenuInstance.SetActive(false);
        }
    }

    public void OnClickDownGrade()
    {
        if (_currentTowerStats == null)
            return;
        if( _currentTowerStats.downgrade == null)
        {
            gameManager.gm.playerEnergy += _currentTowerStats.energy / 2;
            Destroy(_currentTowerStats.gameObject);
            _currentTowerTransform = null;
            _currentTowerStats = null;
            _radialMenuInstance.SetActive(false);
            return;
        }

        var downgradeStats = _currentTowerStats.downgrade.gameObject.GetComponent<towerScript>();

        gameManager.gm.playerEnergy += downgradeStats.energy / 2;
        var Instanse = Instantiate(_currentTowerStats.downgrade.gameObject,
                _currentTowerTransform.position, Quaternion.identity);
            Instanse.GetComponent<towerScript>().isPlacing = true;
            Destroy(_currentTowerStats.gameObject);
            _currentTowerTransform = null;
            _currentTowerStats = null;
            _radialMenuInstance.SetActive(false);
    }
}
