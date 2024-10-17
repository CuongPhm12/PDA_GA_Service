using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PDAService.DAL;

namespace PDAService.Business
{
    public class GCHelper
    {
        public GCHelper()
        {
            SQLHelper.ConnectString(new PdaConfig());
        }
        public DataTable PdaGetPartGC(string modelId, string partNo)
        {
            return SQLHelper.ExecProcedureDataAsDataTable("PDA_GetPart", new { @model_id = modelId, @part_no = partNo });
        }
    }
}