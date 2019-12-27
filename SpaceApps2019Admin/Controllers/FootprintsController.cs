using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using SpaceApps2019Admin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DeploySoftwareSolutions.SpaceApps2019Admin.Controllers
{
    public class FootprintsController : ApiController
    {

        // GET api/search
        [AllowCrossSiteJson]
        public HttpResponseMessage Get(string beam_modep)
        {
            StringBuilder whereClause = new StringBuilder(String.Empty);
            if (!string.IsNullOrEmpty(beam_modep))
            {
                whereClause.Append(" WHERE ");
                String[] filters = beam_modep.Split(',');
                foreach (string filter in filters)
                {
                    whereClause.Append(" beam_modep = '" + filter + "' OR");
                }
                whereClause.Remove(whereClause.Length - 2, 2);
            }

            var json = String.Empty;
            StringBuilder sb = new StringBuilder(String.Empty);
            String top = "{  \"type\": \"FeatureCollection\", \"name\": \"catalog_extents\", \"crs\": { \"type\": \"name\", \"properties\": { \"name\": \"urn:ogc:def:crs:OGC:1.3:CRS84\" } },\"features\": [";
            sb.Append(top);

             NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=[user]]; " +
            "Password=[pwd]];Database=eodms_geo_metadata;");
            conn.Open();

            String query = "SELECT row_to_json(f) As feature FROM(SELECT 'Feature' As type, ST_AsGeoJSON(\"wkb_geometry\")::json As geometry, row_to_json((SELECT l FROM(SELECT ogc_fid AS feat_id,titleprope,orbit_dirp,sensor_mop,polarizatp,orderablep,service_up,look_oriep,dateproper,end_datepr) As l)) As properties  FROM public.catalog_extents As l " + whereClause.ToString() + " ) As f;";

            // Define a query returning a single row result set
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataReader dr = command.ExecuteReader();

            // Output rows
            while (dr.Read())
            {
                sb.Append(dr[0]);
                sb.Append(",");

            }

            conn.Close();

            String bottom = " ]}";

           
            // remove last , 
            sb.Remove(sb.Length - 1, 1);
            sb.Append(bottom);

            var resp = new HttpResponseMessage()
            {
                Content = new StringContent(sb.ToString())
                //Content = new StringContent(json)
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return resp;
        }
        
    }
}
