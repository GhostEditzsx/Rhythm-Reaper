using System.IO;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
  public void Save(ChartData chart, string path)
    {
        string json =
            JsonUtility.ToJson(chart, true);

        File.WriteAllText(path, json);
    }
}
