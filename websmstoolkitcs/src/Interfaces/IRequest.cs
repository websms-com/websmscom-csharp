/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

namespace Websms.Interfaces
{
    /**
     * @interface IRequest
     * @brief Simple interface for requests.
     */
    internal interface IRequest
    {
        /**
         * Target URL of request
         * @return Target URL
         */
        string GetTargetUrl();
    }
}
