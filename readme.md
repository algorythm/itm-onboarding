# Intro Project - Anders

Simple todo application.

## Setup development environment

To set up the database, make sure to have docker installed on your computer. Then run the following command:

```bash
docker run \
   -e 'ACCEPT_EULA=Y' \
   -e 'MSSQL_SA_PASSWORD=mySecur3!Password' \
   -p 1433:1433 \
   --name msdb \
   -d microsoft/mssql-server-linux:2017-latest
```

Then cd into the `src/` directory and run:

```bash
npm i
dotnet restore
dotnet ef database update
```
