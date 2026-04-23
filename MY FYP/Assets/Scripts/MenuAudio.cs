using UnityEngine;

public class MenuAudio : MonoBehaviour
{
     void Start()
    {
        Audiomanager.instance.PlayMenuMusic();
    }
}
