# mastermind-frontend
Dit is de frontend applicatie voor de Mastermind API (zie de map `backend`).

## Project setup
- Clone de repository
    ```
    git clone https://github.com/che-ict/ICT-VK-T-19-mastermind
    ```
- Navigeer naar de map `frontend`
- Draai `npm install` binnen de map `frontend`
- Draai `npm run serve`

### Uitvoeren van tests
Voor het uitvoeren van tests voer je uit `npm run tests`

## Productie
Voer `npm run build` uit om een productie distributie te maken. Gebruik hiervoor **node 16**. Schakelen tussen verschillende versies van npm en node kan eenvoudig gedaan worden met **nvm**.

## Project opzet
```
. ICT-VK-T-19-mastermind-frontend
├── docs                    << Gegenereerde documentatie
|
├── node_modules            << Map met modules die nodig zijn om de applicatie te draaien.
|                              Worden toegevoegd door `npm install`
├── public                  << Public items die tijdens het draaien van de applicatie benaderbaar zijn.
├── src                     << De source code van de applicatie
│   ├── assets              << Bestanden die nodig zijn voor de applicatie (css, img, etc.)
│   ├── components          << .vue component bestanden met daarin de code
│   |   └── __tests__       << Map met daarin tests voor specifieke componenten
│   ├── repositories        << JavaScript bestanden
│   ├── utils               << Functies die behulpzaam zijn binnen de applicatie
│   ├── App.vue             << Het Vue start bestand. Het bestand dat aangeroepen wordt
|   └── main.js             << Het bestand waarvandaan alles begint.
|   .gitignore              << Bestanden en mappen die door git genegeerd moeten worden
|   babel.config.js         << Configuratie voor babel
|   jest.config.js          << Configuratie voor jest
|   package-lock.json       << Gegenereerd bestand die er voor zorgt dat iedereen dezelfde modules heeft.
|                              Niet handmatig aanpassen!
|   package.json            << Informatie over deze packages
|   README.md               << ...
└── vue.config.js           << Configuratie voor vue
```