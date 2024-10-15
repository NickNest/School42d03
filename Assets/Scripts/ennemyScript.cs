using UnityEngine;

public class ennemyScript : MonoBehaviour {

	[HideInInspector]public GameObject nextCheckpoint;
	[HideInInspector]public GameObject playerCore;
	public int waveNumber;
	public GameObject explosion;
	private Vector3 lastPos;
	public float speed;
	public bool isFlying = false;
	public int score;
	public int hp;
	public int value;					
	public int ennemyDamage;				
	public float spawnRate;		
	public int waveLenghtModifier;

	void Start() {
		lastPos = gameObject.transform.position;
		score = hp;
	}

	void Update() {
		lookForward();
		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards (transform.position, nextCheckpoint.transform.position, step);
		if (hp <= 0) {
			gameManager.gm.playerEnergy += value;
			gameManager.gm.score += score;
			destruction ();
		}
		else if (transform.position == playerCore.transform.position) {
			gameManager.gm.damagePlayer(ennemyDamage);
			destruction();
		}
		else if (transform.position == nextCheckpoint.transform.position) {
			nextCheckpoint = nextCheckpoint.GetComponent<checkpoint>().nextCheckpoint;
		}
	}

	void lookForward() {
		Vector3 moveDirection = gameObject.transform.position - lastPos; 
		if (moveDirection != Vector3.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		lastPos = gameObject.transform.position;
	}

	void destruction(){
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
		checkLastEnemy();
	}

	void checkLastEnemy() {
		if (gameManager.gm.lastWave == true) {
			GameObject[] spawners = GameObject.FindGameObjectsWithTag("spawner");
			foreach (GameObject spawner in spawners) {
				if (spawner.GetComponent<ennemySpawner>().isEmpty == false || spawner.transform.childCount > 1) {
					return ;
				}
			}
			Debug.Log ("Victoire !");
			ActionManager.OnEndGame(true);
		}
	}
}
