using System;
using TMPro;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public AudioController audioController;
    public NoteEditor noteEditor;
    public TimelineController timeline;

    public TMP_Text timeText;

    public void PlaceNote(int lane)
    {
        noteEditor.AddNote(
            audioController.CurrentTime,
            lane
        );

        

        if (timeline != null)
        {
            timeline.Refresh(noteEditor.chart);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioController.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlaceNote(0);
        }

        timeText.text = audioController.CurrentTime.ToString("F2") + " sec";
    }
}