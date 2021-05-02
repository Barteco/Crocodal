# Crocodal

Crocodal is an experimental project aiming to create database access library for .NET Core that features:
* fully-functional code first O/RM (change tracking, lazy loading, migrations...)
* multiple database providers (SQLServer, PostgreSQL, ...)
* batching queries, inserts, updates and deletion
* code-first support for views, user defined functions and stored procedures, by translating C# code using Roslyn, including support for multiline statements, conditions, loops, temporary tables and more
* support for JSON, XML and spatial data
* support for primitive collections and complex types
* built-in support for mulitple programming patterns, like Specification
* built-in support for third-party libraries, like NodaTime, StronglyTypedId
* support for provider-specific features, like SQL Server Graph Database
* easy extensibility model
