using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllBar : MonoBehaviour
{
    private bool _paused;
    public void OnPauseClick()
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
    public void OnSpeedOneClick()
    {
        gameManager.gm.changeSpeed(1);
    }
    public void OnSpeedTwoClick()
    {
        gameManager.gm.changeSpeed(2);
    }
    public void OnSpeedThreeClick()
    {
        gameManager.gm.changeSpeed(3);
    }
    public void Resume()
    {
        _paused = false;
        gameManager.gm.pause(_paused);
    }

    public void Pause()
    {
        _paused = true;
        gameManager.gm.pause(_paused);
    }
}
