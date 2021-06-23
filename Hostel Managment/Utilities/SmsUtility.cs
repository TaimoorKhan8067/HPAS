using System;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
    class SmsUtility
    {
        string apiToken = "58b2a28c76ea302c852efe8c7a61c28ec5a6cd2734"; //Your api_token At Lifetimesms.com
        string apiSecret = "bss235222"; //Your api_secret  At Lifetimesms.com
        string Masking = "SMS Alert"; //Your Company Brand Name
        public SmsUtility()
        {

        }


        public string SendSMSPOST(string toNumber, string MessageText)
        {

            String api = "https://lifetimesms.com/json";
            String parameters = "api_token=" + apiToken + "&api_secret=" + apiSecret + "&to=" + toNumber + "&from=" + Masking + "&message=" + MessageText;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            httpWebRequest.Accept = "application/json";
            httpWebRequest.ContentType = " application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {

                parameters = "api_token=" + apiToken + "&api_secret=" + apiSecret + "&to=" + toNumber + "&from=" + Masking + "&message=" + MessageText;


                streamWriter.Write(parameters);
                streamWriter.Flush();
                streamWriter.Close();
            }


            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result.ToString();

            }


           // return null;
        }
    }
