<h1>Web API Onion - .NET 6</h1>

I Develop an onion architecture in a .NET 6 WebAPI, seeking to achieve a clean implementation following good practices.
This architecture includes the following layer architecture.

I included a validation of the communication pipeline to apply logical rules that allow me to validate the information in the request before reaching the controller.
For this, I create a custom middleware and FluentValidation to apply logical rules to the commands.

It is a pattern that allows to separate read and write operations. This pattern helps the scalability, security, and maintainability of the architecture. Because it separates queries from commands into different models, allowing, for example, validation rules to be applied to commands that would not be necessary for queries.

The Query operations return DTOs with only the necessary information to avoid exposing the Domain entities to the outside. This is a good practice that provides security and improves the sending of information since it includes only what is necessary.
The mapping between domain entities and DTOs is done with AutoMapper.

In this case, as I was starting from an existing database with structure and data loaded, I decided to use the Database First approach.

Looking at the AdventureWorks database schema, I saw that it has the audit fields (rowguid and ModifiedDate).
Therefore, I override the SaveChangesAsync method so that I can load them on every add or change.

I included this pattern to handle all communication with the database through a generic repository.
In particular, I use the Nuget Ardalis Specification.

I included the implementation of the MediatR pattern, which is a coordinator in charge of communication between layers. In this case, I use it for calls from the API to the Application.I Develop an onion architecture in a .NET 6 WebAPI, seeking to achieve a clean implementation following good practices.
This architecture includes the following layer architecture.

I included a validation of the communication pipeline to apply logical rules that allow me to validate the information in the request before reaching the controller.
For this, I create a custom middleware and FluentValidation to apply logical rules to the commands.

It is a pattern that allows to separate read and write operations. This pattern helps the scalability, security, and maintainability of the architecture. Because it separates queries from commands into different models, allowing, for example, validation rules to be applied to commands that would not be necessary for queries.

The Query operations return DTOs with only the necessary information to avoid exposing the Domain entities to the outside. This is a good practice that provides security and improves the sending of information since it includes only what is necessary.
The mapping between domain entities and DTOs is done with AutoMapper.

In this case, as I was starting from an existing database with structure and data loaded, I decided to use the Database First approach.

Looking at the AdventureWorks database schema, I saw that it has the audit fields (rowguid and ModifiedDate).
Therefore, I override the SaveChangesAsync method so that I can load them on every add or change.

I included this pattern to handle all communication with the database through a generic repository.
In particular, I use the Nuget Ardalis Specification.

I included the implementation of the MediatR pattern, which is a coordinator in charge of communication between layers. In this case, I use it for calls from the API to the Application.

<h2>Adventure Work Database</h2>

https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2019.bak

