/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Websms.Exceptions;
using Websms.Interfaces;
using Websms.Utils;

namespace Websms
{
    /**
     * @class SmsClient
     * @brief Containts methods for sending SMS messages.
     */
    public class SmsClient
    {

        private string username;
        private string password;
        private string url;

        /**
         * Constructor
         * @param[in] username User name
         * @param[in] password Password
         * @param[in] url URL
         */
        public SmsClient(string username, string password, string url)
        {
            this.username = username;
            this.password = password;
            this.url = url.EndsWith("/") ? url : url + "/";
        }

        /**
         * Sends text message.
         * @param[in] message Text message
         * @param[in] maxSmsPerMessage Max sms per message
         * @param[in] test Test flag
         * @return Response
         */
        public MessageResponse Send(TextMessage message, uint maxSmsPerMessage, bool test)
        {
            ValidateCredentials();
            ValidateMessage(message);

            TextMessage tmp = Clone(message);
            tmp.maxSmsPerMessage = maxSmsPerMessage;
            tmp.test = test;

            string response = Post(tmp);
            return ValidateMessageResponse(JsonHelper.Deserialize<MessageResponse>(response));
        }

        /**
         * Sends binary message.
         * @param[in] message Binary message
         * @param[in] test Test flag
         * @return Response
         */
        public MessageResponse Send(BinaryMessage message, bool test)
        {
            ValidateCredentials();
            ValidateMessage(message);

            BinaryMessage tmp = Clone(message);
            tmp.test = test;

            string response = Post(tmp);
            return ValidateMessageResponse(JsonHelper.Deserialize<MessageResponse>(response));
        }

        /**
         * Validate credentials.
         * @throws Websms.Exceptions.AutorizationFailedException
         */
        private void ValidateCredentials()
        {
            if (username == null || username.Length == 0
                || password == null || password.Length == 0)
            {
                throw new AuthorizationFailedException("Missing username and/or password.");
            }
        }

        /**
         * Validate message.
         * @throws Websms.Exceptions.ParameterValidationException
         */
        private void ValidateMessage(TextMessage message) 
        {
            if (message.messageContent == null || message.messageContent.Length == 0)
            {
                throw new ParameterValidationException("No message content.");
            }
            else if (message.recipientAddressList == null || message.recipientAddressList.Length == 0)
            {
                throw new ParameterValidationException("No recipients");
            }
        }

        /**
         * Validate message.
         * @throws Websms.Exceptions.ParameterValidationException
         */
        private void ValidateMessage(BinaryMessage message)
        {
            if (message.messageContent == null || message.messageContent.Length == 0)
            {
                throw new ParameterValidationException("No message content.");
            }
            else if (message.recipientAddressList == null || message.recipientAddressList.Length == 0)
            {
                throw new ParameterValidationException("No recipients");
            }
        }

        /**
         * Validate message response.
         * @throws Websms.Exceptions.ApiException
         */
        private MessageResponse ValidateMessageResponse(MessageResponse response)
        {
            switch (response.statusCode)
            {
                case StatusCode.OK:
                case StatusCode.OK_QUEUED:
                case StatusCode.OK_TEST:
                {
                    break;
                }
                default:
                {
                    throw new ApiException(response.statusMessage, response.statusCode);
                }
            }

            return response;
        }

        /**
         * Clones object.
         * @param[in] data Source object
         * @return Object clone
         */
        private T Clone<T>(T data)
        {
            return JsonHelper.Deserialize<T>(JsonHelper.Serialize<T>(data));
        }

        /**
         * Post request.
         * @param[in] data Request
         * @return Response string
         */
        private string Post(IRequest data)
        {
            string rtn = null;
            byte[] bytes = Encoding.UTF8.GetBytes(JsonHelper.Serialize(data));
            string url = this.url + data.GetTargetUrl();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";

                string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    this.username + ":" + this.password));
                request.Headers["Authorization"] = "Basic " + auth;
                request.UserAgent = "CSharp SDK Client (v"+ Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", .NET "+ getNETFrameworkVersionNr() +")";

                Stream stream = request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                rtn = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                response.Close();
            }
            catch (WebException ex)
            {
                HttpStatusCode statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                if (statusCode == HttpStatusCode.Unauthorized)
                {
                    throw new AuthorizationFailedException("Authorization failed.");
                }
                else
                {
                    throw new HttpConnectionException("HTTP request failed.", (int)statusCode);
                }
            }
            catch (Exception ex)
            {
                throw new HttpConnectionException(ex.Message, 0);
            }
               
            return rtn;
        }
        
        private String getNETFrameworkVersionNr() {
            //Uncommmented because of migration to .net core 6.x LTS
			//RegistryKey net_versions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
			//string[] version_names = net_versions.GetSubKeyNames();
			////version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
			//String version = version_names[version_names.Length - 1].Remove(0, 1);
			//return version;
            return Environment.Version.ToString();
        }

        //Uncommented because we can read the assembly version using reflection
    	///**
    	// * library version
    	// */
    	//private static String VERSION = "1.0.2";

    }
}
