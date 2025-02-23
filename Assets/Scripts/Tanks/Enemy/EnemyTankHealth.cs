using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyTankHealth : MonoBehaviour
{
    //Zona de variables Gloabales
    [Header("Health")]
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _damageEnemyTank;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    private void Awake()
    {
        _bigExplosion.Stop();
        _smallExplosion.Stop();
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;
    }


    private void OnTriggerEnter(Collider infoAccess)
    {

        if (infoAccess.CompareTag("Shell"))
        {
            _smallExplosion.Play();
            _currentHealth -= _damageEnemyTank;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);

            if (_currentHealth <= 0.0f)
            {
                _bigExplosion.Play();
                Death();
            }
        }

    }

    void Start()
    {

    }


    void Update()
    {

    }

    private void Death()
    {
        _bigExplosion.Play();
        Destroy(gameObject, 1.0f);
    }
}
