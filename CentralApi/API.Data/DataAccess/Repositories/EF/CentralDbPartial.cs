using System;

namespace API.Data.DataAccess.Repositories.EF
{
    public class CentralDb : CentralDbEntities
    {
        public CentralDb() : base("name=CentralDbEntities")     // base(CloudConfigurationManager.GetSetting("PortalEntities").Replace("&quot;", "\""))    
        {
           // AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\grigor\Source\Workspaces\ShukaAm\Central-API\CentralApi\API.Data");
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }

    //[DbConfigurationType(typeof (DatabaseConfiguration))]
    public partial class CentralDbEntities
    {
        public CentralDbEntities(string connectionString) : base(connectionString)
        {
        }
    }
}