
#### _Anderson Davanse_

## Posterr API
Posterr API is a implementation of the Strider's back-end challenge. 


## About
PosterrAPI organization was created to have a simple but flexible structure, taking some concepts from DDD, it's possible to expand to others patterns conform necessity.


## Structure organization
 - ### API
 > Where endpoints are exposed
 - ### Application
 > Where all the pumbling code are, it's where business rules encounters non-functional requirements.
 - ### Domain
 > Isolated entities containing business rules and contracts on how to retrieve and persist them.
 - ### Data
 > Persistent layer, it implements the contracts established in the Domain layer, one project peer specific persistence technology.

## Getting Started

On the project's root folder, run: 

```docker compose build```

```docker compose up```


### Prerequisites
* <a href="https://docs.docker.com/compose/" target="_blank">Docker and Docker compose</a>

* <a href="https://visualstudio.microsoft.com/downloads/" target="_blank">Visual Studio 2022</a>