# Graph Visualization and Import

## Installation
To be able to use this application, you need to clone the repository. To open the application you need

1. Visual Studio 2015 (Because of C# 6.0 constructs)
2. SQL Server


### Database Installation
The project contains a folder *GraphViz.Database* whci includes the script and .dacpac file for database. 
You just need to create an empty database in SQL Server and run the script to create tables and indexes. Don't forget to change the connection string section in the *app.config* and *web.config* for console and web aplications.

### Configuration
You can configure th console app in *app.config*. It can be done by

* GraphServiceUrl: specify the service url for posting the extracted graph data
* ImportFolder: specify the location that application is looking for xml files to import 

## Execution
To execute the application web application needs to be started first and then start the console.

## Extension Points

1. Distance Calculation: It can be done by tree traverse search algorithm. It can be calculated on the fly and cache on demand or calculate all up front whcih make the searc extreemly faster. (I could finish the search in that time)
2. Moving the extraction part to web api service rather than the console application.



