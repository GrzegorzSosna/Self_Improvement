#!/bin/bash

time=5
line="--------------------------------"

SavingSystemInformation() 
{
    clear
    echo "--- Zapis do pliku ---"
    echo -e "\nW tym katalogu znajduje się $(ls | wc -w) plikow: " 
    ls -a   
    read -p "Podaj nazwe pliku .txt: " file
    textFile=$file".txt"
    
    if [ -f $textFile ]; then
        echo "Plik $textFile istnieje. Kasowanie i tworzenie nowego."
        rm $textFile
        touch $textFile
    else
        echo "Tworzenie nowego pliku z informacjami."
        touch $textFile
    fi
    
    echo "--- Informacje o systemie oraz architekturze sprzetowej ---" >> $textFile
    echo -n "Zalogowany uzytkownik: " >> $textFile
    whoami >> $textFile
    echo "Identyfikator biezacego uzytkownika: $EUID " >> $textFile
    echo -e "\nKatalog domowy: $HOME " >> $textFile
    echo "Katalog bieżący: $PWD " >> $textFile
    echo $linia >> $textFile
    echo "Informacje o pamieci: " >> $textFile
    free >> $textFile
    echo $linia >> $textFile
    echo "Rodzaj systemu: " >> $textFile
    echo $OSTYPE >> $textFile
    echo $linia >> $textFile
    echo "Nazwa terminala: " >> $textFile
    echo $TERM >> $textFile
    echo $linia >> $textFile
    echo "Informacje o architekturze sprzetowej: " >> $textFile
    #uname --m >> $textFile
    echo $HOSTTYPE >> $textFile
    echo "Zakonczono zapis danych w pliku $textFile"
}

ReadingSystemInformation()
{
    clear
    echo "--- Odczytywanie informacji z plikow ---"
    echo -e "\nW tym katalogu znajduje się $(ls | wc -w) plikow: " 
    ls -a   
    read -p "Podaj nazwe pliku .txt: " file
    textFile=$file".txt"
    
    if [ -f $textFile ]; then
        cat $textFile
    else
        echo "Brak pliku $textFile na dysku."
    fi
    sleep $time
}

DeletingFiles()
{
    clear
    echo "--- Usuwanie plikow ---"
    echo -e "\nW tym katalogu znajduje się $(ls | wc -w) plikow: " 
    ls -a
    read -p "Podaj nazwe pliku .txt który chcesz usunac: " file
    textFile=$file".txt"
    
    if [ -f $textFile ]; then
        echo "Plik $textFile zostal usuniety."
        rm $textFile
    else
        echo "Plik $textFile nie istnieje."
    fi
}

RenamingFiles()
{
    clear
    echo "--- Zmiana nazwy plikow ---"
    echo -e "\nW tym katalogu znajduje się $(ls | wc -w) plikow: " 
    ls -a
    read -p "Podaj nazwe pliku .txt ktorego nazwe chcesz zmienic: " file
    textFile=$file".txt"
    
    if [ -f $textFile ]; then
        read -p "Podaj nowa nazwe: " newName
        newNameFile=$newName".txt"
        echo "Nazwa pliku $textFile zostala zmieniona na $newNameFile"
        mv $textFile $newNameFile
    else
        echo "Plik $textFile nie istnieje."
    fi  
}

SearchingFiles()
{
    clear
    echo "--- Wyszukiwanie plikow ---"
    echo -e "\nSzukaj po:" 
    echo "1) Nazwie"
    echo "2) Rozmiarze wiekszym niz 500KB"
    echo "3) Rozmiarze mniejszym niz 500KB"
    echo "4) Wyszukiwanie 3 plikow o najwiekszym rozmiarze"
    echo "5) Wyszukiwanie plikow zmodyfikowanych w ciagu ostatnich 10 minut"
    echo "6) Wyszukiwanie plikow po nazwie uzytkownikow"
    read -p "Wybierz: " choose
    
    case $choose in
    "1") read -p "Wpisz cala lub czesc nazwy pliku: " nameFile
    find -type f -name "*$nameFile*.txt" -print -ls;;
    "2") find -type f -size +500k;;
    "3") find -type f -size -500k;;
    "4") find -type f -ls | sort -r -n -k 7 | head -n 3;;
    "5") find -type f -mmin -10;;
    "6") read -p "Wpisz nazwe uzytkownika: " userName
    find -type f -user "$userName" -print -ls;;
    *) echo "Niepoprawny wybor";;
    esac
}

SearchingTextInFiles()
{
    clear
    echo "--- Wyszukiwanie tekstu w plikach ---"
    echo -e "\nW tym katalogu znajduje się $(ls | wc -w) plikow: " 
    ls -a
    read -p "Wpisz tekst ktory chcesz wyszukac: " text
    find -type f -iname "*.txt" | xargs grep -i "$text" 
}

Menu()
{
    while [ "$choose" != "0" ] 
    do 
        clear
        echo -e "--- Menu (informacje o systemie oraz architekturze sprzetowej) ---\n\n1) Zapis do pliku \n2) Odczyt z pliku \n3) Usuwanie plikow \n4) Zmiana nazwy plikow \n5) Wyszukiwanie plikow \n6) Wyszukiwanie tekstu w plikach \n0) KONIEC"
        read -p "Wybierz: " choose
    
        case $choose in
        "1") SavingSystemInformation;;
        "2") ReadingSystemInformation;;
        "3") DeletingFiles;;
        "4") RenamingFiles;;
        "5") SearchingFiles;;
        "6") SearchingTextInFiles;;
        "0") echo "Koniec";;
        *) echo "Niepoprawny wybor";;
        esac
        sleep $time
    done
}

Menu
