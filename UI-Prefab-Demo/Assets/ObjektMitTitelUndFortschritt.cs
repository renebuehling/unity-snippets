using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektMitTitelUndFortschritt : ObjektMitTitel
{
    public float fortschritt = 0f;

    private bool zaehlerLaeuft = true;

    public void Update()
    {
        if (!zaehlerLaeuft) return; 

        fortschritt += (0.5f * Time.deltaTime); // im Verlauf einer Sekunde Fortschritt um 0.5 hochzählen
        fortschritt = fortschritt % 1; // Mit modulo-Operation (=Rest der Division) sicherstellen, dass der Wert zwischen 0 und 1 bleibt.
        
        if (mausUeberObjekt)
        {
            EventBus.bus.beiObjektMitTitelAenderung_aufrufen(this);
        }
    }


    public void AktionAusfuehren()
    {
        zaehlerLaeuft = !zaehlerLaeuft;

        //if (zaehlerLaeuft) zaehlerLaeuft = false;
        //else zaehlerLaeuft = true;
    }
}
