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
        // connectionString = @"Server=192.168.8.101, 1433;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";
        // connectionString = @"Server=localhost;Database=LOAN;User=SA;Password=Ride2die;ConnectRetryCount=0;MultipleActiveResultSets=true";
        connectionString = @"Server=localhost, 1433;Database=LOAN;User=SA;Password=Udara@123;ConnectRetryCount=0;MultipleActiveResultSets=true";


    }

    public static IDbConnection Connection {
        get {
            return new SqlConnection(connectionString);
        }
    }
    // add to db
    public static  void Add(LoanType loanType){
        using  (IDbConnection dbConnection = Connection){
             string quary = "dbo.AddLoanType";
            dbConnection.Open();
            dbConnection.Query<LoanType>(quary, loanType, commandType: CommandType.StoredProcedure);
        }
    }
    // get all from db
    public static IEnumerable<LoanType> GetAll() {
        using (IDbConnection dbConnection = Connection){
             string quary = "dbo.SelectAllLoanTypes";
            dbConnection.Open();
            return dbConnection.Query<LoanType>(quary, commandType: CommandType.StoredProcedure);
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
    public static void Update( LoanType loanType){
        using (IDbConnection dbConnection = Connection){
            var newRate = loanType.rate;
            var id = loanType.id;
            string quary = "dbo.UpdateLoanType";
            dbConnection.Open();
            dbConnection.Query<LoanType>(quary, loanType, commandType: CommandType.StoredProcedure);
        }
    }
    // delete loan type
    public static void Delete(int id) {
        using (IDbConnection dbConnection = Connection) {
            string quary = "dbo.DeleteLoanType";
            dbConnection.Open();
            dbConnection.Query<LoanType>(quary, new{id = id}, commandType: CommandType.StoredProcedure);
        }
    }
}