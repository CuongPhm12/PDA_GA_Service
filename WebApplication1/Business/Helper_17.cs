using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using PDAService.DAL;

namespace PDAService.Business
{
    public class Helper_17
    {
        public Helper_17()
        {
            SQLHelper_17.ConnectString(new PdaConfig());
        }
        //public string writeHistory(string model, string partNo, string refNo)
        //{
        //    var parameters = new
        //    {
        //        model = model,
        //        partNo = partNo,
        //        refNo = refNo,
        //        pStatus = string.Empty
        //    };
        //    string result = SQLHelper.ExecProcedureDataFistOrDefault<string>("MI_Master_History_Insert", parameters);
        //    return parameters.pStatus;
        //}
        public (string Status, string Results)DeleteItemReplaceVerify(string wo, string machine, string slot, string upn)
        {
            // Initialize the DynamicParameters object
            var parameters = new DynamicParameters();
            parameters.Add("@WO", wo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Machine", machine, DbType.String, ParameterDirection.Input);
            parameters.Add("@slot", slot, DbType.String, ParameterDirection.Input);
            parameters.Add("@UPN", upn, DbType.String, ParameterDirection.Input);
            parameters.Add("@pStatus", dbType: DbType.String, direction: ParameterDirection.Output, size: 2);
            parameters.Add("@pResults", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

            using (SqlConnection sqlConnection = new SqlConnection(SQLHelper_17.CONNECTION_STRINGS))
            {
                sqlConnection.Open();

                // Execute the stored procedure
                sqlConnection.Execute("DELETE_ITEM_REPLACE_VERIFY_1", parameters, commandType: CommandType.StoredProcedure);

                string status = parameters.Get<string>("@pStatus");
                string result = parameters.Get<string>("@pResults");
                // Retrieve the output parameter value
                return (status, result);
            }
        }
        public DataTable GetReload(string wo)
        {
            return SQLHelper_17.ExecProcedureDataAsDataTable("DX_GetReload", new { @wo = wo});
        }
        public DataTable Get_TotalByMachine(string wo, string machine_id)
        {
            return SQLHelper_17.ExecProcedureDataAsDataTable("DX_TotalByMachine_1", new { @wo = wo, @machine_id = machine_id });
        }
    }
  

}
