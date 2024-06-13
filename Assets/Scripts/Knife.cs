using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioSource audioSource;
    [SerializeField] PauseMenu pauseMenu;

    private const int verticalSpeed = 13;
    private float startX;
    private bool isFlying;
    private bool hasPlayedSound = false;

    private void Start()
    {
        // Сохраняем место спауна ножа
        startX = transform.position.x ;
    }

    private void Update()
    {
        // Если нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0) && !pauseMenu.isPaused)
        {
            // Проверяем, что звук еще не воспроизведен
            if (!hasPlayedSound) 
            {
                // Устанавливаем тон звука
                SetPitch(1f, 2f);
                // Воспроизводим звук
                audioManager.PlaySFX(audioManager.miss);
                // Устанавливаем, что звук воспроизведен
                hasPlayedSound = true; 
            }

            // Устанавливаем, что нож летит
            isFlying = true;
        }

        // Если летим
        if (isFlying)
        {
            // Перемещаем объект в право
            transform.Translate(Time.deltaTime * verticalSpeed, 0, 0);
        }
        else
        {
            // Иначе перемещаемся вверх вниз по вертикали
            transform.position = new Vector2(startX, Mathf.Sin(Time.time * 3.3f) * 3.25f);
        }

        // Если мы вышли за границы экрана
        if (transform.position.x > 7.75f)
        {
            // Перезагружаем активную сцену по её индексу
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Устанавливаем, что звук не воспроизведен
            hasPlayedSound = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isFlying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SetPitch(0.6f, 1.2f);
            audioManager.PlaySFX(audioManager.attack);

            // Проверяем, есть ли другие противники рядом с ножом в окружности радиусом 1f
            // Метод возвращает массив всех коллайдеров, которые находятся внутри или пересекают эту окружность.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Shield"))
                {
                    GlobalEventManager.SendEnemyKilled();

                    Destroy(collider.gameObject);

                    // Получаем имя префаба, на который попали
                    string prefabName = collider.gameObject.name;

                    // В зависимости от имени префаба увеличиваем счет
                    switch (prefabName)
                    {
                        case "shield1(Clone)":
                            GlobalEventManager.CallEnemyKilled(1);
                            break;
                        case "shield2(Clone)":
                            GlobalEventManager.CallEnemyKilled(5);
                            break;
                    }
                }
            }

            isFlying = false;
        }
    }

    private void SetPitch( float minRange, float maxRange)
    {
        audioSource.pitch = UnityEngine.Random.Range(minRange, maxRange);
        
    }
}