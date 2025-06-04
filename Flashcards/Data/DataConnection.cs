using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Flashcards.Data;

public class DataConnection
{
    private IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    private static string ConnectionString;

    public DataConnection()
    {
        ConnectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];
    }

    internal void CreateDatabase()
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            var createStackTable = @"
                        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Stacks')
                        CREATE TABLE Stacks (
                        Id int IDENTITY(1,1) NOT NULL,
                        Name NVARCHAR(10) NOT NULL UNIQUE,
                        PRIMARY KEY (Id)
                    );";

            connection.Execute(createStackTable);

            var createFlashcardTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Flashcards')
                    CREATE TABLE Flashcards (
                        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        Question NVARCHAR(30) NOT NULL,
                        Answer NVARCHAR(30) NOT NULL,
                        StackId int NOT NULL 
                            FOREIGN KEY 
                            REFERENCES Stacks(Id) 
                            ON DELETE CASCADE 
                            ON UPDATE CASCADE
                    );";

            connection.Execute(createFlashcardTable);
        }
    }
}