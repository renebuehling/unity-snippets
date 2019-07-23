using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

/// <summary>
/// Stellt einen Mechanismus bereit, um Textfragmente aus einer Textdatei zu lesen.
/// Verwendung: Einem beliebigen GameObject ein Woerterbuch-Script im Inspector hinzufügen 
/// und der Eigenschaft textfile im Inspector eine Textdatei in den Projekt-Assets zuweisen.
/// Dann an den gewünschten Stellen lies("schlüssel") auf dem Woerterbuch aufrufen.
/// 
/// Die Textdatei unterstützt folgende Formate:
/// - Zeilen, die mit ; beginnen werden ignoriert (Kommentarzeilen)
/// - Zeilen, die einen Wörterbuchinhalt beschreiben müssen der Form "Schlüssel Wert..." folgen
/// - Leere Zeilen und Zeilen ohne Leerzeichen werden ignoriert
/// 
/// 
/// MIT License
/// 
/// Copyright(c) 2019 René Bühling, www.buehling.org
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in all
/// copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
/// SOFTWARE.
/// </summary>
public class Woerterbuch : MonoBehaviour
{
    /// <summary>
    /// Wörterbuch mit ausgelesenen Text-Fragmenten.
    /// </summary>
    private Dictionary<string, string> words = new Dictionary<string, string>();

    #if UNITY_EDITOR
    [Tooltip(".txt-Datei mit Texten. Jede Zeile muss aus Schlüssel und Wert bestehen, getrennt mit Leerzeichen.")]
    #endif
    public TextAsset textfile = null;

    /// <summary>
    /// Lädt ein neues Textfile, setzt <see cref="textfile"/> und liest den Inhalt neu ein.
    /// Rufe diese Funktion auf, um während des Spiels die Textdatei auszutauschen.
    /// </summary>
    /// <param name="textfile">Neue Textdatei.</param>
    public void setzeTextfile(TextAsset textfile)
    {
        this.textfile = textfile;
        textEinlesen();
    }
    
    /// <summary>
    /// Liest den im textfile Asset gespeicherten Text ein.
    /// </summary>
    private void textEinlesen()
    {
        if (textfile==null)
        {
            Debug.LogWarning("Dem Wörterbuch wurde keine Textdatei im Inspector zugewiesen.");
            return;
        }
        words.Clear();
        string[] lines = Regex.Split(textfile.text, "\r\n|\r|\n");
        for (int i = 0; i < lines.Length; i++) //parse key/value pairs
        {
            zeileEinlesen(lines[i]);
        }

        Debug.Log("Es wurden " + words.Count + " Schlüssel-Wert-Paare eingelesen.");
    }

    /// <summary>
    /// Wertet eine Textzeile aus. 
    /// Wenn sie der Form "key value" ist, wird value unter key im Wörterbuch abgespeichert.
    /// 
    /// Wird normalerweise nur von textEinlesen() verwendet.
    /// </summary>
    /// <param name="line">Auszuwertende Zeile.</param>
    private void zeileEinlesen(string line)
    {
        if (line.Length == 0 || line.StartsWith(";")) return; //Kommentar
        if (line.IndexOf(" ") < 0) return; //Unvollständig, enthält kein Leerzeichen
        string k = line.Substring(0, line.IndexOf(" ")); //Text vor dem ersten Leerzeichen ist der Schlüssel
        string v = line.Substring(line.IndexOf(" ") + 1); //Text nach dem ersten Leerzeichen ist der Wert
        //Debug.Log("key="+k+", val="+v);
        words[k] = v;
    }

    /// <summary>
    /// Aufrufen, um einen Begriff aus dem Wörterbuch zu holen.
    /// Kann von überall aus aufgerufen werden, um einen benannten Text zu holen. 
    /// </summary>
    /// <param name="key">Schlüssel</param>
    /// <returns>Wert, der beim Schlüssel hinterlegt wurde.</returns>
    public string lies(string key)
    {
        if (words.ContainsKey(key)) return words[key].Replace("\\n", "\n").Replace("<br>", "\n");
        else return "[Fehlt:" + key + "]";
    }

    private void Start()
    {
        textEinlesen();
    }

}
