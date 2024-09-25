using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	[SerializeField] private SpawnObject[] _spawnObjects;
	
	private void Start()
	{
		foreach (var spawnObject in _spawnObjects)
		{
			StartCoroutine(SpawnRoutine(spawnObject));
		}
	}

	private IEnumerator SpawnRoutine(SpawnObject spawnObject)
	{
		Shield shield = spawnObject.ShieldPrefab;
		float minDelay = spawnObject.SpawnDelay.MinDelay;
		float maxDelay = spawnObject.SpawnDelay.MaxDelay;
		
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
			
			Vector3 _spawnPosition = new Vector3 (transform.position.x, Random.Range(3.2f, -3.5f));
			Instantiate(shield, _spawnPosition, Quaternion.Euler(0,60, 0)); 
		}
	}
}

[Serializable]
public struct SpawnObject
{
	[SerializeField] private Shield _shieldPrefab;
	[SerializeField] private SpawnDelay _spawnDelay;

	public Shield ShieldPrefab => _shieldPrefab;
	public SpawnDelay SpawnDelay => _spawnDelay;
}

[Serializable]
public struct SpawnDelay
{
	[SerializeField] private float _minDelay;
	[SerializeField] private float _maxDelay;

	public float MinDelay => _minDelay;
	public float MaxDelay  => _maxDelay;
}
