/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

namespace Websms.Data
{
    /**
     * @class SmsSendResponse
     * @brief Represents a response to a SMS send request.
     */
    public class SmsSendResponse
    {
        /// User-defined message id
        public string clientMessageId { get; set; }
        /// Transfer id
        public string transferId { get; set; }
        /// Status code
        public int statusCode { get; set; }
        /// Detailed status information
        public string statusMessage { get; set; }

        public SmsSendResponse()
        {
            this.clientMessageId = "";
            this.transferId = "";
            this.statusCode = StatusCode.OK;
            this.statusMessage = "";
        }
    }
}
