using System;
using System.Collections.Generic;
using System.Data.SqlClient;

/*
 Designing a inherited database connection classes
*/
namespace MoshHamedani_C__imtermediate
{
    // ABSTRACT classes cannot be instantiated by DbConnection()
    // and can ONLY be used as base classes for other classes.
    public abstract class DbConnection
    {   // must be marked as ABSTRACT coz contains abstract METHODS.
        public TimeSpan Timeout{ get; set; }
        public string ConnectionString { get; set; }

        public DbConnection(string connectionString, int timeout = 10)
        {
            this.Timeout = TimeSpan.FromSeconds(timeout);

            if ( string.IsNullOrWhiteSpace(connectionString) )
                throw new ArgumentException("invalid connection string");
            this.ConnectionString = connectionString;
        }

        // abstract methods doesn’t have a body.
        public abstract void Open();
        public abstract void Close();
    }

    /* In a derived class, ALL abstract members of the BASE class,
     * need to be overrided, otherwise that derived class to be ABSTRACT too */
    public class MsSqlConnection : DbConnection
    {
        /* reasons to keep the individual constructor:
        * base class DbConnection doesn't have parameterless constructor DbConnection();
        * cannot directly instantiate MsSqlConnection with timeout and connectionString parameters;
        * to add custom initialization logic specific to MsSqlConnection in the future.
        */
        public MsSqlConnection(string connectionString, int timeout) : base(connectionString, timeout)
        { /* just empty constructor */ }

        public override void Open() { Console.WriteLine($"Opening MSSQL connection via: {ConnectionString}"); }
        public override void Close() { Console.WriteLine("Closing MSSQL Server connect"); }
    }

    public class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString, int timeout) : base(connectionString, timeout)
        { /* just empty constructor */ }

        public override void Open() { Console.WriteLine($"Opening Oracle DB via: {ConnectionString}"); }
        public override void Close() { Console.WriteLine("Closing Oracle db connect"); }
    }

    public class DbConnection_Program
    {
        public static void Run()
        {
            var mssql = new MsSqlConnection("server = MSSQL_Server; database = myDB1;", 10);
            Console.WriteLine("\n"); mssql.Open(); mssql.Close(); Console.WriteLine("\n");

            var oracle = new OracleConnection("server = Oracle_db; database = myDB2;", 10);
            try
                { oracle.Open(); }
            catch (SqlException ex)       // Log the exception
                { Console.WriteLine($"SQL Error: {ex.Message}"); }
            catch (TimeoutException ex)  // Log the exception
                { Console.WriteLine($"Connection timed out: {ex.Message}"); }
            finally
                { oracle.Close(); }

        }
    }

    public class DbCommand { 
        private DbConnection _connection;
        private readonly string _sqlStatement;

        // constructor caters for NULL reference or an EMPTY string
        public DbCommand( DbConnection connection, string sqlStatement )
        {
            if (connection == null)
                throw new InvalidOperationException("database isn't initialized");
            _connection = connection;

            if (string.IsNullOrWhiteSpace(sqlStatement))
                throw new ArgumentException("invalid connection string");
            _sqlStatement = sqlStatement;
        }

        public void Execute()
        {
            _connection.Open();
            Console.WriteLine($"Executing SQL statement: {_sqlStatement}");
            _connection.Close();
        }
    }

    public class DbCommand_Program
    {
        public static void Run()
        {
            try {
                var mssql = new MsSqlConnection("server = MSSQL_Server; database = myDB1;", 10);
                //Console.WriteLine("");
                var dbCommand1 = new DbCommand(mssql, "SELECT * FROM Users");
                Console.WriteLine("\n"); dbCommand1.Execute(); Console.WriteLine("\n"); 

                var oracle = new OracleConnection("server = Oracle_db; database = myDB2;", 10);
                var dbCommand2 = new DbCommand(oracle, "SELECT * FROM Users");
                dbCommand2.Execute();
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }


}
