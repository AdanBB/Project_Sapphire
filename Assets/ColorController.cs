using UnityEngine;
using System.Collections.Generic;
using System;


[Serializable]
public class ColorStructure
{
	public string colorName;
	public Color color;
}

public class ColorController : MonoBehaviour {


	public List<ColorStructure> colorList;

}
