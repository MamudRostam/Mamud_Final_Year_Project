using UnityEngine;

public class MatchRoomAudio : MonoBehaviour
{
    void Start()
    {
        if (Audiomanager.instance != null)
        {
            Audiomanager.instance.PlayGameMusic();
        }
    }
}
