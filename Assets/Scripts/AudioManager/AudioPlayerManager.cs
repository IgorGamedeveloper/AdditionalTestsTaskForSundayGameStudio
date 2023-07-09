using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayerManager : MonoBehaviour
{
    public static AudioPlayerManager Instance { get; private set; }

    private AudioSource _audio;

    [SerializeField] private AudioClip[] _clips;
    private int _clipIndex;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartPlay();
    }

    private void Update()
    {
        if (_audio.isPlaying == false)
        {
            PlayNextClip();
        }
    }

    public void StartPlay()
    {
        if (_clips != null && _clips.Length > 0)
        {
            _clipIndex = 0;
            _audio.clip = _clips[_clipIndex];
            _audio.Play();
        }
        else
        {
            Debug.Log("Добавьте музыкальные дорожки!");
        }
    }

    public void PlayNextClip()
    {

        if (_clips != null && _clips.Length > 0)
        {
            _clipIndex++;

            if (_clipIndex < _clips.Length)
            {
                _audio.clip = _clips[_clipIndex];
                _audio.Play();
            }
            else
            {
                StartPlay();
            }
        }
        else
        {
            Debug.Log("Добавьте музыкальные дорожки!");
        }
    }


}
