using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService;

namespace EDIS.Areas.WebService.Models
{
    public class ERPVendors
    {
        public string CUS_NO { get; set; }
        public string NAME { get; set; }
        public string UNI_NO { get; set; }

        /// <summary>
        /// Check the input vendor is in ERP system or not.
        /// If true, return ERP vendorId, else return null.
        /// </summary>
        /// <param name="uno"></param>
        /// <param name="vname"></param>
        /// <returns></returns>
        public async Task<string> CheckERPVendorAsync(string uno, string vname)
        {
            ERPservicesSoapClient ERPWebServices = new ERPservicesSoapClient(ERPservicesSoapClient.EndpointConfiguration.ERPservicesSoap);
            try
            {
                var objs = await ERPWebServices.GetVendorAsync("", uno, "");
                string s = objs.Body.GetVendorResult;
                List<ERPVendors> vendors = JsonConvert.DeserializeObject<List<ERPVendors>>(s);
                var vendor = vendors.First();
                return vendor.CUS_NO;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get the ERP vendor by uno.
        /// </summary>
        /// <param name="uno"></param>
        /// <returns></returns>
        public async Task<ERPVendors> GetERPVendorAsync(string uno)
        {
            ERPservicesSoapClient ERPWebServices = new ERPservicesSoapClient(ERPservicesSoapClient.EndpointConfiguration.ERPservicesSoap);
            try
            {
                var objs = await ERPWebServices.GetVendorAsync("", uno, "");
                string s = objs.Body.GetVendorResult;
                List<ERPVendors> vendors = JsonConvert.DeserializeObject<List<ERPVendors>>(s);
                var vendor = vendors.First();
                return vendor;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Get ERP Vendor list by keyname.
        /// </summary>
        /// <param name="uno"></param>
        /// <param name="vname"></param>
        /// <returns></returns>
        public async Task<List<ERPVendors>> GetERPVendorsByKeyNameAsync(string uno, string vname)
        {
            ERPservicesSoapClient ERPWebServices = new ERPservicesSoapClient(ERPservicesSoapClient.EndpointConfiguration.ERPservicesSoap);
            try
            {
                List<ERPVendors> vendors1 = new List<ERPVendors>();
                List<ERPVendors> vendors2 = new List<ERPVendors>();
                if (float.TryParse(uno, out float result))
                {
                    var objs1 = await ERPWebServices.GetVendorAsync("", uno, "");
                    string s1 = objs1.Body.GetVendorResult;
                    if (!s1.Contains("過濾無資料"))
                    {
                        vendors1 = JsonConvert.DeserializeObject<List<ERPVendors>>(s1);
                    }
                }
                var objs2 = await ERPWebServices.GetVendorAsync("", "", vname);
                string s2 = objs2.Body.GetVendorResult;
                if (!s2.Contains("過濾無資料"))
                {
                    vendors2 = JsonConvert.DeserializeObject<List<ERPVendors>>(s2);
                }
                vendors1.AddRange(vendors2);
                if (vendors1.Count() > 0)
                {
                    vendors1 = vendors1.GroupBy(v => v.CUS_NO).Select(group => group.First()).ToList();
                }
                return vendors1;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}
