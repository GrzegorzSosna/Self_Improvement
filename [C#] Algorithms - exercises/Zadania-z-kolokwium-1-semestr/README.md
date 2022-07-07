# Zadanie 1
<br>
W pliku numeryKart.txt znajduje się lista 16-cyfrowych numerów kart płatniczych i imion (z ewentualny drugim imieniem) z nazwiskami ich właścicieli. Dane są podane w kolejnych wierszach a numery i imię i nazwisko są oddzielone przecinkiem. Zadanie polega na napisaniu programu, który tworzy plik numeryKartMaskowane.txt z zawartością numeryKart.txt, w którym:
<br>
1. Nie ma nagłówka ("numer karty,imię [drugie imię] nazwisko") i numery i imię z nazwiskiem są oddzielone średnikiem.
2. Cyfry numerów kart od piątej do dwunastej są zastąpione X.
3. Drugie imię jest pomijane a nazwisko zostaje skrócone do pierwszej litery i za nim jest kropka.
Fragment pliku, który powinniśmy otrzymać:
<br>
Program powinien działać dla dowolnej liczby wierszy w pliku źródłowym (ale możemy pominąć kwestię maksymalnego rozmiaru bufora). Ścieżki pliku wejściowego i wyjściowego mogą być zaszyte w kodzie. Należy użyć klasy StringBuilder.
