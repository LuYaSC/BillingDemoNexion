<br />
  <h3 align="center">Demo Bills Backend for Nexion Demo</h3>
</div>


### Built With

You can use the application to create users, currencies, states, services and invoices, you can also create invoices in bulk and pay them

Development with (.Net 5)

* [.NET](https://dotnet.microsoft.com/)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->

### Prerequisites

1. Donwload the last version for dotnet in 
   ```sh
   https://dotnet.microsoft.com/
   ```
1. Donwload Visual Studio 2022 in 
   ```sh
   https://visualstudio.microsoft.com/es/launch/
   ```
1. Donwload Visual Studio Code in 
   ```sh
   https://code.visualstudio.com/
   ```

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/LuYaSC/BillingDemoNexion
   ```

2. Create Docker Container for SQL (Optional), change [Port] for port want to use, with example (Recomended use: 1436 or 1437)
    ```sh
    docker run -d --name develop-sql -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password$" -p [port]:1433 -d mcr.microsoft.com/mssql/server:2019-latest
    ```

3. Change file appsettings.json Local Database if you use Local Database use commented line, only change DataSource 

4. Migrations in VisualStudio
    ```sh
    update-database -Context DBContext
    ```
4. Migrations in VsCode
    ```sh
    dotnet ef database update --context DBContext
    ```
5. Execute script: BDBills.sql    

/**Optional**/
If you have problems with migrations  (Only for problemas with migrations docker or local)
Execute BDBills Complete Script.sql

6. Execute 
    ```sh
    dotnet run
    ```
this command start the services on port 5000 or 5001, also can use https://localhost:5001/swagger/index.html

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- USAGE EXAMPLES -->
## Unit Test

Execute unit test for all logic business

1. User the command
   ```sh
      dotnet test
   ```
2. Test Methods (Postman)
You can import the requests to the postman with the file "Peticions BillAPI.json", you will find the query methods for pending and paid invoices (historical)
the method to make the payment of an invoice

3. you can change the name of url methos for (get, create, update, delete) parameters, the options can use this:  https://localhost:5001/api/[options]/Get
      1. Users
      2. States
      3. Currencies
      4. Services

Note. You can also use the swagger found in the path https://[service]/swagger/index.html

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Luis Jose Jimenez Peña - [@LuYaSc](https://twitter.com/LuYaSc) - luisjimpe93@gmail.com

Project Link: [https://github.com/LuYaSC/ChipaxChallenge](https://github.com/LuYaSC/ChipaxChallenge)

<p align="right">(<a href="#top">back to top</a>)</p>
