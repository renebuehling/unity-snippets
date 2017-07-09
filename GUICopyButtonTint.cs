using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Helper to apply the color transition of a button to its graphic children.
/// Usually UI.Button copies its color states only to one target, i.e. the buttons image,
/// but often child elements like text or icons should be colorized too, which is done by this script.
/// 
/// Usage: 
/// - Create a button with child elements, i.e. text and image.
/// - Add GUICopyButtonTint to both children.
///
/// Versions: 
/// - 01 Jan 2016: Replaced GetComponent<CanvasRenderer>() with targetGraphic.canvasRenderer
///
/// License:
/// The MIT License (MIT)
/// 
/// Copyright (c) 2015 Rene Bühling, www.buehling.org
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in all
/// copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
/// SOFTWARE.
/// </summary>
public class GUICopyButtonTint : MonoBehaviour 
{
	private Graphic 	target = null;
	private Button 		button = null;

	// Use this for initialization
	void Start () 
	{
		string n=gameObject.name+"/"+GetType().Name;
		if (GetComponent<Button>()!=null)
		{
			Debug.LogWarning("Note: "+n+": Suspicious setup found, check if correct: Add GUICopyButtonTint to the child of the button (i.e. Text), not the button itself!");
		}

		target = GetComponent<Graphic>();
		button = GetComponentInParent<Button>();
		if (button==null)
		{
			Debug.LogWarning("Note: "+n+": Object has not parent button. Component will have no effect and is disabled now.");
			enabled=false;
		}
		else if (target==null)
		{
			Debug.LogWarning("Note: "+GetType().Name+": Object has not target graphic. Component will have no effect and is disabled now.");
			enabled=false;
		}
	}

	void Update () 
	{
		try{
			if ((button==null) || (target==null)) return;
			//target.color=button.GetComponent<CanvasRenderer>().GetColor();
			target.color=button.targetGraphic.canvasRenderer.GetColor(); 
		}catch{}
	}
}
