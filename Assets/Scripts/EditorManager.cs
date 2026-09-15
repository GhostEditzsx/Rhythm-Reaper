using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public AudioController audioController;
    public NoteEditor noteEditor;
    public TimelineController timeline;

    public void PlaceNote(int lane)
    {
        noteEditor.AddNote(
            audioController.CurrentTime,
            lane
        );

        timeline.Refresh(noteEditor.chart);
    }

    public AudioController AudioController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            {
                AudioController.Pause();
            }
        }
    }
}