using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts
{
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
			while (true)
			{
				yield return new WaitForSeconds(Random.Range(spawnObject.MinDelay, spawnObject.MaxDelay));
			
				Vector2 _spawnPosition = new Vector2(transform.position.x, Random.Range(3.2f,-3.5f));
				Instantiate(spawnObject.Prefab, _spawnPosition, Quaternion.Euler(0, 60, 0)); 
			}
		}
	}
}