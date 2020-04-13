# PeopleManagement

* Implemented a solution using Docker orchestrator support for Visual Studio, this is the best way to setup a local database instance for the purpose
* Used latest MS SQL Server
* The application uses Blazor which is a relatively new tech to build responsive web apps
* The database is created by EF Core at runtime and queries written using fluent LINQ statements
* Implemented the Search and Add functions
* Run the application in Visual Studio debug mode with the Docker Composer runner
* Due to time contraints, there is not sufficient level of testing to make this production ready, however I would suggest adding:
  * a level of Unit Tests on the Blazor components (see guidelines from Steve Sanderson https://blog.stevensanderson.com/2019/08/29/blazor-unit-testing-prototype/)
  * a level of Integration Tests using the Docker compose orchestration to setup the database and test the integration with the service layer (essentially the EF queries)
* Regarding future functionalities, I would probably add the ability to
  * add/edit groups
  * edit people
  * perhaps consolidate search and add functionalities in a single page 