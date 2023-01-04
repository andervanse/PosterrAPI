
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

On the project's root folder: 

### Run Application

```docker-compose build```

```docker-compose up```


### Run Tests

  ```docker-compose -f .\docker-compose-test.yml build```

  ```docker-compose -f .\docker-compose-test.yml up```


### Prerequisites
* [Docker and Docker compose](https://docs.docker.com/compose/)

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)



## Planning

### Questions for the Product Manager
On this new reply-to-post, is ok to assume that the same post validations are applied?
The @ mentioning must be persisted for future use?
What happens if the @ mentioning is not at the beginning of the Post?
Those replies are private between the owner of the post and the user who wrote the reply?

To solve this problem I would add a new field in the Posts table to indicate that this is a 'reply-to-post' in the database.
in the domain I'd add a property called IsReplyToPos in the Post class and filter these kinds of posts in a specific method in the post repository.



## Critique

I'd like to implement more unit tests, two for each requisite, considering a happy path and a wrong one.
On the API I'd like to version the API and use attributes to describe each endpoint, I'd like to separate all the configuration in the Program.cs to a specific group of classes in a folder called 'config', making use of extension methods.

When it comes to scaling, I would put a load balancer in front to the application and have some applications instances behind it.
Another thing is make use of CQRS pattern, and separate reads and writes being made to the database, creating two databases, one to writes and one (possibly NoSql) to the reads.
Yet another alternative would be separate the most important queries in microservices to scale, making using of containerization.