/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

using System;

namespace Websms.Exceptions
{
    /**
     * @class AuthorizationFailedException
     * @brief Invalid user and/or password.
     */
    public class AuthorizationFailedException : Exception
    {
        /**
         * Constructor
         * @param[in] message Error message
         */
        public AuthorizationFailedException(string message)
            : base(message)
        {
        }
    }
}
