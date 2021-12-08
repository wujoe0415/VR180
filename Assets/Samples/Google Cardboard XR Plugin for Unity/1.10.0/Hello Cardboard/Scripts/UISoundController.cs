//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class UISoundController : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Color NormalColor;
    public Color HightlightColor;
    public Color PressedColor;
    public PlaySound play;
   
    public void Start()
    {
        NormalColor = GetComponent<Button>().colors.normalColor;
        HightlightColor = GetComponent<Button>().colors.highlightedColor;
        PressedColor = GetComponent<Button>().colors.pressedColor;

        OnPointerExit();
    }
    
    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        var colors = this.gameObject.GetComponent<Button>().colors;
        colors.normalColor = HightlightColor;
        this.gameObject.GetComponent<Button>().colors = colors;
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        var colors = this.gameObject.GetComponent<Button>().colors;
        colors.normalColor = NormalColor;
        this.gameObject.GetComponent<Button>().colors = colors;
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        var colors = this.gameObject.GetComponent<Button>().colors;
        colors.normalColor = PressedColor;
        this.gameObject.GetComponent<Button>().colors = colors;
        play.playSound();
    }

    
}
