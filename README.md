
# TTDL API

Teckel Teun's Data Lab API
###
Dit project bevat de code en dockerfiles om de TTDL API te runnen, het bevat CRUD operaties voor stoelen, metingen, patienten
en gebruikers. Daarnaast start de docker-compose file ook een postgres database voor het opslaan en testen van de database.


## Gebruikt door

Dit project wordt gebruikt door de volgende projecten:

- TTDL Frontend (https://github.com/hesitantronin/TTDL-web-app)
- TTDL Embedded (https://github.com/hesitantronin/TTDL-Embedded)

En gemaakt voor Ortho Innovatief (https://www.ortho-innovatief.nl/)

# Gebruikte technologieën

[Swagger](https://swagger.io/tools/swaggerhub/?utm_source=aw&utm_medium=ppcg&utm_campaign=SEM_SwaggerHub_PR_EMEA_ENG_EXT_Prospecting&utm_term=swagger&utm_content=511173019641&gad_source=1&gclid=CjwKCAjwg8qzBhAoEiwAWagLrM--Mz_eYMjYYezwviw4LNP8rEqhHGUkojUOPZAJHWYVuAvwW0p9VBoCEA8QAvD_BwE&gclsrc=aw.ds) - Automatische documentatie, te vinden op http://localhost:28080/swagger/index.html wanneer de docker environment runt of op http://localhost:8080 wanneer je de API lokaal runt.

[Postgres](https://www.postgresql.org/) - Database 

[Pgadmin](https://www.pgadmin.org/) - GUI voor de postgres database



# Docker

Builden en runnen van je applicatie

```bash
docker-compose up --build
```

De API is nu beschikbaar op http://localhost:28080
De postgres database is nu beschikbaar op http://localhost:25432
De pgadmin GUI is nu beschikbaar op http://localhost:20080




## Lokaal runnen
Clone het project

```bash
  git clone https://github.com/hesitantronin/TTDL-Backend.git
```

Ga naar de project folder

```bash
  cd TTDL-Backend
```

installeer dependencies

```bash
  dotnet restore
```

run het project

```bash
  dotnet run
```

De applicatie zal nu runnen op het address localhost:8080





## Running Tests

Om de unittests te runnen volg je de volgende commands

Naar test directory vanaf parent

```bash
  cd TTDL.Backend.Tests
```

Run test
```bash
  dotnet test
```


## Wat zou er toegevoegd kunnen worden in toekomstige iteraties

- Security - (cookies, authenticatie voor webpagina's)
- Repositories - Scheidt de database operaties van de services (enkel geïmplementeerd bij de chairController)
- Betere mockdata seedings
- Uitgebreidere unittests

