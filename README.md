Tools:
EntityFramework,
Automapper,
FluentValidation,
Mediatr,
swagger

Urls:
https://localhost:44357/swagger/index.html,
https://localhost:44357/api/customer,
https://localhost:44357/api/product,
https://localhost:44357/api/Order,

Coding styles and Assumptions:
I implemented fluent Validation Pipeline behavior for validating the various requests DTOS,
I used a middleware to handle any other exception that happens in the application using a custom exception class,
I implemented the repository and unit of work pattern for persistence,
I implemented DDD strictly using Value Objects for Price to ensure Immutablity,
I implemented DDD by ensuring all domain logics were done in the domain,
I added unit tests for the various handlers also using NUnit,
I implemented Integration tests also,
I implemented command and query segregation using CQRS,

Nice to haves:
We can extend the application by usinfg prometheus for monitoring and checks,
we can still add more unit tests and integration tests also,
we can add an architectural tests to ensure ddd compliance,
