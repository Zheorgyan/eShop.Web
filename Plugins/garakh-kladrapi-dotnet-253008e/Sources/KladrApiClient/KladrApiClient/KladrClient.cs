namespace KladrApiClient
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Globalization;
    using System.Net;
    using System.Runtime.Serialization;

    /// <summary>
    /// Performs operation to get address from Kladr API.
    /// </summary>
    public class KladrClient
    {
        #region Fields
        private const string _apiEndpoint = "http://kladr-api.ru/api.php?";

        /// <summary>
        /// WebClient object to make API calls.
        /// </summary>
        private WebClient _client;

        /// <summary>
        /// Callback for FirmSearchResponse.
        /// </summary>
        private KladrApiCallback _apiCall;

        /// <summary>
        /// Clients Token.
        /// </summary>
        private string _clientToken;

        /// <summary>
        /// Clients Key.
        /// </summary>
        private string _clientKey;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KladrClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="key">The key.</param>
        public KladrClient(string token, string key)
        {
            _clientToken = token;
            _clientKey = key;
            _client = new WebClient();
            _client.OpenReadCompleted += clientFindAddress;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KladrClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="key">The key.</param>
        /// <param name="client">The client object for async operations.</param>
        public KladrClient(string token, string key, WebClient client)
        {
            _clientToken = token;
            _clientKey = key;
            _client = client ?? new WebClient();
            _client.OpenReadCompleted += clientFindAddress;
        }

        #endregion Constructor

        #region Delegates

        /// <summary>
        /// Callback for API call.
        /// </summary>
        /// <param name="resp">The response object.</param>
        public delegate void KladrApiCallback(KladrResponse resp);

        #endregion Delegates

        #region Methods

        /// <summary>
        /// Finds the address.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="callback">The callback.</param>
        public void FindAddress(Dictionary<string,string> parameters, KladrApiCallback callback)
        {
            if (parameters == null)
            {
                invokeException(null, "Parameters dictionary is null");
                return;
            }

            ////Assigning callback
            _apiCall = callback;
            var paramsToPost = createParametersString(parameters);
            var request = String.Format(CultureInfo.CurrentCulture, _apiEndpoint + paramsToPost);
            var uri = new Uri(request);
            try
            {
                ////Performing async open-read
                if (!_client.IsBusy)
                {
                    _client.OpenReadAsync(uri);
                }
            }
            catch (WebException ex)
            {
                ////Calling proper callback and setting error data.
                invokeException(ex.InnerException, ex.Message);
            }
        }

        /// <summary>
        /// Creates the parameters string.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        private string createParametersString(Dictionary<string, string> values)
        {
            string parametersToPost = string.Empty;

            if (values.ContainsKey("regionId"))
                parametersToPost += "&regionId=" + values["regionId"];

            if (values.ContainsKey("districtId"))
                parametersToPost += "&districtId=" + values["districtId"];

            if (values.ContainsKey("cityId"))
                parametersToPost += "&cityId=" + values["cityId"];

            if (values.ContainsKey("streetId"))
                parametersToPost += "&streetId=" + values["streetId"];

            if (values.ContainsKey("buildingId"))
                parametersToPost += "&buildingId=" + values["buildingId"];

            if (values.ContainsKey("query"))
                parametersToPost += "&query=" + values["query"];

            if (values.ContainsKey("contentType"))
                parametersToPost += "&contentType=" + values["contentType"];

            if (values.ContainsKey("withParent"))
                parametersToPost += "&withParent=" + values["withParent"];

            if (values.ContainsKey("limit"))
                parametersToPost += "&limit=" + values["limit"];

            if (values.ContainsKey("callback"))
                parametersToPost += "&callback=" + values["callback"];

            parametersToPost += "&token=" + _clientToken;
            parametersToPost += "&key=" + _clientKey;

            if (parametersToPost.Length > 1)
                if (parametersToPost.StartsWith("&"))
                    parametersToPost = parametersToPost.Substring(1);
            return parametersToPost;
        }

        /// <summary>
        /// Handles the address search event of the client control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Net.OpenReadCompletedEventArgs"/> instance containing the event data.</param>
        private void clientFindAddress(object sender, OpenReadCompletedEventArgs e)
        {
            ////If no Error
            if (e.Error == null)
            {
                try
                {
                    ////Getting result stream
                    var s = e.Result;
                    var _jsonDeserializer = new JsonSerializer();
                    var _jsonReader = new JsonTextReader(new StreamReader(s));
                    var resp = (KladrResponse)_jsonDeserializer.Deserialize(_jsonReader, typeof(KladrResponse));
                    if (_apiCall != null)
                    {
                        resp.InfoMessage = "OK";
                        _apiCall.Invoke(resp);
                    }

                }
                catch (SerializationException ex)
                {
                    ////Calling proper callback and setting error data.
                    invokeException(ex.InnerException, ex.Message);
                }
                finally
                {
                    if (e.Result != null)
                    {
                        e.Result.Close();
                    }
                }
            }
            else
            {
                ////Calling proper callback and setting error data.
                invokeException(e.Error, e.Error.Message);
            }
        }

        /// <summary>
        /// Invokes the exceptions for all calls.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message of the exception.</param>
        private void invokeException(Exception e, string message)
        {
            if (e == null)
            {
                return;
            }

            if (_apiCall != null)
            {
                _apiCall.Invoke(new KladrResponse(){Error = e, InfoMessage = message});
            }
        }

        #endregion
    }
}
