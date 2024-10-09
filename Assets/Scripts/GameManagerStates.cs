using UnityEngine;
using UnityEngine.UI;

public class GameManagerStates : MonoBehaviour
{
    [SerializeField] private Text TextHP;
    [SerializeField] private Text TextEnergy;

    void Update()
    {
        TextHP.text = gameManager.gm.playerHp.ToString();
        TextEnergy.text = gameManager.gm.playerEnergy.ToString();
    }
}
