using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToogleController : MonoBehaviour
{
    public Toggle fullscreen;
    public AudioSource click;

    void Start()
    {
        // Inicialitza el toggle segons l'estat actual
        fullscreen.isOn = Screen.fullScreen;

        // Assigna el listener
        fullscreen.onValueChanged.AddListener(SetFullscreen);
    }

    void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        click.playOnAwake = true;
    }
}
