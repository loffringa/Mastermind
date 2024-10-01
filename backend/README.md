# Mastermind Backend
Dit is de backend applicatie die nodig is voor het succesvol draaien van de mastermind frontend (zie de map `frontend`)

## Benodigdheden
- .Net SDK 7.0 (https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

## Project setup
- Clone de repository
    ```
    git clone https://github.com/che-ict/ICT-VK-T-19-mastermind
    ```
- Visual Studio Code
  - Doe `CTRL`, `Shift` + `P`
  - Zoek en selecteer `Run task`
  - Selecteer `watch`
- Visual Studio
  - Open `Mastermind.sln`
  - Start de applicatie

## Productie
Voor het maken van een productie applicatie, bouw de applicatie als volgt.

**Visual Studio Code**
- Doe `CTRL`, `Shift` + `P`
- Zoek en selecteer `Run task`
- Selecteer `publish`

**Visual Studio**
- Open `Mastermind.sln`
- Bouw in Release modus.

## Project opzet
```
. ICT-VK-T-19-mastermind-backend
├── .github                           << Github gerelateerde bestanden, zoals workflows
├── .vscode                           << Bestanden die voor VSCode van toepassing zijn.
├── Images                            << Afbeeldingen
├── Mastermind                        << De source code van de applicatie
│   ├── Controllers                   << Controllers
│   ├── Models                        << Model bestanden
│   ├── Properties                    << Instellingen voor het draaien van de API.
│   ├── Services                      << Services die aangeroepen en gebruikt kunnen worden de API.
│   ├── appsettings.Development.json  << Settings voor development
|   └── appsettings.json              << De standaard settings.
|   └── Mastermind.csproj             << Het Mastermind project.
|   └── Mastermind.csproj.user        << Het Mastermind project met gebruikers instellingen
|   └── Program.cs                    << Het bestand waarvandaan alles begint.
|   └── Startup.cs                    << Startup file die wordt gebruikt in Program.cs
|   MastermindTest                    << Map met Mastermind tests
|   .gitignore                        << Bestanden en mappen die door git genegeerd moeten worden
|   Mastermind.sln                    << De Mastermind solution. Kan worden geopend met Visual Studio
|   README.md                         << ...
```