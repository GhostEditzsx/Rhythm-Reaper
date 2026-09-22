using UnityEngine;

public class TimelineController : MonoBehaviour
{
    [Header("Koppelingen")]
    public RectTransform content;     
    public GameObject notePrefab;     

    [Header("Schaal (verticaal: tijd omhoog, lanes naast elkaar)")]
    public int laneCount = 4;
    public float pixelsPerSecond = 100f;
    public float laneWidth = 80f;
    public float noteHeight = 20f;

    [Header("Playhead")]
    public float playheadOffset = 100f;   

    
    
    public void SetTime(float time)
    {
        if (content == null) return;

        content.anchoredPosition = new Vector2(
            0f,
            playheadOffset - time * pixelsPerSecond
        );
    }

    public void Refresh(ChartData chart)
    {
        if (content == null || notePrefab == null || chart == null)
        {
            Debug.LogWarning("TimelineController: Content, Note Prefab of chart ontbreekt.");
            return;
        }

        
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        foreach (NoteData note in chart.notes)
        {
            GameObject obj = Instantiate(notePrefab, content);
            RectTransform rt = obj.GetComponent<RectTransform>();

            
            
            rt.anchorMin = new Vector2(0.5f, 0f);
            rt.anchorMax = new Vector2(0.5f, 0f);
            rt.pivot = new Vector2(0.5f, 0.5f);

            rt.sizeDelta = new Vector2(laneWidth - 10f, noteHeight);



            
            float laneX = (note.lane - (laneCount - 1) / 2f) * laneWidth;

            rt.anchoredPosition = new Vector2(
                laneX,                          
                note.time * pixelsPerSecond    
               
            );


        }
    }
}