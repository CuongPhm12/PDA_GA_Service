﻿using Newtonsoft.Json;
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
        public void PdaGetPartGC(string modelId, string partNo, string refNo)
        {
            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            // Log the received parameters
            try
            {

                System.Diagnostics.Debug.WriteLine($"Received modelId: {modelId}, partNo: {partNo}, refNo: {refNo}");
                var data = new GCHelper().PdaGetPartGC(modelId, partNo, refNo);
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_PartNo_NotChecked(string modelId, string refNo)
        {
            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            // Log the received parameters
            try
            {

                System.Diagnostics.Debug.WriteLine($"Received modelId: {modelId}, refNo: {refNo}");
                var data = new GCHelper().Get_PartNo_NotChecked(modelId, refNo);
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void PdaInsertHistory(string model, string partNo, string refNo, string wo)
        {
            // Log the received parameters
            System.Diagnostics.Debug.WriteLine($"Received model: {model}, partNo: {partNo}, refNo: {refNo}, wo: {wo}");

            try
            {

                //var pStatus = new GCHelper().writeHistory(model, partNo, refNo,wo);
                var pStatus = new GCHelper().writeHistory(model, partNo, refNo, wo);
                // Log or debug output for verification
                System.Diagnostics.Debug.WriteLine($"Stored procedure output @pStatus: {pStatus}");

                // Create a JSON response with the status
                var response = new { pStatus = pStatus };
                string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonResponse);
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");

                // Return error as JSON
                string errorJson = JsonConvert.SerializeObject(new { error = ex.Message });
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(errorJson);
            }
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void PdaInsertHistory_ver_new_1(string model, string partNo, string refNo, string wo, int qty)
        {
            // Log the received parameters
            System.Diagnostics.Debug.WriteLine($"Received model: {model}, partNo: {partNo}, refNo: {refNo}, wo: {wo}, qty: {qty}");

            try
            {

                //var pStatus = new GCHelper().writeHistory(model, partNo, refNo,wo);
                var pStatus = new GCHelper().writeHistory_ver_new_1(model, partNo, refNo, wo, qty);
                // Log or debug output for verification
                System.Diagnostics.Debug.WriteLine($"Stored procedure output @pStatus: {pStatus}");

                // Create a JSON response with the status
                var response = new { pStatus = pStatus };
                string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonResponse);
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");

                // Return error as JSON
                string errorJson = JsonConvert.SerializeObject(new { error = ex.Message });
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(errorJson);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetReload(string wo)
        {
            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            // Log the received parameters
            try
            {

                System.Diagnostics.Debug.WriteLine($"Received wo: {wo}");
                var data = new Helper_17().GetReload(wo);
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Get_TotalByMachine(string wo, string machine_id)
        {
            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            // Log the received parameters
            try
            {

                System.Diagnostics.Debug.WriteLine($"Received wo: {wo}, machine_id: {machine_id}");
                var data = new Helper_17().Get_TotalByMachine(wo, machine_id);
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DeleteItemReplaceVerify(string wo, string machine, string slot, string upn)
        {
            // Log the received parameters
            System.Diagnostics.Debug.WriteLine($"Received wo: {wo}, machine: {machine}, slot: {slot}, upn: {upn}");

            try
            {

                var result = new Helper_17().DeleteItemReplaceVerify(wo, machine, slot, upn);
                // Log or debug output for verification

                System.Diagnostics.Debug.WriteLine($"Stored procedure output @pStatus: {result.Status}");
                System.Diagnostics.Debug.WriteLine($"Stored procedure output @pResults: {result.Results}");

                // Create a JSON response with the status
                var response = new { pStatus = result.Status, pResults = result.Results };
                string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonResponse);
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");

                // Return error as JSON
                string errorJson = JsonConvert.SerializeObject(new { error = ex.Message });
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(errorJson);
            }
        }
    }
}
