# fun-status-backend

This projects it's the backend for a status project for my resell hosting company. It's developed in a modular structure that helped to use libs in other projects for future if there are required.

Project structure:
| Project | Description |
| :---: | :---: |
| Domain | Connection with database, define models for each column and auto migration based on model structure | 
| Encryption | Algorithm that encrypt and decrypt every data base on a configured given string |
| JWTAuth | Implementation of JWT since .Net Core 3 didn't provide a strong implementation of this concept |
| Provider | Implementation of database methods in a secure way with Repository pattern |
| Fun-Status | Core for REST API and project startup |
