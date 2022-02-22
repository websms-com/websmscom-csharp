/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

using Websms.Data;
using Websms.Interfaces;

namespace Websms
{
    /**
     * @class TextMessage
     * @brief Used to send a text sms message.
     * @see Websms.Data.TextSmsSendRequest
     */
    public class TextMessage : TextSmsSendRequest, IRequest
    {
        public TextMessage()
        {
        }

        /**
         * Constructor
         * @param[in] recipient Recipient
         * @param[in] messageContent Message content
         */
        public TextMessage(long recipient, string messageContent)
        {
            this.recipientAddressList = new long[1];
            this.recipientAddressList[0] = recipient;
            this.messageContent = messageContent;
        }

        /**
         * Constructor
         * @param[in] recipientAddressList List of recipients
         * @param[in] messageContent Message content
         */
        public TextMessage(long[] recipientAddressList, string messageContent)
        {
            this.recipientAddressList = recipientAddressList;
            this.messageContent = messageContent;
        }
        
        public string GetTargetUrl()
        {
            return "smsmessaging/text";
        }

    }
}
