/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

using System;

namespace Websms.Exceptions
{
    /**
     * @class HttpConnectionException
     * @brief Signals HTTP error.
     */
    public class HttpConnectionException : Exception
    {
        /// HTTP status code
        public int statusCode { get; private set; }

        /**
         * Constructor
         * @param[in] message Error message
         * @param[in] statusCode HTTP status code
         */
        public HttpConnectionException(string message, int statusCode)
            : base(message)
        {
            this.statusCode = statusCode;
        }
    }
}
