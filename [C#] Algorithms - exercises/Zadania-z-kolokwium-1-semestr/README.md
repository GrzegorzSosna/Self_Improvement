# Zadania z kolokwium na pierwszym roku studiów informatycznych
⬇️<b> Zadanie 1 </b>⬇️
<br><br>
W pliku numeryKart.txt znajduje się lista 16-cyfrowych numerów kart płatniczych i imion (z ewentualny drugim imieniem) z nazwiskami ich właścicieli. Dane są podane w kolejnych wierszach a numery i imię i nazwisko są oddzielone przecinkiem. Zadanie polega na napisaniu programu, który tworzy plik numeryKartMaskowane.txt z zawartością numeryKart.txt, w którym:
<br>
1. Nie ma nagłówka ("numer karty,imię [drugie imię] nazwisko") i numery i imię z nazwiskiem są oddzielone średnikiem.
2. Cyfry numerów kart od piątej do dwunastej są zastąpione X.
3. Drugie imię jest pomijane a nazwisko zostaje skrócone do pierwszej litery i za nim jest kropka.
Fragment pliku, który powinniśmy otrzymać:
![image](https://user-images.githubusercontent.com/103256053/177726827-21f1eade-efd6-4370-84a9-c8bb41a9a16a.png)
<br>
Program powinien działać dla dowolnej liczby wierszy w pliku źródłowym (ale możemy pominąć kwestię maksymalnego rozmiaru bufora). Ścieżki pliku wejściowego i wyjściowego mogą być zaszyte w kodzie. Należy użyć klasy StringBuilder.
<br><br><br>
⬇️<b> Zadanie 2 </b>⬇️
<br><br>
Napisz procedurę o argumentach folderZrodlowy, folderDocelowy, która będzie przenosić wszystkie pliki z folderu źródłowego do folderu docelowego o ile ich nazwy kończą się na "Maskowane". Nieprzeniesione pliki mają zostać usunięte. Można skorzystać z metod Move/MoveTo klasy FileInfo.
<br><br><br>
⬇️<b> Zadanie 3 </b>⬇️
<br><br>
Napisz program zapisujący do dwóch zmiennych string aktualną datę i czas w dwóch różnych formatach. Następnie napisz kod pozwalający wypisać na ekran najdłuższy wspólny fragment obu ciągów tekstowych. Przykład:

![image](https://user-images.githubusercontent.com/103256053/178202760-1d089bf1-1760-475c-9beb-33c5d7db2b73.png)
<br>
