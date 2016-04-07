﻿using UnityEngine;
using UnityEditor;
using System.Collections;

namespace AlpacaSound
{
	[CustomEditor (typeof (RetroPixel))]
	public class RetroPixelEditor : Editor
	{
		SerializedObject serObj;

		SerializedProperty horizontalResolution;
		SerializedProperty verticalResolution;
		SerializedProperty numColors;

		SerializedProperty color0;
		SerializedProperty color1;
		SerializedProperty color2;
		SerializedProperty color3;
		SerializedProperty color4;
		SerializedProperty color5;
		SerializedProperty color6;
		SerializedProperty color7;
        SerializedProperty color8;
        SerializedProperty color9;
        SerializedProperty color10;
        SerializedProperty color11;
        SerializedProperty color12;
        SerializedProperty color13;
        SerializedProperty color14;
        SerializedProperty color15;
        SerializedProperty color16;
        SerializedProperty color17;
        SerializedProperty color18;
        SerializedProperty color19;
        SerializedProperty color20;
        SerializedProperty color21;
        SerializedProperty color22;
        SerializedProperty color23;

        void OnEnable ()
		{
			serObj = new SerializedObject (target);
			
			horizontalResolution = serObj.FindProperty ("horizontalResolution");
			verticalResolution = serObj.FindProperty ("verticalResolution");
			numColors = serObj.FindProperty ("numColors");
			color0 = serObj.FindProperty ("color0");
			color1 = serObj.FindProperty ("color1");
			color2 = serObj.FindProperty ("color2");
			color3 = serObj.FindProperty ("color3");
			color4 = serObj.FindProperty ("color4");
			color5 = serObj.FindProperty ("color5");
			color6 = serObj.FindProperty ("color6");
			color7 = serObj.FindProperty ("color7");
            color8 = serObj.FindProperty("color8");
            color9 = serObj.FindProperty("color9");
            color10 = serObj.FindProperty("color10");
            color11 = serObj.FindProperty("color11");
            color12 = serObj.FindProperty("color12");
            color13 = serObj.FindProperty("color13");
            color14 = serObj.FindProperty("color14");
            color15 = serObj.FindProperty("color15");
            color16 = serObj.FindProperty("color16");
            color17 = serObj.FindProperty("color17");
            color18 = serObj.FindProperty("color18");
            color19 = serObj.FindProperty("color19");
            color20 = serObj.FindProperty("color20");
            color21 = serObj.FindProperty("color21");
            color22 = serObj.FindProperty("color22");
            color23 = serObj.FindProperty("color23");
        }

		override public void OnInspectorGUI ()
		{
			serObj.Update ();

			//RetroPixel myTarget = (RetroPixel) target;

			horizontalResolution.intValue = EditorGUILayout.IntField("Horizontal Resolution", horizontalResolution.intValue);
			verticalResolution.intValue = EditorGUILayout.IntField("Vertical Resolution", verticalResolution.intValue);
			numColors.intValue = EditorGUILayout.IntSlider("Number of colors", numColors.intValue, 2, RetroPixel.MAX_NUM_COLORS);

			if (numColors.intValue > 0) color0.colorValue = EditorGUILayout.ColorField("Color 0", color0.colorValue);
			if (numColors.intValue > 1) color1.colorValue = EditorGUILayout.ColorField("Color 1", color1.colorValue);
			if (numColors.intValue > 2) color2.colorValue = EditorGUILayout.ColorField("Color 2", color2.colorValue);
			if (numColors.intValue > 3) color3.colorValue = EditorGUILayout.ColorField("Color 3", color3.colorValue);
			if (numColors.intValue > 4) color4.colorValue = EditorGUILayout.ColorField("Color 4", color4.colorValue);
			if (numColors.intValue > 5) color5.colorValue = EditorGUILayout.ColorField("Color 5", color5.colorValue);
			if (numColors.intValue > 6) color6.colorValue = EditorGUILayout.ColorField("Color 6", color6.colorValue);
			if (numColors.intValue > 7) color7.colorValue = EditorGUILayout.ColorField("Color 7", color7.colorValue);
            if (numColors.intValue > 8) color8.colorValue = EditorGUILayout.ColorField("Color 8", color8.colorValue);
            if (numColors.intValue > 9) color9.colorValue = EditorGUILayout.ColorField("Color 9", color9.colorValue);
            if (numColors.intValue > 10) color10.colorValue = EditorGUILayout.ColorField("Color 10", color10.colorValue);
            if (numColors.intValue > 11) color11.colorValue = EditorGUILayout.ColorField("Color 11", color11.colorValue);
            if (numColors.intValue > 12) color12.colorValue = EditorGUILayout.ColorField("Color 12", color12.colorValue);
            if (numColors.intValue > 13) color13.colorValue = EditorGUILayout.ColorField("Color 13", color13.colorValue);
            if (numColors.intValue > 14) color14.colorValue = EditorGUILayout.ColorField("Color 14", color14.colorValue);
            if (numColors.intValue > 15) color15.colorValue = EditorGUILayout.ColorField("Color 15", color15.colorValue);
            if (numColors.intValue > 16) color16.colorValue = EditorGUILayout.ColorField("Color 16", color16.colorValue);
            if (numColors.intValue > 17) color17.colorValue = EditorGUILayout.ColorField("Color 17", color17.colorValue);
            if (numColors.intValue > 18) color18.colorValue = EditorGUILayout.ColorField("Color 18", color18.colorValue);
            if (numColors.intValue > 19) color19.colorValue = EditorGUILayout.ColorField("Color 19", color19.colorValue);
            if (numColors.intValue > 20) color20.colorValue = EditorGUILayout.ColorField("Color 20", color20.colorValue);
            if (numColors.intValue > 21) color21.colorValue = EditorGUILayout.ColorField("Color 21", color21.colorValue);
            if (numColors.intValue > 22) color22.colorValue = EditorGUILayout.ColorField("Color 22", color22.colorValue);
            if (numColors.intValue > 23) color23.colorValue = EditorGUILayout.ColorField("Color 23", color23.colorValue);

            serObj.ApplyModifiedProperties ();
		}
	}
}
