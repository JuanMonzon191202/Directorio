# Directorio
Instalación de dotnet entity en VSC
Dotnet new webapi -o NOMBREPROYECTO
dotnet add package microsoft.entityframeworkcore.sqlserver
dotnet add package microsoft.entityframeworkcore.Design
dotnet tool install --global dotnet-ef

CodeFirst

para ejecutar el proyecto
dotnet run


-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_


                                          DataBaseFirst
-dotnet ef dbcontext scaffold
"Server=localhost\SQLEXPRESS;Database=DBDirectorio;Trusted_connection=true;Encrypt=False"
Microsoft.EntityFrameworkCore.SqlServer --context-dir .\Data --output-dir .\Data\CitasApiModels-




-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_
