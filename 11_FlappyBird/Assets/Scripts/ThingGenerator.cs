using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingGenerator : MonoBehaviour
{
	[SerializeField] private float _secondsBetweenSpawn;
	[SerializeField] private float _maxSpawnPositionY;
	[SerializeField] private GameObject _template;
	[SerializeField] private TubeGenerator _tubeGenerator;
	[SerializeField] private GameObject _conatiner;

	private bool _isReady;
	private float _currentTime;
	private float _currentMaxSpawnPositionY;

	private void Awake()
	{
		transform.position = _tubeGenerator.gameObject.transform.position;
	}

	private void OnEnable()
	{
		_tubeGenerator.MomentOfGeneration += TrySpawnThing;
	}

	private void OnDestroy()
	{
		_tubeGenerator.MomentOfGeneration -= TrySpawnThing;
	}

	private void Update()
	{
		_currentTime += Time.deltaTime;

		if (_currentTime >= _secondsBetweenSpawn && !_isReady)
			_isReady = true;
	}

	private void TrySpawnThing(float offsetPositionY)
	{
		if (_isReady)
		{
			var upOrDownPosition = Random.Range(0, 2);

			if (upOrDownPosition == 1)
				_currentMaxSpawnPositionY = -_maxSpawnPositionY;
			else
				_currentMaxSpawnPositionY = _maxSpawnPositionY;

			var currentPositionY = offsetPositionY + _currentMaxSpawnPositionY;

			Vector3 spawnPoint = new Vector3(transform.position.x, currentPositionY, transform.position.z);

			var thing = Instantiate(_template, _conatiner.transform);

			thing.transform.position = spawnPoint;

			_isReady = false;
			_currentTime = 0;
		}
	}
}
