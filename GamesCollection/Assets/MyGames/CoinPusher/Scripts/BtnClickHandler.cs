using UnityEngine;
using UnityEngine.EventSystems;

public class BtnClickHandler : MonoBehaviour, IPointerClickHandler
{
    public Camera cameraToActivate;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clic sur : " + gameObject.name);
        Camera[] allCams = Resources.FindObjectsOfTypeAll<Camera>();
        if (cameraToActivate != null)
        {
            foreach (Camera cam in allCams)
            {
                cam.enabled = false;
            }

            cameraToActivate.enabled = true;
        }
        else
        {
            Debug.LogError("Aucune caméra n'est assignée à ce bouton : " + gameObject.name);
        }

    }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
