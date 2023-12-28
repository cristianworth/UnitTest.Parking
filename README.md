# Dependencies
* .Net version 5
* xUnit testing tool

# References
* Github inspiration project can be found [here](https://github.com/alura-cursos/alura.estacionamento/tree/aula01)
* Alura inspiration course can be found [here](https://cursos.alura.com.br/course/testes-net-teste-software)

## CLI commands
CLI to create a unit tests:
```
dotnet new xunit -o ProjetoTeste.Tests
```
CLI to reference the unit tests to the main project:
```
dotnet add ./ProjetoTeste.Tests/ProjetoTeste.Tests.csproj reference ./ProjetoAlvoTeste/ProjetoAlvoTeste.csproj
```
CLI to run the tests (text version for the Test Explorer):
```
dotnet test
```
