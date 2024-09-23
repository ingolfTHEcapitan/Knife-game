using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Shield _shieldOnePrefab;
	[SerializeField] private Shield _shieldTwoPrefab;
	
	private Vector3 _spawnPosition;

	private void Start()
	{
		_spawnPosition = new Vector3 (transform.position.x, Random.Range(3.2f, -3.5f));
		
		// Задаем случаную позицию появления объекта
		transform.position = _spawnPosition;
		
		// Запускаем корутины для спавна щитов
		StartCoroutine(SpawnRoutine(_shieldOnePrefab,2f, 1.5f));
		StartCoroutine(SpawnRoutine(_shieldTwoPrefab, 6f, 4f));
	}

	private IEnumerator SpawnRoutine(Shield target, float minSpawnDelay, float maxSpawnDelay)
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
			Instantiate(target, _spawnPosition, Quaternion.Euler(0, 60, 0)); 
		}
	}
}
