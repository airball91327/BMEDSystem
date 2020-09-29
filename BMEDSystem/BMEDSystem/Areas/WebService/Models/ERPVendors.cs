using Newtonsoft.Json;
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
    }

}
