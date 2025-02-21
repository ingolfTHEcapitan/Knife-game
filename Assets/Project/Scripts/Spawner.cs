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
		Shield shield = spawnObject.Prefab;
		float minDelay = spawnObject.Delay.Min;
		float maxDelay = spawnObject.Delay.Max;
		
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
			
			Vector2 _spawnPosition = new Vector2(transform.position.x, Random.Range(3.2f, -3.5f));
			Instantiate(shield, _spawnPosition, Quaternion.Euler(0,60, 0)); 
		}
	}
}

[Serializable]
public struct SpawnObject
{
	[field: SerializeField] public Shield Prefab;
	[field: SerializeField]  public SpawnDelay Delay;
}

[Serializable]
public struct SpawnDelay
{
	[field: SerializeField] public float Min;
	[field: SerializeField] public float Max;
}
