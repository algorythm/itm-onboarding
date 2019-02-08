# Intro Project - Anders

Simple todo application.

## Setup development environment

To set up the database, make sure to have docker installed on your computer. Then run the following command:

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=mySecurePassword' -p 1433:1433 --name msdb -d microsoft/mssql-server-linux:2017-CU8
```

Then cd into the `src/` directory and run:

```bash
npm i
dotnet restore
```
