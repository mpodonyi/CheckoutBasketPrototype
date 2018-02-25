# CheckoutBasketPrototype

Implementation Notes:

Part 1:

* Authentication and Authorization are out of scope
* Logging not Implemented
* Unit and Integration Testing are just rudimentary to show that I know how it works and how it should be done
* Logging should be moved to GlobalAttribute in WebApi because cross-cutting concern
* No UnitOfWork Pattern but Registry which also commits value
* Validation should move in own Service and Factored out similar to Mapping Service
* It is assumed that a User with a Guid exists already
* At initial Basket needs to be generated for the User before the Basket can be filled with BasketItems
* Mark "Checkout.Com.BasketPrototype.ApiGateway" as StartUp Project and hit "F5"
* The Service returns 500 for all Errors; this should be changed to respond Better To User Caused Errors an give more Feedback to User
* Swagger UI available under http://localhost:62196/swagger
* More XML documentation needed for ServiceLayer

Part 2

* ClientLib generated from Swagger file
* ClientLib should target NetStandard to allow broad range of Users to integrate with

P.S.: There is room for improvement and there will be bugs :-)
