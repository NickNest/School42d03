using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTitleButtons : MonoBehaviour
{
    [SerializeField] private Text _congratText;

    public void OnMainTitleButtonClick()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
