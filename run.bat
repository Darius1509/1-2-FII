@echo off
echo Starting backend...
start cmd /k "cd /d BE\1-2-FII && dotnet build && dotnet run --project 12FIIAPI"

echo Starting frontend...
start cmd /k "cd /d FE\OneTwoFiiFront && npm run dev"