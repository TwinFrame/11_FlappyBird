using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
	[SerializeField] protected int _creationProportion;

	public int CreationProportion => _creationProportion;
}
