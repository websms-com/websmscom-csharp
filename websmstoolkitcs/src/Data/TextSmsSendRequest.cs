/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

namespace Websms.Data
{
    /**
     * @class TextSmsSendRequest
     * @brief Represents a text sms send request.
     */
    public class TextSmsSendRequest
    {
        /// Message content
        public string messageContent { get; set; }
        /// Max number of messages to be send
        public uint maxSmsPerMessage { get; set; }
        /// Test message?
        public bool test { get; set; }
        /// List of recipients
        public long[] recipientAddressList { get; set; }
        /// Address of sender
        public string senderAddress { get; set; }
        /// Type of sender address
        public string senderAddressType { get; set; }
        /// Send as flash sms?
        public bool sendAsFlashSms { get; set; }
        /// Notification url
        public string notificationCallbackUrl { get; set; }
        /// User-defined message id
        public string clientMessageId { get; set; }
        /// Priority
        public uint priority { get; set; }
        /// Authentification information
        public string authToken { get; set; }
        /// API Key
        public string apiKey { get; set; }

        public TextSmsSendRequest()
        {
            this.messageContent = null;
            this.maxSmsPerMessage = 1;
            this.test = true;
            this.recipientAddressList = null;
            this.senderAddress = "";
            this.senderAddressType = SenderAddressType.NATIONAL;
            this.sendAsFlashSms = false;
            this.notificationCallbackUrl = "";
            this.clientMessageId = "";
            this.priority = 0;
        }
    }
}
