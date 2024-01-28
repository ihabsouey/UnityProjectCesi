using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public PointOfInterest PointOfInterestPrefab;
    List<PointOfInterest> pointOfInterestList = new List<PointOfInterest>();
    int _currentID = 0;

    public EditorWindow EditorWindow;
    public GameObject Player;

    public string path;
    public string ConfigFileName;

    public void CreateNewPointOfInterest(Vector3 playerPos, Vector3 playerRotation)
    {
        var poiPosition = playerPos + (playerRotation);
        poiPosition.y = 0.0f;
        PositionStruct posStruct = new PositionStruct(poiPosition.x, poiPosition.z);
        var poi = Instantiate(PointOfInterestPrefab, poiPosition, PointOfInterestPrefab.transform.rotation);
        poi.InitializePOI(_currentID++, posStruct);
        pointOfInterestList.Add(poi);
    }

    public void DeletePointOfInterest(int id)
    {
        var poi = GetPointOfInterestById(id);
        pointOfInterestList.Remove(poi);
        GameObject.Destroy(poi.gameObject);
    }

    public void SavePointOfInterest(PointOfInterestStruct poiData)
    {
        var poi = GetPointOfInterestById(poiData.Id);
        poi.PointOfInterestData = poiData;
    }

    protected PointOfInterest GetPointOfInterestById(int id)
    {
        return pointOfInterestList.Where(x => x.PointOfInterestData.Id == id).First();
    }



    public void DisplayPOI(PointOfInterestStruct poiInfo)
    {
        EditorWindow.FillData(poiInfo);
        EditorWindow.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Player.SetActive(false);
    }

    public void HidePOI()
    {
        EditorWindow.gameObject.SetActive(false);

        Player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
      private void Start()
    {
        path = Application.streamingAssetsPath + "/" + ConfigFileName;
        LoadScene();
    }

    public void LoadScene()
    {
        if (!File.Exists(path))
        {
            return;
        }
        using (StreamReader file = File.OpenText(path))
        {
            JsonSerializer serializer = new JsonSerializer();
            List<PointOfInterestStruct> poiList = (List<PointOfInterestStruct>)serializer.Deserialize(file, typeof(List<PointOfInterestStruct>));
            if(poiList == null)
            {
                return;
            }
            foreach (var pointOfInterest in poiList)
            {
                var poi = Instantiate<PointOfInterest>(PointOfInterestPrefab);
                poi.PointOfInterestData = pointOfInterest;
                pointOfInterestList.Add(poi);
            }
        }

    }

    public void SaveScene()
    {
        var poiStructList = new List<PointOfInterestStruct>();
        pointOfInterestList.ForEach(x => poiStructList.Add(x.PointOfInterestData));
        string json = JsonConvert.SerializeObject(poiStructList);

        using (StreamWriter file = new StreamWriter(path))
        {
            file.Write(json);
        }
    }


}
