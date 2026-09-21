using UnityEngine;

public class TimelineController : MonoBehaviour
{
    [Header("Koppelingen")]
    public RectTransform content;      
    public GameObject notePrefab;      

    [Header("Schaal")]
    public float pixelsPerSecond = 100f;
    public float laneHeight = 50f;

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
            Debug.Log("Note gemaakt onder: " + obj.transform.parent.name, obj);
            
            RectTransform rt = obj.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0f, 1f);
            rt.anchorMax = new Vector2(0f, 1f);
            rt.pivot = new Vector2(0f, 1f);
            rt.sizeDelta = new Vector2(20f, 20f);

            rt.anchoredPosition = new Vector2(
                note.time * pixelsPerSecond,
                -note.lane * laneHeight
            );
        }
    }
}