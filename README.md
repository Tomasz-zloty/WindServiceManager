Projekt zaliczeniowy — aplikacje .NET

# Wind Service Manager

Aplikacja webowa Blazor Server do zarządzania farmą wiatrową (monitoring turbin, zgłoszenia serwisowe, status pracy zespołów).

## Wymagania

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Uruchomienie

```bash
cd WindServiceManager
dotnet restore
dotnet run
```

Aplikacja uruchomi się pod adresem: **[http://localhost:5007](http://localhost:5007)**

Przy pierwszym starcie tworzony jest plik bazy SQLite `windservice.db`.

## Zakładki aplikacji


| Zakładka       | Opis                                                       |
| -------------- | ---------------------------------------------------------- |
| **Pulpit**     | Statystyki farmy, aktywny serwis, procedury BHP            |
| **Dashboard**  | Karty turbin ze zmianą statusu (sprawna / serwis / awaria) |
| **Turbiny**    | Dodawanie i usuwanie turbin                                |
| **Zgłoszenia** | Przegląd i zgłaszanie usterek serwisowych                  |


## Technologie

- Blazor Server (.NET 10)
- Entity Framework Core
- SQLite

## Autor  
Tomasz Złotkowski

