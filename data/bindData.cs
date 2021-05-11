using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public static class bindData
    {
        public static bool GetInstDelResult(string response)
        {
            JObject r = JObject.Parse(response);
            JArray ar = JArray.Parse(r["data"].ToString());

            foreach(JObject x in ar)
            {
                if(Convert.ToInt32(x["rows"].ToString()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public static Dictionary<string, object> GetEmployee(string response)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            JObject r = JObject.Parse(response);
            if (Convert.ToInt32(r["return"].ToString()) != 0)
            {
                return null;
            }

            JArray ar = JArray.Parse(r["data"].ToString());
            foreach (JObject content in ar.Children<JObject>())
            {
                dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(content.ToString());
            }
            return dict;
        }

        public static Dictionary<string, object> GetKeyToDict(string response)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            JObject r = JObject.Parse(response);
            if (Convert.ToInt32(r["return"].ToString()) != 0)
            {
                return null;
            }

            JArray ar = JArray.Parse(r["data"].ToString());
            foreach (JObject content in ar.Children<JObject>())
            {
                dict.Add(content["name"].ToString(), content["nonce"]);
            }
            return dict;
        }

        public static Dictionary<string, object> GetCompanyToDict(string response)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            JObject r = JObject.Parse(response);
            if (Convert.ToInt32(r["return"].ToString()) != 0)
            {
                return null;
            }

            JArray ar = JArray.Parse(r["data"].ToString());
            foreach (JObject content in ar.Children<JObject>())
            {
                dict.Add(content["name"].ToString(), content["nonce"]);
            }
            return dict;
        }

        public static Dictionary<string, object> GetTypeOfWork(string response)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            JObject r = JObject.Parse(response);
            if (Convert.ToInt32(r["return"].ToString()) != 0)
            {
                return null;
            }

            JArray ar = JArray.Parse(r["data"].ToString());
            foreach (JObject content in ar.Children<JObject>())
            {
                dict.Add(content["name"].ToString(), content["nonce"]);
            }
            return dict;
        }

        public static DataTable GetCompany(string response)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();

            JObject r = JObject.Parse(response);
            if(Convert.ToInt32(r["return"].ToString()) != 0)
            {
                return null;
            }

            JArray ar = JArray.Parse(r["data"].ToString());

            if(ar.Count == 0)
            {
                return null;
            }

            dt = (DataTable)JsonConvert.DeserializeObject(ar.ToString(), (typeof(DataTable)));
            // Relocation Column
            //dt.Columns[1].SetOrdinal(0);
            //dt.Columns[2].SetOrdinal(4);

            dt.Columns["nonce"].SetOrdinal(0);
            dt.Columns["name"].SetOrdinal(1);
            dt.Columns["uen"].SetOrdinal(2);
            dt.Columns["typeofwork"].SetOrdinal(3);
            dt.Columns["totalemployee"].SetOrdinal(4);

            TextInfo text = new CultureInfo("en-US", false).TextInfo;
            // Rename ColumnName
            dt.Columns[0].ColumnName = text.ToTitleCase(dt.Columns[0].ColumnName);
            dt.Columns[1].ColumnName = text.ToTitleCase(dt.Columns[1].ColumnName);
            dt.Columns[2].ColumnName = text.ToTitleCase(dt.Columns[2].ColumnName);
            dt.Columns[3].ColumnName = text.ToTitleCase(dt.Columns[3].ColumnName);
            dt.Columns[4].ColumnName = text.ToTitleCase(dt.Columns[4].ColumnName);
            
            return dt;
        }

        public static DataTable JsonToExcel(string JsonStr)
        {
            JObject r = JObject.Parse(JsonStr);
            if (Convert.ToInt32(r["return"].ToString()) != 0)
            {
                return null;
            }

            JArray ar = JArray.Parse(r["data"].ToString());
            DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(ar.ToString(), (typeof(DataTable)));

            dataTable.Columns["passNo"].SetOrdinal(0);
            dataTable.Columns["companyRole"].SetOrdinal(1);
            dataTable.Columns["name"].SetOrdinal(2);
            dataTable.Columns["mobile"].SetOrdinal(3);
            dataTable.Columns["occupation"].SetOrdinal(4);
            dataTable.Columns["email"].SetOrdinal(5);
            dataTable.Columns["nric"].SetOrdinal(6);
            dataTable.Columns["category"].SetOrdinal(7);
            dataTable.Columns["company"].SetOrdinal(8);
            dataTable.Columns["nationality"].SetOrdinal(9);
            dataTable.Columns["dateOfSIC"].SetOrdinal(10);
            dataTable.Columns["csoc"].SetOrdinal(11);
            dataTable.Columns["csoc_ExpireDate"].SetOrdinal(12);
            dataTable.Columns["additionalCourse"].SetOrdinal(13);
            dataTable.Columns["additionalCourseFrom"].SetOrdinal(14);
            dataTable.Columns["additionalCourseTo"].SetOrdinal(15);
            dataTable.Columns["remark"].SetOrdinal(16);

            TextInfo text = new CultureInfo("en-US", false).TextInfo;
            dataTable.Columns[0].ColumnName = text.ToTitleCase(dataTable.Columns[0].ColumnName);
            dataTable.Columns[1].ColumnName = text.ToTitleCase(dataTable.Columns[1].ColumnName);
            dataTable.Columns[2].ColumnName = text.ToTitleCase(dataTable.Columns[2].ColumnName);
            dataTable.Columns[3].ColumnName = text.ToTitleCase(dataTable.Columns[3].ColumnName);
            dataTable.Columns[4].ColumnName = text.ToTitleCase(dataTable.Columns[4].ColumnName);
            dataTable.Columns[5].ColumnName = text.ToTitleCase(dataTable.Columns[5].ColumnName);
            dataTable.Columns[6].ColumnName = text.ToTitleCase(dataTable.Columns[6].ColumnName);
            dataTable.Columns[7].ColumnName = text.ToTitleCase(dataTable.Columns[7].ColumnName);
            dataTable.Columns[8].ColumnName = text.ToTitleCase(dataTable.Columns[8].ColumnName);
            dataTable.Columns[9].ColumnName = text.ToTitleCase(dataTable.Columns[9].ColumnName);
            dataTable.Columns[10].ColumnName = text.ToTitleCase(dataTable.Columns[10].ColumnName);
            dataTable.Columns[11].ColumnName = text.ToTitleCase(dataTable.Columns[11].ColumnName);
            dataTable.Columns[12].ColumnName = text.ToTitleCase(dataTable.Columns[12].ColumnName);
            dataTable.Columns[13].ColumnName = text.ToTitleCase(dataTable.Columns[13].ColumnName);
            dataTable.Columns[14].ColumnName = text.ToTitleCase(dataTable.Columns[14].ColumnName);
            dataTable.Columns[15].ColumnName = text.ToTitleCase(dataTable.Columns[15].ColumnName);
            dataTable.Columns[16].ColumnName = text.ToTitleCase(dataTable.Columns[16].ColumnName);
            return dataTable;
        }

        public static DataTable GetEmployeeOmit(string response)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();

            JObject r = JObject.Parse(response);
            if (Convert.ToInt32(r["return"].ToString()) != 0)
            {
                return null;
            }

            JArray ar = JArray.Parse(r["data"].ToString());

            if (ar.Count == 0)
            {
                return null;
            }

            dt = (DataTable)JsonConvert.DeserializeObject(ar.ToString(), (typeof(DataTable)));
            // Relocation Column
            dt.Columns["passno"].SetOrdinal(0);
            dt.Columns["name"].SetOrdinal(1);
            dt.Columns["nationality"].SetOrdinal(2);
            dt.Columns["companyname"].SetOrdinal(3);
            dt.Columns["occupation"].SetOrdinal(4);
            dt.Columns["mobile"].SetOrdinal(5);
            dt.Columns["remark"].SetOrdinal(6);

            TextInfo text = new CultureInfo("en-US", false).TextInfo;
            // Rename ColumnName
            dt.Columns[0].ColumnName = text.ToTitleCase(dt.Columns[0].ColumnName);
            dt.Columns[1].ColumnName = text.ToTitleCase(dt.Columns[1].ColumnName);
            dt.Columns[2].ColumnName = text.ToTitleCase(dt.Columns[2].ColumnName);
            dt.Columns[3].ColumnName = text.ToTitleCase(dt.Columns[3].ColumnName);
            dt.Columns[4].ColumnName = text.ToTitleCase(dt.Columns[4].ColumnName);
            dt.Columns[5].ColumnName = text.ToTitleCase(dt.Columns[5].ColumnName);
            dt.Columns[6].ColumnName = text.ToTitleCase(dt.Columns[6].ColumnName);

            return dt;
        }

        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }
}
