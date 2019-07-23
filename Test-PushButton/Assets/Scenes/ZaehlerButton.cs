using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZaehlerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float warteNoch=0f;
    
    // Update is called once per frame
    void Update()
    {
        if (mausIstGedrueckt)
        {
            if (warteNoch <= 0f) //Wartezeit abgelaufen
            {
                WennButtonAngeklickt();
                warteNoch = 0.5f; //Wartezeit bis WennButtonAngeklickt wieder ausgelöst wird
            }
            else
            {
                warteNoch -= Time.deltaTime; //verstrichene Zeit von Wartezeit abziehen
            }
        }
        else //maus ist nicht gedrückt
        {
            warteNoch = 0f;
        }
    }

    public Text textfeld;

    public void WennButtonAngeklickt()
    {
        int aktuelleZahl = 0;
        int.TryParse(textfeld.text, out aktuelleZahl);

        aktuelleZahl += 1;
        textfeld.text = aktuelleZahl.ToString();
    }

    private bool mausIstGedrueckt = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Maus gedrückt.");
        mausIstGedrueckt = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Maus losgelassen.");
        mausIstGedrueckt = false;
    }
}
