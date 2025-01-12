﻿using UnityEngine;

public class gameManager : MonoBehaviour {

	[HideInInspector]public int playerHp = 20;
	public int playerMaxHp = 20;
	[HideInInspector]public int playerEnergy = 300;
	public int playerStartEnergy = 300;
	public float energyMultiplier = 2.0f; 
    public float healthMultiplier = 3.0f;
	public int delayBetweenWaves = 10;					
	public int nextWaveEnnemyHpUp = 20; 				
	public int nextWaveEnnemyValueUp = 30; 		
	public int averageWavesLenght = 15;					
	public int totalWavesNumber = 20;						
	[HideInInspector]public bool lastWave = false;
	[HideInInspector]public int currentWave = 1;
	private float tmpTimeScale = 1;
	[HideInInspector]public int score = 0;

	public static gameManager gm;
	void Awake () {
		if (gm == null)
			gm = this;
	}

	void Start() {
		Time.timeScale = 1;
		playerHp = playerMaxHp;
		playerEnergy = playerStartEnergy;
	}

	public void pause(bool paused) {
		if (paused == true) {
			tmpTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		else
			Time.timeScale = tmpTimeScale;
	}

	public void changeSpeed(float speed) {
		Time.timeScale = speed;
	}

	public void damagePlayer(int damage) {
		playerHp -= damage;
		if (playerHp <= 0)
			gameOver();
		else
			Debug.Log ("Il reste au joueur " + playerHp + "hp");
	}

	public void gameOver() {
		Time.timeScale = 0;
		Debug.Log ("Game Over");
		ActionManager.OnEndGame(false);
	}

	public int GetFinalScore() 
	=> (int)(playerEnergy * energyMultiplier + playerHp * healthMultiplier);

	public string GetFinalRank(){
		int finalScore = GetFinalScore();
		string rank;
        if (finalScore >= 90) {
            rank = "S";
        } else if (finalScore >= 80) {
            rank = "A";
        } else if (finalScore >= 70) {
            rank = "B";
        } else if (finalScore >= 60) {
            rank = "C";
        } else if (finalScore >= 50) {
            rank = "D";
        } else {
            rank = "F";
        }
		return rank;
	}
}
