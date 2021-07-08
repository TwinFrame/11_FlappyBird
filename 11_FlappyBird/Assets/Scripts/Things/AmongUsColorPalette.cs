using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmongUsColorPalette : MonoBehaviour
{
	[SerializeField] List<Color> _colorPalette;

	public List<Color> ColorPalette => _colorPalette;
}
