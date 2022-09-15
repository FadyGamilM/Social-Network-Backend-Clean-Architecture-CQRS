# Social-Network-Backend-Clean-Architecture-CQRS
This project is a pure backend for social-media platform (suck as facebook), I decided to follow the clean architecture (hexagonal architecture) and CQRS pattern.

# Domain Layer Design Approach.
Actually I relied on 3 basic concepts from the DDD concepts which are:
* Domain Entities
  
      1- The domain entity is the object that is can be identified by its unique identifier.
      2- Two domain entities can be called equale if and only if their identifier (Id) is the same.

* Value Objects
  
      1- The Value object is just an object that represents a property of the domain entity itself.
      2- Two value objects can be called equale if and only if all the values of their properties are the same (value object can consists of more than one property).

* Aggregates
  
      1- The Aggregate is a collection of domain entities with value objects that are used to model a single concept in our domain buisness rule.
      
Simple example to illustrate these 3 important concepts:
* The business is an online bakery specialized in a pie product.
* the entity here is the pie.
* each entity consists of some ingrediants, so the ingrediant is a valie object, because there is no existance of the ingrediant without a pie.
* the use case is that we need to servce this pie with these specific ingrediants to 6-10 people not more.