/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

namespace Websms
{
    /**
     * @class SenderAddressType
     * @brief Contains sender address types.
     */
    public static class SenderAddressType
    {
        /// National number
        public const string NATIONAL = "national";
        /// International number
        public const string INTERNATIONAL = "international";
        /// String
        public const string ALPHANUMERIC = "alphanumeric";
        /// Short code
        public const string SHORTCODE = "shortcode";
    }
}
