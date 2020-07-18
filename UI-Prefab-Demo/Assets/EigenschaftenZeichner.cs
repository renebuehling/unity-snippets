using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Stellt Objekteigenschaften im UI dar. 
/// 
/// Dieses Script wird an einen Canvas gehängt, der die
/// konkreten Darstellungskomponenten (Text, Button, etc.) 
/// enthält.
/// 
/// </summary>
public class EigenschaftenZeichner : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf die Textkomponente, die den Text auf dem
    /// Bildschirm zeichnet.
    /// </summary>
    public Text textName;

    /// <summary>
    /// Zeiger auf die RawImage-Komponente, die das Symbol 
    /// von ObjektMitTitel zeichnet. 
    /// </summary>
    public RawImage icon;

    /// <summary>
    /// RawImage für den Laufbalken der Fortschrittsanzeige.
    /// </summary>
    public RawImage fortschritt;

    public RawImage fortschrittsBalken;

    public Button aktionsButton;

    protected ObjektMitTitel dasAktuelleObjekt = null;

    /// <summary>
    /// Löst die Darstellung auf, d.h. der Titel des Objekts
    /// aus dem Ereignis wird nun konkret in der Textkomponente
    /// auf dem Bildschirm gezeichnet.
    /// </summary>
    /// <param name="dasObjekt">Objekt dessen Titel gezeichnet werden soll. Kann null sein, um den Text zu leeren.</param>
    public void zeichneObjekt(ObjektMitTitel dasObjekt)
    {
        dasAktuelleObjekt = dasObjekt;
        if (dasObjekt == null) // Kein Objekt -> leerer Text
        {
            textName.text = "";
            icon.enabled = false;
            fortschrittsBalken.gameObject.SetActive(false);
            aktionsButton.gameObject.SetActive(false);
        }
        else // Konkretes Objekt -> dessen Eigenschaften zeichnen
        {
            textName.text = dasObjekt.titel;
            icon.texture = dasObjekt.icon;
            icon.enabled = (dasObjekt.icon != null);

            if (dasObjekt.GetType() == typeof(ObjektMitTitelUndFortschritt))
            {
                Vector3 neueGroesse = new Vector3(1f,1f,1f);
                neueGroesse.x = ((ObjektMitTitelUndFortschritt)dasObjekt).fortschritt;
                fortschritt.GetComponent<RectTransform>().localScale = neueGroesse;
                fortschrittsBalken.gameObject.SetActive(true);
                aktionsButton.gameObject.SetActive(true);
            }
            else //kein ObjektMitTitelUndFortschritt
            {
                fortschrittsBalken.gameObject.SetActive(false);
                aktionsButton.gameObject.SetActive(false);
            }
        }
    }


    /// <summary>
    /// Wenn der Eigenschaftenzeichner erzeugt wurde und bereit ist...
    /// </summary>
    public void Awake()
    {
        zeichneObjekt(null); //zu Beginn alles ausblenden
        EventBus.bus.beiObjektMitTitelAenderung += zeichneObjekt; // Im Eventbus registrieren, dass die oben definierte Funktion zeichneObjekt aufgerufen wird.
    }

    public void OnDestroy()
    {
        EventBus.bus.beiObjektMitTitelAenderung -= zeichneObjekt; // Wenn dieser EigenschaftenZeichner gelöscht wird, auch die Benachrichtung wieder auflösen. (Sonst NullPointerException, wenn versucht wird, die Nachricht an das nicht mehr vorhandene Objekt zu schicken.)
    }

    public void BeiAktionsButtonClick()
    {
        Debug.Log("Button geklickt");

        if ( dasAktuelleObjekt!=null && dasAktuelleObjekt.GetType() == typeof(ObjektMitTitelUndFortschritt))
        {
            ((ObjektMitTitelUndFortschritt)dasAktuelleObjekt).AktionAusfuehren();
        }
    }

}
