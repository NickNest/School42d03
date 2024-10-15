using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseObj;
    private bool _paused;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void OnMainMenuClick()
    {
        gameManager.gm.changeSpeed(1);
        SceneManager.LoadScene("Title");
    }

    public void Resume()
    {
        _paused = false;
        gameManager.gm.pause(_paused);
        _pauseObj.SetActive(false);
    }

    public void Pause()
    {
        _paused = true;
        gameManager.gm.pause(_paused);
        _pauseObj.SetActive(true);
    }
}
