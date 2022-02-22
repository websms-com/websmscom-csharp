/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

using System;

namespace Websms.Exceptions
{
    /**
     * @class ApiException
     * @brief Signals API errors.
     */
    public class ApiException : Exception
    {
        /**
         * Status code
         * @see Websms.StatusCode
         */
        public int statusCode { get; private set; }

        /**
         * Status message
         */
        private string statusMessage
        {
            get { return base.Message; }
        }

        /**
         * Constructor
         * @param[in] statusMessage Status message
         * @param[in] statusCode Status code
         */
        public ApiException(string statusMessage, int statusCode)
            : base(statusMessage)
        {
            this.statusCode = statusCode;
        }
    }
}
