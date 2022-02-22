/**
 * Copyright (C) 2012, sms.at mobile internet services gmbh
 * 
 * @author Markus Opitz
 */

namespace Websms
{
    /**
     * @enum StatusCode
     * @brief All status codes that can be returned by requests.
     */
    public static class StatusCode
    {
        /// Message sent
	    public const int OK	= 2000;
        /// Message queued
	    public const int OK_QUEUED = 2001;
        /// Test ok
	    public const int OK_TEST = 2002;
        /// Malformed XML/JSON
	    public const int MALFORMED_XML = 4000;
        /// Invalid credentials
	    public const int INVALID_CREDENTIALS = 4001;
        /// At least one recipient address is invalid
	    public const int INVALID_RECIPIENT = 4002;
        /// Invalid sender
	    public const int INVALID_SENDER	= 4003;
        /// Invalid message type
	    public const int INVALID_MESSAGE_TYPE = 4004;
        /// Invalid message alphabet
	    public const int INVALID_MESSAGE_ALPHABET = 4005;
        /// Invalid message class
	    public const int INVALID_MESSAGE_CLASS = 4006;
        /// Invalid message data
	    public const int INVALID_MESSAGE_DATA = 4007;
        /// Invalid message id
	    public const int INVALID_MESSAGE_ID	= 4008;
        /// Invalid text
	    public const int INVALID_TEXT = 4009;
        /// Invalid autosegment
	    public const int INVALID_AUTOSEGMENT = 4010;
        /// Invalid COD
	    public const int INVALID_COD = 4011;
        /// Throttling. Allowed message rate exceeded.
	    public const int THROTTLING = 4012;
        /// The allowed message limit exceeded.
	    public const int MSG_LIMIT_EXCEEDED	= 4013;
        /// Unauthorized IP
	    public const int UNAUTHORIZED_IP = 4014;
        /// Invalid priority
	    public const int INVALID_MESSAGE_PRIORITY = 4015;
        /// Invalid COD return address
	    public const int INVALID_COD_RETURNADDRESS = 4016;
        /// Message would generate multiple segments, but option is not enabled.
	    public const int MULTISEGMENTS = 4017;
        /// Method not allowed
	    public const int API_METHOD_FORBIDDEN = 4018;
        /// Parameter missing
	    public const int PARAMETER_MISSING = 4019;
        // Invalid API key
	    public const int INVALID_API_KEY = 4020;
        /// Invalid auth token
	    public const int INVALID_AUTH_TOKEN	= 4021;
        /// Access denied
	    public const int ACCESS_DENIED = 4022;
        /// Rate Limit Exceeded, spam check
	    public const int THROTTLING_SPAMMING_IP = 4023;
        /// Too many requests
	    public const int THROTTLING_TOO_MANY_REQUESTS = 4024;
        // Too many recipients
	    public const int THROTTLING_TOO_MANY_RECIPIENTS	= 4025;
        /// Message content too long
	    public const int MAX_SMS_PER_MESSAGE_EXCEEDED = 4026;
        /// Internal error
	    public const int INTERNAL_ERROR	= 5000;
        /// Service not available
	    public const int SERVICE_UNAVAILABLE = 5003;
    }
}
