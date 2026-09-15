using UnityEngine;

public class NoteEditor : MonoBehaviour
{
    public ChartData chart;

    public void AddNote(float time, int lane)
    {
        chart.notes.Add(new NoteData
        {
            time = time,
            lane = lane
        });
    }
}