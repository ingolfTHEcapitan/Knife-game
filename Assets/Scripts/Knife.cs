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

        // Находим GameObject на сцене
        SoundFX = GameObject.Find("SFX");
        // Получаем доступ к его компоненту
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
            // Если мы не летим не в цель, перезагружаем сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Если попали в цель
        else
        {
           
            SetPitch(0.6f, 1.2f);
            // Воспроизводим звук попадания
            audioManager.PlaySFX(audioManager.attack);
            // Удаляем объект по которому попали
            Destroy(collision.gameObject);
            isFlying = false;
            hasPlayedSound = false;
            // Вызываем метод IncreaseScore() скрипта ScoreManager для увеличения счёта
            scoreManager.IncreaseScore();

        }
    }

    private void SetPitch( float minRange, float maxRange)
    {
        audioSource.pitch = Random.Range(minRange, maxRange);
    }
}