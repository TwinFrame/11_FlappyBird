using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ThingGenerator : MonoBehaviour
{
	[SerializeField] private List<Thing> _templates;

	[SerializeField] private float _secondsBetweenSpawn;
	[SerializeField] private float _maxSpawnPositionY;
	[SerializeField] private TubeGenerator _tubeGenerator;
	[SerializeField] private GameObject _conatiner;

	private bool _isReady;
	private float _currentTime;
	private float _currentMaxSpawnPositionY;
	private int _sumProportion;
	private List<string> _scaleProportion;

	private void Awake()
	{
		transform.position = _tubeGenerator.gameObject.transform.position;

		_scaleProportion = CreateScaleProportion();
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

			var thing = Instantiate(ChooseTemplate(), _conatiner.transform);

			thing.transform.position = spawnPoint;

			_isReady = false;

			_currentTime = 0;
		}
	}

	private Thing ChooseTemplate()
	{
		var number = Random.Range(0, _scaleProportion.Count);

		string name = _scaleProportion[number];

		var template = _templates.FirstOrDefault(t => t.name == name);

		return template;
	}

	private int GetSumProportion()
	{
		_sumProportion = 0;

		foreach (var template in _templates)
		{
			_sumProportion += template.CreationProportion;
		}

		return _sumProportion;
	}

	private List<string> CreateScaleProportion()
	{
		List<string> scaleProportion = new List<string>();

		int currentTemplate = 0;

		int nextMarkProportion = _templates[currentTemplate].CreationProportion;

		for (int i = 0; i < GetSumProportion(); i++)
		{
			if (i > nextMarkProportion - 1)
			{
				currentTemplate++;

				nextMarkProportion += _templates[currentTemplate].CreationProportion;
			}

			scaleProportion.Add(_templates[currentTemplate].gameObject.name);
		}

		return scaleProportion;
	}
}
