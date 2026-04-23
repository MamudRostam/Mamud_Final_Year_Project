using UnityEngine;

public class MatchRoomAudio : MonoBehaviour
{
    void Start()
    {
        Audiomanager.instance.PlayGameMusic();
    }
}
