using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

public class LoanTypeRepository {
    private static string connectionString;
    public  LoanTypeRepository() {
        connectionString = @"Server=192.168.8.101, 1433;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";
        // connectionString = @"Server=localhost;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";

    }

    public static IDbConnection Connection {
        get {
            return new SqlConnection(connectionString);
        }
    }
    // add to db
    public static  void Add(LoanType loanType){
        using  (IDbConnection dbConnection = Connection){
             string quary = "INSERT INTO LoanTypeTabel (id, label, rate)"
                            + "VALUES(@id, @label, @rate)";
            dbConnection.Open();
            dbConnection.Execute(quary, loanType);
        }
    }
    // get from db
    public static IEnumerable<LoanType> GetAll() {
        using (IDbConnection dbConnection = Connection){
            dbConnection.Open();
            return dbConnection.Query<LoanType>("SELECT * FROM LoanTypeTabel");
        }
    }
    // get loan type by id
    // public LoanType GetByID( string id ) {
    //     using (IDbConnection dbConnection = Connection){
    //         string quary = "SELECT * FROM LoanTypeTabel"
    //                         + "WHERE id = @Id";
    //         dbConnection.Open();
    //         return dbConnection.Query<LoanType>(quary, new{id = id}).FirstOrDefault();
    //     }
    // }


    // update loan type
    public static void Update(LoanType loanType){
        using (IDbConnection dbConnection = Connection){
            string quary = "UPDATE LoanTypeTabel SET rate = @rate"
                            + "WHERE id = @id";
            dbConnection.Open();
            dbConnection.Query(quary, loanType);
        }
    }
}