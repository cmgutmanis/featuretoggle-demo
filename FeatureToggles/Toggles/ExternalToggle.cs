using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Toggles;

namespace FeatureToggles.Toggles
{
    public class ExternalToggle : IFeatureToggle
    {

        public bool IsActive<TFeature>()
        {
            var key = typeof(TFeature).Name;

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            var conn = new SqlConnection(connectionString.ToString());
            conn.Open();

            var cmd = new SqlCommand();
            cmd.CommandText = string.Format("select* from toggle where togglename = \'{0}\'", key);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            var expiry = new DateTime();

            using (var result = cmd.ExecuteReader()){
                while (result.Read())
                {
                    var toggleValue = Convert.ToBoolean(result["togglevalue"]);
                    var toggleExpiry = result["toggleexpiration"] ?? result["toggleexpiration"].ToString();
                    DateTime.TryParse(toggleExpiry as string, out expiry);
                }
            }

            conn.Close();
            return true;
        }
    }
}