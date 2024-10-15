using UnityEngine;

public class ennemySpawner : MonoBehaviour {

	private int waveNumber = 0;
	private float spawnRate;
	private float nextSpawn = 0;
	private float nextWave;
	private int waveLenght;
	private int spawned = 0;
	private GameObject toSpawn;
	public GameObject[] bots;
	public GameObject nextCheckpoint;
	[HideInInspector]public GameObject playerCore;
	[HideInInspector]public bool isEmpty = false;

	void trySpawn() {
		if (Time.time > nextSpawn && spawned <  waveLenght) {
			GameObject newBot = (GameObject)Instantiate(toSpawn, transform.position, Quaternion.identity);
			newBot.transform.parent = this.gameObject.transform;
			ennemyScript botScript = newBot.GetComponent<ennemyScript>();
			if (botScript.isFlying == true)
				botScript.nextCheckpoint = playerCore;
			else
				botScript.nextCheckpoint = nextCheckpoint;
			botScript.playerCore = playerCore;
			botScript.waveNumber = waveNumber;
			botScript.hp = Mathf.RoundToInt(((float)gameManager.gm.nextWaveEnnemyHpUp * (waveNumber - 1) + 100) / 100 * (float)botScript.hp);
			botScript.value = Mathf.RoundToInt(((float)gameManager.gm.nextWaveEnnemyValueUp * (waveNumber - 1) + 100) / 100 * (float)botScript.value);
			nextSpawn = Time.time + spawnRate;
			spawned += 1;
		}
		if (spawned ==  waveLenght) {
			if (waveNumber == gameManager.gm.totalWavesNumber) {
				gameManager.gm.lastWave = true;
				isEmpty = true;
			}
			else {
				nextWave = Time.time + gameManager.gm.delayBetweenWaves;
				pickType();
			}
		}
	}

	void pickType() {
		waveNumber += 1;
		Debug.Log("Vague numero : " + waveNumber);
		spawned = 0;
		int r = Random.Range(0, bots.Length);
		toSpawn = bots[r];
		ennemyScript botScript = bots[r].GetComponent<ennemyScript>();
		waveLenght = Mathf.RoundToInt(((float)botScript.waveLenghtModifier + 100) / 100 * (float)gameManager.gm.averageWavesLenght);
		spawnRate = botScript.spawnRate;
	}

	void Update() {
		if (Time.time > nextWave && waveNumber <= gameManager.gm.totalWavesNumber)
			trySpawn ();
	}

	void Start() {
		playerCore = GameObject.FindGameObjectWithTag("playerCore");
		pickType();
	}

}
