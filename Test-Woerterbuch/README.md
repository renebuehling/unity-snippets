# W�rterbuch

## Textfile-Format

- Zeilen, die mit `;` beginnen, sind Kommentare und werden ignoriert.
- Wenn eine Zeile aus Wort+Leerzeichen+Text besteht, wird Wort als Schl�ssel und der Text als Wert gespeichert.
- Leere Zeilen und Zeilen ohne Leerzeichen werden ignoriert.
- Zeilenumbr�che k�nnen mit `\n` oder `<br>` erzeugt werden.
- Einfache Formatierungen sind mit Unitys [Text-Markup](https://docs.unity3d.com/Manual/StyledText.html) m�glich, sofern das Ziel-Textfeld die Eigenschaft `richText` gesetzt hat.

Beispiel: 
```
; 
; Zeilenumbr�che k�nnen mit \n oder <br> erzeugt werden.
1 Hallo.
Zwei Wie geht es Dir. <br>Neue Zeile\nZeile3
formatiert Das ist ein <b>rich</b> <color=red>Text</color>, der einige grundlegende <i>Formatierungen</i> unterst�tzt.
```