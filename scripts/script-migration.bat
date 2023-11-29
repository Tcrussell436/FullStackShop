@echo off
set /p initial=Start Migration: 
set /p end=End Migration: 
set /p output=Output file name: 


@echo on
dotnet ef migrations script %initial% %end% --project src/Backend/FullStackShop.EF --startup-project src/Backend/FullStackShop.API -o src/Backend/FullStackShop.EF/Migrations/SQL/%output%.sql