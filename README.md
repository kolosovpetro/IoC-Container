# IoC Container

## Description

Simple IoC Container. This container consists of the following layers:

- Builder: abstraction over container, builds container, registers types and returns concrete container.
- Container: has a methods in order to register types and returns concrete instance, which implements TConctract
- Service: entity with type properties, concrete implementation of TContract, and enum property lifetime

## To Do

- Implement following responsibilities: 
  - Builder -- builds container, 
  - Container -- registers type and gives an instance from service
  - Service -- contains instance, lifetime, types.
- ~~Create abstraction layer to reduce cast~~ (done)
- Create and throw custom exceptions:
  - InvalidTypeException: 
    - ~~to be thrown when TImplementation doesn't implement TContract~~ (done)
  - TypeAlreadyRegisteredException: 
    - ~~to be thrown when user try to add TConctract which is already registered~~ (done)
  - TypeNotFoundException: 
    - ~~to be thrown if TConctract is not registered in container~~ (done)
- ~~Perform tests for singleton and transient objects~~ (done)
- ~~Implement logic such that will provide always new instance in Transient, and to keep instance in case if Singleton~~ (done)
- ~~Unite all logics under one dictionary <TContract, IService>~~ (done)