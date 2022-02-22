/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

using System;

namespace Websms.Exceptions
{
    /**
     * @class ParameterValidationException
     * @brief Signals invalid or missing parameters.
     */
    public class ParameterValidationException : Exception
    {
        /**
         * Constructor
         * @param[in] message Error message
         */
        public ParameterValidationException(string message)
            : base(message)
        {
        }
    }
}
