# Wseicraft2024

Czterowarstwowa, top-downowa gra akcji z elementami dungeon crawlera stworzona w Unity. Repozytorium zawiera skrypty gry, prefabry, animacje, mapy, tekstury oraz elementy środowiska, które tworzą prototyp rozgrywki z walką, generowaniem pomieszczeń i cyklem dzień/noc.

## Opis projektu

Projekt przedstawia top-downowego bohatera poruszającego się po kolejnych pomieszczeniach, walczącego z przeciwnikami i eksplorującego generowaną mapę. Gra wykorzystuje prosty system ataku, dash, poruszania, animacji postaci oraz zmieniające się warunki środowiskowe w zależności od pory dnia.

Najważniejsze elementy projektu:
- poruszanie gracza klawiszami WASD
- atak myszką (kliknięcie lewym przyciskiem)
- szybki dash na spację
- walka z przeciwnikami z różnymi typami ruchu i zachowania
- generowanie losowych pomieszczeń / lokalizacji
- cykl dzień/noc wpływający na wygląd świata i zachowanie przeciwników
- animacje postaci i wrogów
- assety mapy i prefabry obiektów

## Główne systemy gry

### 1. Poruszanie i walka gracza
Skrypt `Scripts/PlayerMovement.cs` odpowiada za:
- ruch gracza
- obrót/odwracanie sprite'a
- animacje ruchu
- dash
- sprawdzanie stanu zdrowia i przejście do sceny śmierci

Skrypt `Scripts/PlayerAttack.cs` odpowiada za:
- atak w kierunku ruchu gracza
- wykrywanie przeciwników w zasięgu ataku
- uruchamianie efektu wstrząsu kamery
- zadawanie obrażeń z pomocą `Enemy.TakeDamage()`

### 2. Przeciwnicy
Skrypt `Scripts/Enemy.cs` obsługuje:
- zdrowie przeciwnika
- obrażenia
- animację bólu
- śmierć i wyłączenie kolidera

Dodatkowo repo zawiera skrypty typu:
- `EnemyMovement.cs`
- `EnemyMele.cs`
- `EnemyRange.cs`

co sugerują różne style walki i ruchu wrogów.

### 3. Generowanie mapy
Skrypt `Scripts/MapGenerator.cs` generuje siatkę pomieszczeń na planszy:
- losowo wybiera pomieszczenia z listy
- instaluje je w kolejnych pozycjach
- tworzy prosty poziom proceduralny

### 4. Cykl dzień/noc
Skrypt `Scripts/DayNightCycle.cs` kontroluje zmiany stanu świata:
- przełączanie pomiędzy dniem a nocą
- zmiana prędkości gracza
- zmiana zachowania przeciwników
- aktywacja animacji słońca / zmiany warstwy mapy

### 5. Obiekty środowiskowe
Skrypt `Scripts/DayNightObject.cs` obsługuje obiekty, które zmieniają swoje zachowanie lub wygląd w zależności od pory dnia.

## Struktura repozytorium

- `Scripts/` — skrypty Unity C# kontrolujące grę
- `Animations/` — animacje postaci i przeciwników
- `CharactersPrefabs/` — prefabry postaci i obiektów gry
- `Map/` — prefabry pomieszczeń i elementy mapy
- `MapTextures/` — tekstury atlasowe dla środowiska
- `Image/` — graficzne elementy dekoracyjne i tła
- `Music/` — pliki muzyczne / dźwiękowe
- `Textures/` — ogólne tekstury projektu
- `images/` — dodatkowe grafiki

## Kontrolki

- `WASD` — poruszanie
- `Spacja` — dash
- `Lewy przycisk myszy` — atak

## Jak uruchomić

1. Otwórz projekt w Unity.
2. Zaimportuj repozytorium jako projekt Unity lub użyj jego zawartości jako zasobów projektu.
3. Ustaw odpowiednią scenę główną / startową, jeśli projekt jest rozdzielony na wiele scen.
4. Naciśnij Play, aby uruchomić grę.

Uwaga: repozytorium wygląda na zbiór zasobów i skryptów prototypu Unity, dlatego może wymagać dodatkowej konfiguracji scen, prefabów i ustawień projektu w środowisku Unity.

## Zależności / technologia

- Unity
- C#
- 2D game development
- Rigidbody2D, Animator, Physics2D, prefabry i skrypty MonoBehaviour

## Status projektu

To jest prototyp lub wczesna wersja gry. Repozytorium zawiera dużo zasobów artystycznych i systemów technicznych, ale może nie być jeszcze w pełni zintegrowane jako skończony, gotowy do publikacji produkt.

## Licencja

Brak określonej licencji w repozytorium. Jeśli chcesz użyć projektu komercyjnie lub publicznie, najpierw sprawdź prawa autorskie i skontaktuj się z właścicielem repozytorium.

## Autor

Repozytorium należy do użytkownika `EFoxStudio`.

## Podsumowanie

`Wseicraft2024` to prototyp gry akcyjnej w stylu top-down z generowaną mapą, walką, przeciwnikami i cyklem dzień/noc. Projekt jest zbudowany na fundamentach Unity i zawiera gotowe skrypty oraz assety do dalszego rozwoju.
