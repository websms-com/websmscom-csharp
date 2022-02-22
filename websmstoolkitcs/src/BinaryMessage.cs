/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

using System;

using Websms.Data;
using Websms.Interfaces;

namespace Websms
{
    /**
     * @class BinaryMessage
     * @brief Used to send a binary sms message.
     * @see Websms.Data.BinarySmsSendRequest
     */
    public class BinaryMessage : BinarySmsSendRequest, IRequest
    {
        public BinaryMessage()
        {
        }

        /**
         * Constructor
         * @param[in] recipientAddressList List of recipients
         * @param[in] messageContent Binary message content
         */
        public BinaryMessage(long[] recipientAddressList, byte[][] messageContent)
        {
            this.recipientAddressList = recipientAddressList;
            this.messageContent = new string[messageContent.Length];
            
            for (int i = 0; i < messageContent.Length; ++i)
            {
                this.messageContent[i] = Convert.ToBase64String(messageContent[i]);
            }
        }

        public string GetTargetUrl()
        {
            return "smsmessaging/binary";
        }
    }
}
