using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private GameObject _endTitleObj;
    [SerializeField] private Text _endTitleText;

    private void OnEnable() {
        ActionManager.EndGame += OnEndGame;
        _endTitleObj.SetActive(false);
    }
    private void OnDisable() {
        ActionManager.EndGame -= OnEndGame;
        _endTitleObj.SetActive(false);
    }

    public void OnEndGame(bool isWinning) {
        if(isWinning){
            int finalScore = gameManager.gm.GetFinalScore();
            string rank = gameManager.gm.GetFinalRank();
            _endTitleText.text = $"YOU WIN!\nYour score {finalScore}\nRank {rank}";
        }
        _endTitleObj.SetActive(true);
    }

    public void RestartScene(){
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name);
    }
}
