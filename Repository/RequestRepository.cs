using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

public class RequestRepository {
    private static string connectionString;
    public  RequestRepository() {
        connectionString = @"Server=192.168.8.101, 1433;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";
        // connectionString = @"Server=localhost;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";
    }

    public static IDbConnection Connection {
        get {
            return new SqlConnection(connectionString);
        }
    }

    public static  void Add(Request request){
        using  (IDbConnection dbConnection = Connection){
             string sQuary = "INSERT INTO REQUESTS (rid,name,age,address,contact,job,ammount,duration,reason,pending,accepted,declined,nic,doc)"
                            + "VALUES(@rid, @name, @age, @address, @contact, @job, @ammount, @duration, @reason, @pending, @accepted, @declined, @nic, @doc)";
            dbConnection.Open();
            dbConnection.Execute(sQuary, request);
        }
    }

    public  IEnumerable<Request> GetAll() {
        using (IDbConnection dbConnection = Connection){
            dbConnection.Open();
            return dbConnection.Query<Request>("SELECT * FROM REQUESTS");
        }
    }

    // public Request GetByID( string nic ) {
    //     using (IDbConnection dbConnection = Connection){
    //         string sQuary = "SELECT * FROM REQUESTS"
    //                         + "WHERE nic = @nic";
    //         dbConnection.Open();
    //         return dbConnection.Query<Request>(sQuary, new{nic = nic}).FirstOrDefault();
    //     }
    // }

    public static void Update(Request request){
        using (IDbConnection dbConnection = Connection){
            string sQuary = "UPDATE REQUESTS SET name = @name, address = @address,reason = @reason,"
                            + "pending = @pending,accepted = @accepted, declined = @declined"
                            + "WHERE rid = @rid";
            dbConnection.Open();
            dbConnection.Query(sQuary, request);
        }
    }
}