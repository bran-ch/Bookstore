# BookstoreAPI

BookstoreAPI is a C# API for storing Books and Authors.

## Getting Started

### VS Code Dev Container

A VS Code Dev Container is provided to get the project started quickly. The container is configured using `debian:stretch-slim` as a base and installs the basic dependencies for .NET Core 3.1 and additional tools such as Python and the Azure CLI


### Without the container

#### Prerequisites

.NET Core 3.1

```bash
dotnet restore

# Run the API on port 5000
dotnet run --project BookstoreApi/BookstoreApi.csproj

# Run the Unit Tests
dotnet test
```

## Usage

### Postman Collection
A Postman Collection is provided that includes basic CRUD operations for the `/books` and `/authors` endpoints

### Endpoints

Route                       | Description
--------------------------- | ----------------------------------
`GET /authors`              | Gets all Authors
`GET /authors/{authorId}`   | Get a single author by id
`POST /authors`             | Create an author
`PUT /authors/{authorId}`   | Updates an author by id
`DELETE /authors/{authorId}`| Deletes an author by id
`GET /books`                | Gets all books
`GET /books/{bookId}`       | Get a single book by id
`POST /books`               | Create a book. Note that this also creates the Author
`PUT /books/{bookId}`       | Updates a book by id
`DELETE /books/{bookId}`    | Deletes a book by id

See the generated Swagger for more details on the request bodies and response models
<Base Url>/swagger/index.html