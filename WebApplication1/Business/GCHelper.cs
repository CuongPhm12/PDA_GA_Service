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
    public class GCHelper
    {
        public GCHelper()
        {
            SQLHelper.ConnectString(new PdaConfig());
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
        public string writeHistory(string model, string partNo, string refNo)
        {
            // Initialize the DynamicParameters object
            var parameters = new DynamicParameters();
            parameters.Add("@model", model, DbType.String, ParameterDirection.Input);
            parameters.Add("@partNo", partNo, DbType.String, ParameterDirection.Input);
            parameters.Add("@refNo", refNo, DbType.String, ParameterDirection.Input);
            parameters.Add("@pStatus", dbType: DbType.String, direction: ParameterDirection.Output, size: 12);

            using (SqlConnection sqlConnection = new SqlConnection(SQLHelper.CONNECTION_STRINGS))
            {
                sqlConnection.Open();

                // Execute the stored procedure
                sqlConnection.Execute("MI_Master_History_Insert", parameters, commandType: CommandType.StoredProcedure);

                // Retrieve the output parameter value
                return parameters.Get<string>("@pStatus");
            }
        }
        public DataTable PdaGetPartGC(string modelId, string partNo, string refNo)
        {
            return SQLHelper.ExecProcedureDataAsDataTable("PDA_GetPart", new { @model_id = modelId, @part_no = partNo, @ref_no= refNo });
        }
        public DataTable Get_PartNo_NotChecked(string modelId, string refNo)
        {
            return SQLHelper.ExecProcedureDataAsDataTable("Get_PartNo_NotChecked", new { @model_id = modelId, @ref_no = refNo });
        }
    }
  

}
