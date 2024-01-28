using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
    
public class EditorWindow : MonoBehaviour
{
        public EditorManager EditorManager;
        public TMP_InputField TitleInputField, ContentTextField;

        private PointOfInterestStruct _poiInfo;
        public void FillData(PointOfInterestStruct poiInfo)
        {
            this._poiInfo = poiInfo;
            TitleInputField.text = poiInfo.Title;
            ContentTextField.text = poiInfo.Description;
        }

        public void SavePOI()
        {
            _poiInfo.Title = TitleInputField.text;
            _poiInfo.Description = ContentTextField.text;

            EditorManager.SavePointOfInterest(_poiInfo);
            EditorManager.HidePOI();

    }

    public void DeletePOI()
        {
            EditorManager.DeletePointOfInterest(_poiInfo.Id);
            EditorManager.HidePOI();

    }

}
