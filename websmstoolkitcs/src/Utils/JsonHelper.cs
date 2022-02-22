/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace Websms.Utils
{
    /**
     * @class JsonHelper
     * @brief Methods for JSON serialization/deserialization.
     */
    public class JsonHelper
    {
        /**
         * Serialize object to JSON string.
         * @param[in] data Object
         * @return JSON string
         */
        public static string Serialize<T>(T data)
        {
            string json;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(data.GetType());
            
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, data);
                json = Encoding.UTF8.GetString(stream.ToArray());
            }

            return json;
        }

        /**
         * Deserialize JSON string.
         * @param[in] json JSON string
         * @return Object
         */
        public static T Deserialize<T>(string json)
        {
            T data;
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                data = (T)deserializer.ReadObject(stream);
            }

            return data;
        }
    }
}