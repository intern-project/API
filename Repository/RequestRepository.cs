using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using API.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;

public class RequestRepository {
    private static string connectionString;
    public RequestRepository () {
        connectionString = @"Server=192.168.43.233, 1433;Database=LOAN;User=SA;Password=Udara@123;ConnectRetryCount=0;MultipleActiveResultSets=true";
        // connectionString = @"Server=192.168.8.103, 1433;Database=LOAN;User=SA;Password=Udara@123;ConnectRetryCount=0;MultipleActiveResultSets=true";
        // connectionString = @"Server=localhost;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";
        //connectionString = @"Server=localhost;Database=LOAN;User=SA;Password=Udara@123;ConnectRetryCount=0;MultipleActiveResultSets=true";

    }

    public static IDbConnection Connection {
        get {
            return new SqlConnection (connectionString);
        }
    }
    //Add a Loan Request
    public static void Add (Request request) {
        using (IDbConnection dbConnection = Connection) {
            dbConnection.Open ();
            dbConnection.Query<Request> ("dbo.MakeLoanRequest",
                request,
                commandType : CommandType.StoredProcedure);
        }
    }
    //Get All Loan Requests
    public IEnumerable<Request> GetAll () {
        using (IDbConnection dbConnection = Connection) {
            dbConnection.Open ();
            return dbConnection.Query<Request> ("dbo.SelectLoanRequests", commandType : CommandType.StoredProcedure);
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

    // Update request for accept or decline Loan without SP
    public static void Update(Request request){
        using (IDbConnection dbConnection = Connection){
            var reason = request.reason;
            var pending = request.pending;
            var accepted = request.accepted;
            var declined = request.declined;
            var rid = request.rid;

            string sQuary = "UPDATE MakeRequest SET " + "pending = "+ pending +"," + "accepted =" + accepted + ","+ "declined =" + declined+ " WHERE rid =" + rid;
            dbConnection.Open();
            dbConnection.Query<Request>(sQuary, request);
        }
    }

    // Update request for accept or decline Loan with SP

    // public static void Update (Request request) {
    //     using (IDbConnection dbConnection = Connection) {
    //         dbConnection.Open ();
    //         dbConnection.Query("dbo.EditRequest",
    //             request,
    //             commandType : System.Data.CommandType.StoredProcedure);
    //     }
    // }
}