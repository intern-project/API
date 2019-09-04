
using System.Data;
using System.Data.SqlClient;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

using System.Linq;
using System.Text;


public class LoginTypeRepository {
    private static string connectionString;
    public  LoginTypeRepository() {
        // connectionString = @"Server=192.168.43.233, 1433;Database=LOAN;User=SA;Password=Udara@123;ConnectRetryCount=0;MultipleActiveResultSets=true";
        // connectionString = @"Server=localhost;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";
        connectionString = @"Server=localhost, 1433;Database=LOAN;User=SA;Password=Udara@123;ConnectRetryCount=0;MultipleActiveResultSets=true";
    }

    public static IDbConnection Connection {
        get {
            return new SqlConnection(connectionString);
        }
    }
    // add to db

    public  IEmployee login(IUser user){

        var email = user.email;
        var @email1 =user.email;
        Console.WriteLine(email);
        IEnumerable<IEmployee> employeesFromDB = null;

        using (IDbConnection dbConnection = Connection) {
            dbConnection.Open ();
            //query
            //  string query = "select * from Employee where email='"+email+"'";
             string query = "dbo.Login";

            
            employeesFromDB=dbConnection.Query<IEmployee>(query,new {email= email}, commandType: CommandType.StoredProcedure);
        }

         //get the first instance of collection
            IEmployee EmployeeFromDB = employeesFromDB.FirstOrDefault();

            var userEmailFromDB = EmployeeFromDB.email;

            

            //checking existance of employee
            if (userEmailFromDB!= null)
            {
                return EmployeeFromDB;
            }
            else
            {

                return null;

            }
    }


    public IEnumerable<IEmployee> getA(){
         using (IDbConnection dbConnection = Connection) {
            dbConnection.Open ();
            //query
            string query = "select * from Employee";
            return dbConnection.Query<IEmployee>(query);
        }

    }


   
                                }