@echo off
set /p migration_name=Enter Migration Name: 

@echo on
dotnet ef migrations add %migration_name% --startup-project src/Backend/FullStackShop.API --project src/Backend/FullStackShop.EF --context ApplicationDbContext
