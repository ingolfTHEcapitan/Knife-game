using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    private const int verticalSpeed = 13;
    private float startX;
    private bool isFlying;
    private bool hasPlayedSound = false;

    // Передаём ссылки на классы
    private ScoreManager scoreManager;
    private AudioManager audioManager;
    private AudioSource audioSource;
    public GameObject SoundFX;

    private void Start()
    {
        // Сохраняем место спауна ножа
        startX = transform.position.x ;

        // Находим экземпляры скриптов в сцене
        scoreManager = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();

        // Получаем доступ к компоненту
        audioSource = SoundFX.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Если нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
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
            transform.position = new Vector3(startX, Mathf.Sin(Time.time * 3) * 4f);
        }

        // Если мы вышли за границы экрана
        if (transform.position.x > 9)
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
            Destroy(collision.gameObject);
            isFlying = false;
            hasPlayedSound = false;

            // Получаем имя префаба, на который попали
            string prefabName = collision.gameObject.name;

            // В зависимости от имени префаба увеличиваем счет
            switch (prefabName)
            {
                case "shield1(Clone)":
                    scoreManager.IncreaseScore(1);
                    break;
                case "shield2(Clone)":
                    scoreManager.IncreaseScore(5);
                    break;
            }
        }
    }

    private void SetPitch( float minRange, float maxRange)
    {
        audioSource.pitch = Random.Range(minRange, maxRange);
    }
}