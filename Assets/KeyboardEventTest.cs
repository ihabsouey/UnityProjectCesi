using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;
using UnityEngine.UI;
// Add KeyboardEventTest to a GameObject with a valid UIDocument.
// When the user presses a key, it will print the keyboard event properties to the console.
[RequireComponent(typeof(UIDocument))]

public class KeyboardEventTest : MonoBehaviour
{
   
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(new Label("To be a host choose H and to be client choose C"));
    }
    void Update()
    {
         var root = GetComponent<UIDocument>().rootVisualElement;
   
        if (Input.GetKeyDown(KeyCode.H))
        {
            try
            {
                NetworkManager.Singleton.StartHost();
                Debug.Log("Started as a host");
                // remove the label
                root.Clear();
                root.Add(new Label("To switch the light tap : L "));
                root.Add(new Label("To call the Mir100 tap  : G "));
            }
            catch (System.Exception)
            {
                Debug.Log("Already a host");
            }

     

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            try
            {
                NetworkManager.Singleton.StartClient();
                Debug.Log("Started as a client");
                root.Clear();
                root.Add(new Label("To switch the light tap : L  "));
                root.Add(new Label("To call the Mir100 tap  : G  "));
            }
            catch (System.Exception)
            {
                Debug.Log("Already a client");
            }


        }
}
   

 
}