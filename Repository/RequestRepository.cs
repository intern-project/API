using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections;

public class RequestRepository {
    private string connectionString;
    public RequestRepository() {
        connectionString = @"Server=localhost;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";
    }

    public IDbConnection Connection {
        get {
            return new SqlConnection(connectionString);
        }
    }

    public void Add(Request request){
        using (IDbConnection dbConnection = Connection){
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

    // public void Update(Request request){
    //     using (IDbConnection dbConnection = Connection){
    //         string sQuary = "UPDATE REQUESTS SET name = @name, address = @address,reason = @reason,"
    //                         + "pending = @pending,accepted = @accepted, declined = @declined"
    //                         + "WHERE rid = @rid";
    //         dbConnection.Open();
    //         dbConnection.Query(sQuary, request);
    //     }
    // }
}