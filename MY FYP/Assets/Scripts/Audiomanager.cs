using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music Clips")]
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    [Header("UI")]
    public AudioClip buttonClick;

    [Header("Player")]
    public AudioClip playerShoot;
    public AudioClip playerHit;

    [Header("Enemy")]
    public AudioClip enemyShoot;
    public AudioClip enemyHit;

    [Header("Game States")]
    public AudioClip gameOver;
    public AudioClip gameComplete;


    [Header("Volume Controls")]
    [Range(0, 1)] public float masterVolume = 1f;
    [Range(0, 1)] public float musicVolume = 1f;
    [Range(0, 1)] public float sfxVolume = 1f;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

     void Update()
    {
        musicSource.volume = masterVolume * musicVolume;
        sfxSource.volume = masterVolume * sfxVolume;
    }

    // Music

    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }

    public void PlayGameMusic()
    {
        PlayMusic(gameMusic);
    }

    void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // SFX

    public void PlayButton()
    {
        sfxSource.PlayOneShot(buttonClick);
    }

    public void PlayGameOver()
    {
        sfxSource.PlayOneShot(gameOver);
    }

    public void PlayGameComplete()
    {
        sfxSource.PlayOneShot(gameComplete);
    }

    public void PlayPlayerHit()
    {
        sfxSource.PlayOneShot(playerHit);
    }

    public void PlayEnemyHit()
    {
        sfxSource.PlayOneShot(enemyHit);
    }

    public void PlayPlayerShoot()
    {
        sfxSource.PlayOneShot(playerShoot);
    }

    public void PlayEnemyShoot()
    {
        sfxSource.PlayOneShot(enemyShoot);
    }



}
