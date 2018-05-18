# HaloGuns REST API 

A REST API built using C# & Visual Studio .Net WEBAPI. 

For storing information about Halo (videogame franchise) guns.  

## Tooling 
* MySQLi 
* .Net WEBAPI 
* Visual Studio IDE 
* C# 

# Setup & use 
* git clone https://github.com/BH0/HaloGunsRestAPI.git 
* cd HaloGunsRestAPI 
* Make sure you have an instance of MySQL running 
* Edit Private_template.cs and type in your password 
* Change Private_template.cs filename to Private.cs 
* Make a database called "haloguns" 
* Create the guns-table called "tblGuns" 
  * CREATE TABLE tblGuns (ID INT, name VARCHAR(20), faction VARCHAR(20), race VARCHAR(20), type VARCHAR(20), technology VARCHAR(20), PRIMARY KEY(ID));   
* Start IIS [server] 

  
