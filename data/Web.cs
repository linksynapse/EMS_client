using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;

namespace data
{
    public class Web
    {
        private string accessToken;
        private string protocol;
        private string permition;
        private string host;

        private Cookie cookie;

        public string domain
        {
            get
            {
                return host.Split(':')[0];
            }
        }
        public string port
        {
            get
            {
                return "80";
            }
        }

        public string Host
        {
            get
            {
                return host;
            }
        }

        public int permit
        {
            get
            {
                return Convert.ToInt32(permition);
            }
        }

        public Web(string protocol, string host, string accessToken, string permition)
        {
            this.protocol = protocol;
            this.host = host;
            this.accessToken = accessToken;
            this.permition = permition;

            Initalize();
        }

        public void Initalize()
        {
            cookie = new Cookie("JSESSIONID", accessToken, "/", domain);
        }

        public string GetRequest(string uri, Dictionary<string, object> Parameter, bool SSL = false)
        {
            string url = SSL ? "https://" : "http://";
            url += host + "/";
            url += uri;

            var enumerator = Parameter.GetEnumerator();
            var condition = enumerator.MoveNext();
            if (condition)
            {
                url += "?";
                do
                {
                    var current = enumerator.Current;
                    url += current.Key.Replace("$","") + "=";
                    url += System.Web.HttpUtility.UrlEncode(current.Value.ToString());
                    condition = enumerator.MoveNext();
                    if (condition)
                    {
                        url += "&";
                    }
                } while (condition);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookie);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public string PostRequest(string uri, Dictionary<string, object> Parameter, bool SSL = false)
        {
            string param = "";
            string url = SSL ? "https://" : "http://";
            url += host + "/";
            url += uri;

            var enumerator = Parameter.GetEnumerator();
            var condition = enumerator.MoveNext();
            if (condition)
            {
                do
                {
                    var current = enumerator.Current;
                    param += current.Key.Replace("$", "") + "=";
                    param += System.Web.HttpUtility.UrlEncode(current.Value.ToString());
                    condition = enumerator.MoveNext();
                    if (condition)
                    {
                        param += "&";
                    }
                } while (condition);
            }

            HttpWebRequest hr = WebRequest.CreateHttp(url);
            hr.CookieContainer = new CookieContainer();
            hr.CookieContainer.Add(cookie);
            hr.Method = "POST";
            hr.ContentType = "application/x-www-form-urlencoded";
            hr.ContentLength = param.Length;

            using (var stream = hr.GetRequestStream())
            {
                stream.Write(Encoding.ASCII.GetBytes(param), 0, param.Length);
            }

            WebResponse wr = hr.GetResponse();
            Stream st = wr.GetResponseStream();
            StreamReader sr = new StreamReader(st);
            String r = sr.ReadToEnd();
            sr.Close();
            st.Close();
            wr.Close();

            return r;
        }

        public string PostMultipart(string uri, Dictionary<string, object> parameters, bool SSL = false)
        {
            string url = SSL ? "https://" : "http://";
            url += host + "/";
            url += uri;

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cookie);
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;

            if (parameters != null && parameters.Count > 0)
            {

                using (Stream requestStream = request.GetRequestStream())
                {

                    foreach (KeyValuePair<string, object> pair in parameters)
                    {

                        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                        if (pair.Value is FormFile)
                        {
                            FormFile file = pair.Value as FormFile;
                            string header = "Content-Disposition: form-data; name=\"" + pair.Key + "\"; filename=\"" + file.Name + "\"\r\nContent-Type: " + file.ContentType + "\r\n\r\n";
                            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(header);
                            requestStream.Write(bytes, 0, bytes.Length);
                            byte[] buffer = new byte[32768];
                            int bytesRead;
                            if (file.Stream == null)
                            {
                                // upload from file
                                using (FileStream fileStream = File.OpenRead(file.FilePath))
                                {
                                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                                        requestStream.Write(buffer, 0, bytesRead);
                                    fileStream.Close();
                                }
                            }
                            else
                            {
                                // upload from given stream
                                while ((bytesRead = file.Stream.Read(buffer, 0, buffer.Length)) != 0)
                                    requestStream.Write(buffer, 0, bytesRead);
                            }
                        }
                        else
                        {
                            string data = "Content-Disposition: form-data; name=\"" + pair.Key + "\"\r\n\r\n" + pair.Value;
                            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
                            requestStream.Write(bytes, 0, bytes.Length);
                        }
                    }

                    byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                    requestStream.Write(trailer, 0, trailer.Length);
                    requestStream.Close();
                }
            }

            using (WebResponse response = request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                    return reader.ReadToEnd();
            }
        }


        public static Web Parse(string arg)
        {
            string protocol = arg.Split("//")[0];
            string host = arg.Split("//")[1].Split('/')[0];
            string accessToken = arg.Split("//")[1].Split('/')[1];
            string permition = arg.Split("//")[1].Split('/')[2];

            return new Web(protocol, host, accessToken, permition);
        }
    }
    public class FormFile
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public string FilePath { get; set; }

        public Stream Stream { get; set; }
    }
}
