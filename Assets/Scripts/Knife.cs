using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    private const int verticalSpeed = 13;
    private float startX;
    private bool isFlying;
    private bool hasPlayedSound = false;

    // ������� ������ �� ����� ���������� �� ���������� ������
    private ScoreManager scoreManager;
    // ������� ������ �� ����� ���������� �� ���������� ������
    AudioManager audioManager;

    

    private void Awake()
    {
        // ������� �� ���� ��������� ������� AudioManager � �����
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        // ��������� ����� ������ ����
        startX = transform.position.x ;
        // ������� ��������� ������� ScoreManager � �����
        scoreManager = FindObjectOfType<ScoreManager>(); 
    }

    private void Update()
    {
        // ���� ������ ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���������, ��� ���� ��� �� �������������
            if (!hasPlayedSound) 
            {
                // ������������� ���� ������� ����� PlaySFX �� ������� AudioManager
                audioManager.PlaySFX(audioManager.miss);
                // �������������, ��� ���� �������������
                hasPlayedSound = true; 
            }

            // �������������, ��� ��� �����
            isFlying = true;
        }

        // ���� �����
        if (isFlying)
        {
            // ���������� ������ � �����
            transform.Translate(Time.deltaTime * verticalSpeed, 0, 0);
        }
        else
        {
            // ����� ������������ ����� ���� �� ���������
            transform.position = new Vector3(startX, Mathf.Sin(Time.time * 3) * 4f);
        }

        // ���� �� ����� �� ������� ������
        if (transform.position.x > 9)
        {
            // ������������� �������� ����� �� � �������
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // �������������, ��� ���� �� �������������
            hasPlayedSound = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isFlying)
        {
            // ���� �� �� ����� �� � ����, ������������� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // ���� ������ � ����
        else
        {
            // ������������� ���� ���������
            audioManager.PlaySFX(audioManager.attack);
            // ������� ������ �� �������� ������
            Destroy(collision.gameObject);
            isFlying = false;
            hasPlayedSound = false;
            // �������� ����� IncreaseScore() ������� ScoreManager ��� ���������� �����
            scoreManager.IncreaseScore(); 
          
        }
    }
}