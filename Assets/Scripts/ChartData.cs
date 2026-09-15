using System.Collections.Generic;

[System.Serializable]
public class ChartData
{
    public float bpm;
    public List<NoteData> notes = new();
}