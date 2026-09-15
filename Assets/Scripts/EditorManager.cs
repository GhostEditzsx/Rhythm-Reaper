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
}