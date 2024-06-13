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
        // ��������� ����� ������ ����
        startX = transform.position.x ;
    }

    private void Update()
    {
        // ���� ������ ����� ������ ����
        if (Input.GetMouseButtonDown(0) && !pauseMenu.isPaused)
        {
            // ���������, ��� ���� ��� �� �������������
            if (!hasPlayedSound) 
            {
                // ������������� ��� �����
                SetPitch(1f, 2f);
                // ������������� ����
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
            transform.position = new Vector2(startX, Mathf.Sin(Time.time * 3.3f) * 3.25f);
        }

        // ���� �� ����� �� ������� ������
        if (transform.position.x > 7.75f)
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SetPitch(0.6f, 1.2f);
            audioManager.PlaySFX(audioManager.attack);

            // ���������, ���� �� ������ ���������� ����� � ����� � ���������� �������� 1f
            // ����� ���������� ������ ���� �����������, ������� ��������� ������ ��� ���������� ��� ����������.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Shield"))
                {
                    GlobalEventManager.SendEnemyKilled();

                    Destroy(collider.gameObject);

                    // �������� ��� �������, �� ������� ������
                    string prefabName = collider.gameObject.name;

                    // � ����������� �� ����� ������� ����������� ����
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