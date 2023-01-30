using Newtonsoft.Json;
using PilotDesktop.Settings.Constants;
using PilotDesktop.Settings.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.Pilot.Services
{
    public class ConnectToApi
    {
        private readonly PilotApplicationSettings _pilotApplicationSettings;

        public ConnectToApi()
        {
            _pilotApplicationSettings = Program._pilotApplicationSettings;
        }

        private static readonly HttpClient HttpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };
        private static readonly string _token = "UGlsb3RVc2VyOnRlc3Rhcg==";
        private static readonly string _urlBase = "http://pandonexis.localtest.me/api/pandoNexis/pilot/";

        public async Task<string> GetData(string method, Dictionary<string, string> parameters)
        {
            var url = _pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.BaseUrl] + method;

            if (parameters != null && parameters.Any())
            {
                foreach (var value in parameters)
                { 
                    url += "?" + value.Key + "=" + value.Value; 
                }
            }    
            try 
            { 
                var _client = new HttpClient();
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Add("ClientSecret", _pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ApiSecret]);

                var response = await _client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.Unauthorized) // Todo Handle If Status Not Success.
                {
                    var tt = response.StatusCode;
                }

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode &&
                        !string.IsNullOrWhiteSpace(responseString))
                {
                 return responseString;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("cannot connect");
            }
        }
        public async Task<string> PostData(string method,string jsonData, Dictionary<string, string> parameters)
        {
            var url = _pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.BaseUrl] + method;

            if (parameters != null && parameters.Any())
            {
                foreach (var value in parameters)
                {
                    url += "?" + value.Key + "=" + value.Value;
                }
            }
            try
            {

                var _client = new HttpClient();
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Add("ClientSecret", _pilotApplicationSettings.Settings[PilotApplicationSettingsConstants.ApiSecret]);
                

                var response = await _client.PostAsync(url, new StringContent(jsonData));
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.Unauthorized) // Todo Handle If Status Not Success.
                {
                    var tt = response.StatusCode;
                }


                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode &&
                        !string.IsNullOrWhiteSpace(responseString))
                {
                    return responseString;
                }
                return null;
            }
            catch (Exception e)
            {

                throw new Exception("cannot connect");
            }


        }
    }
}
