using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http.Headers;

public class GameManager : MonoBehaviour
{
    //Zona de variables Globales
    [Header("Images")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;
    [Header("Fade")]
    [SerializeField]
    private float _fadeDuration;
    [SerializeField]
    private float _displayImageDuration;
    private float _timer;

    public bool IsPlayerCaught;
    public bool IsPlayerAtExit;
    public bool IsRestartLevel;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;
    private AudioSource _audioSource;

    [SerializeField]
    private GameObject _panel;
    



    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (IsPlayerAtExit)
        {
            Won();
        }
        else if (IsPlayerCaught)
        {
            Caught();
        }

    }

    private void Won()
    {
        _audioSource.clip = _wonClip;
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        _timer = _timer + Time.deltaTime;
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer / _fadeDuration);

        if (_timer > _fadeDuration + _displayImageDuration)
        {
            Debug.Log("Has ganado");
        }
    }

    private void Caught()
    {
        _audioSource.clip = _caughtClip;
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        _timer = _timer + Time.deltaTime;
        _caughtImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer / _fadeDuration);

        if (_timer > _fadeDuration + _displayImageDuration)
        {
            Debug.Log("Has perdido");
            SceneManager.LoadScene("JhonLemon");
        }

    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.gameObject.tag == "JohnLemon")
        {
            Won();
            IsPlayerAtExit = true;
            _panel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void LoadSceneLevel()
    {

        SceneManager.LoadScene("JhonLemon");

    }



}
