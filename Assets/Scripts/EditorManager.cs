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

        if (timeline != null)
        {
            timeline.SetTime(audioController.CurrentTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioController.Play();
        }

        if (Input.GetKeyDown(KeyCode.D)) PlaceNote(0);
        if (Input.GetKeyDown(KeyCode.F)) PlaceNote(1);
        if (Input.GetKeyDown(KeyCode.J)) PlaceNote(2);
        if (Input.GetKeyDown(KeyCode.K)) PlaceNote(3);

        timeText.text = audioController.CurrentTime.ToString("F2") + " sec";
    }
}