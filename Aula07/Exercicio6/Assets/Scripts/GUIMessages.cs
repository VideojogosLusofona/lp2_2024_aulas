﻿using UnityEngine;

public class GUIMessages : MonoBehaviour
{
    // The messages fade speed
    [SerializeField] [Range(0.1f, 1f)] float fadeSpeed = 0.6f;

    // Degree of visibility of each label
    private float visibilityW;
    private float visibilityA;
    private float visibilityS;
    private float visibilityD;

    // Start is called before the first frame update
    private void Start()
    {
        // Set visibility of all labels to zero
        visibilityW = 0f;
        visibilityA = 0f;
        visibilityS = 0f;
        visibilityD = 0f;
    }

    private void Update()
    {
        // If any of the labels are visible, fade them
        if (visibilityW > 0) visibilityW -= fadeSpeed * Time.deltaTime;
        if (visibilityA > 0) visibilityA -= fadeSpeed * Time.deltaTime;
        if (visibilityS > 0) visibilityS -= fadeSpeed * Time.deltaTime;
        if (visibilityD > 0) visibilityD -= fadeSpeed * Time.deltaTime;
    }

    // This draws the immediate mode GUI each frame
    private void OnGUI()
    {
        // Define labels style
        Color baseColor = Color.yellow;
        GUIStyle style = GUIStyle.none;

        style.fontSize = 25;
        style.fontStyle = FontStyle.Bold;

        // Set this GUI rendering to foreground
        GUI.depth = 0;

        // If W label is visible, show it
        if (visibilityW > 0)
        {
            // Set alpha (transparency) for this label
            baseColor.a = visibilityW;
            style.normal.textColor = baseColor;
            // Show label
            GUI.Label(new Rect(300, 200, 300, 50), "W was pressed!", style);
        }
        // If A label is visible, show it
        if (visibilityA > 0)
        {
            // Set alpha (transparency) for this label
            baseColor.a = visibilityA;
            style.normal.textColor = baseColor;
            // Show label
            GUI.Label(new Rect(300, 225, 300, 50), "A was pressed!", style);
        }
        // If S label is visible, show it
        if (visibilityS > 0)
        {
            // Set alpha (transparency) for this label
            baseColor.a = visibilityS;
            style.normal.textColor = baseColor;
            // Show label
            GUI.Label(new Rect(300, 250, 300, 50), "S was pressed!", style);
        }
        // If D label is visible, show it
        if (visibilityD > 0)
        {
            // Set alpha (transparency) for this label
            baseColor.a = visibilityD;
            style.normal.textColor = baseColor;
            // Show label
            GUI.Label(new Rect(300, 275, 300, 50), "D was pressed!", style);
        }
    }

    // This method is the event listener
    // It will be listening to EventMaster events
    // It simply sets alpha to 1 (no transparency) each time a key is pressed
    public void ShowGUIMessage(char key)
    {
        switch (key)
        {
            case 'W':
                visibilityW = 1f;
                break;
            case 'S':
                visibilityS = 1f;
                break;
            case 'A':
                visibilityA = 1f;
                break;
            case 'D':
                visibilityD = 1f;
                break;
        }
    }
}
