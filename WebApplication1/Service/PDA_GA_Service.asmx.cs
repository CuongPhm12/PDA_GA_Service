using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using PDAService.Business;

namespace PDAService.Service
{
    /// <summary>
    /// Summary description for BIVNService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PDAService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void PdaGetPartGC(string modelId, string partNo)
        {
            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            // Log the received parameters
            try
            {

            System.Diagnostics.Debug.WriteLine($"Received modelId: {modelId}, partNo: {partNo}");
            var data = new GCHelper().PdaGetPartGC(modelId, partNo);
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                //return json;
                // Return the JSON with the correct content type
                Context.Response.Clear();
                Context.Response.ContentType = "application/json"; // Ensure response is set to JSON
                Context.Response.Write(json);
            }
            catch (Exception ex)
            {

                // Log the exception and return error as JSON
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");

                // Return error as a JSON response
                string errorJson = JsonConvert.SerializeObject(new { error = ex.Message });
                Context.Response.Clear();
                Context.Response.ContentType = "application/json"; // Ensure response is set to JSON
                Context.Response.Write(errorJson);
            }
        }
    }
}
