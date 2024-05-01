using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    [Tooltip("Взрыв (Префаб).")]
    [SerializeField] private GameObject _explosion;

    [Tooltip("Для проверки видимости мины.")]
    [SerializeField] private GameObject _mine;

    [Tooltip("Для системы частиц со взрывом.")]
    [SerializeField] private ParticleSystem _explosionPS;

    [SerializeField] private AudioSource _explosionClip;

    private bool isExplosion = false;
    private bool isPermission = true;

    // Update is called once per frame
    void Update()
    {
        // Префаб взрыва следует за миной
        _explosion.transform.position = _mine.transform.position;

        // Система частиц следует за миной
        _explosionPS.transform.position = _mine.transform.position;

        if (_mine.activeSelf == false)
            isExplosion = true;
        
        // Если мина исчезла, то выполняем все нужные действия (две переменные нужны чтобы всё выполнилось по одному разу)
        // Т.к. мина, после исчезновения не видна, то взрыв и звук выполнялись бы постоянно
        if (isExplosion && isPermission)
        {
            // Взрыв частиц
            _explosionPS.Play();

            // Звук взрыва
            _explosionClip.Play();

            // Префаб взрыва (эффектор)
            Instantiate(_explosion);

            // Отзываем разрешение и больше этот код выполняться не будет
            isPermission = false;
        }        
    }
}
