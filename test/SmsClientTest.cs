using System;
using System.Collections;
using System.Text;

using NUnit.Framework;

using Websms;
using Websms.Exceptions;

namespace WebsmsTest
{
    [TestFixture]
    class SmsClientTest
    {
        private const string USERNAME = "";
        private const string PASSWORD = "";
        private const string URL = "https://api.websms.com/json";

        [Test]
        public void NoUser()
        {
            SmsClient client = new SmsClient(null, PASSWORD, URL);
            TextMessage message = new TextMessage();
            Assert.Throws(typeof(AuthorizationFailedException), delegate { client.Send(message, 1, true); });
        }

        [Test]
        public void NoPass()
        {
            SmsClient client = new SmsClient(USERNAME, null, URL);
            TextMessage message = new TextMessage();
            Assert.Throws(typeof(AuthorizationFailedException), delegate { client.Send(message, 1, true); });
        }

        [Test]
        public void EmptyUser()
        {
            SmsClient client = new SmsClient("", PASSWORD, URL);
            TextMessage message = new TextMessage();
            Assert.Throws(typeof(AuthorizationFailedException), delegate { client.Send(message, 1, true); });
        }

        [Test]
        public void EmptyPass()
        {
            SmsClient client = new SmsClient(USERNAME, "", URL);
            TextMessage message = new TextMessage();
            Assert.Throws(typeof(AuthorizationFailedException), delegate { client.Send(message, 1, true); });
        }


        [Test]
        public void WrongCredentials()
        {
            SmsClient client = new SmsClient("user", "pass", URL);
            long[] recipientAddressList = new long[1];
            recipientAddressList[0] = 1234567;
            TextMessage message = new TextMessage(recipientAddressList, "Hello");
            Assert.Throws(typeof(AuthorizationFailedException), delegate { client.Send(message, 1, true); });
        }

        [Test]
        public void NoMessageContent()
        {
            SmsClient client = new SmsClient(USERNAME, PASSWORD, URL);
            long[] recipientAddressList = new long[1];
            recipientAddressList[0] = 1234567;
            TextMessage message = new TextMessage(recipientAddressList, "");
            Assert.Throws(typeof(ParameterValidationException), delegate { client.Send(message, 1, true); });
        }

        [Test]
        public void NoRecipientAddressList()
        {
            SmsClient client = new SmsClient(USERNAME, PASSWORD, URL);
            long[] recipientAddressList = new long[0];
            TextMessage message = new TextMessage(recipientAddressList, "Hello");
            Assert.Throws(typeof(ParameterValidationException), delegate { client.Send(message, 1, true); });
        }

        [Test]
        public void HttpConnectionException()
        {
            SmsClient client = new SmsClient(USERNAME, PASSWORD, "Not an url");
            long[] recipientAddressList = new long[1];
            recipientAddressList[0] = 1234567;
            TextMessage message = new TextMessage(recipientAddressList, "Hello");
            Assert.Throws(typeof(HttpConnectionException), delegate { client.Send(message, 1, true); });
        }

        [Test]
        public void ApiException()
        {
            SmsClient client = new SmsClient(USERNAME, PASSWORD, URL);
            long[] recipientAddressList = new long[1];
            recipientAddressList[0] = 1234567;
            TextMessage message = new TextMessage(recipientAddressList, "Hello");
            message.priority = 999999;
            Assert.Throws(typeof(ApiException), delegate { client.Send(message, 1, true); });
        }

        [Test]
        public void TextMessage()
        {
            SmsClient client = new SmsClient(USERNAME, PASSWORD, URL);
            long[] recipientAddressList = new long[1];
            recipientAddressList[0] = 1234567;
            TextMessage message = new TextMessage(recipientAddressList, "Hello");
            message.clientMessageId = "clientMessageId";
            MessageResponse response = client.Send(message, 1, true);
            Assert.AreEqual(response.statusCode, StatusCode.OK);
            Assert.AreEqual(response.statusMessage, "OK");
            Assert.AreEqual(response.clientMessageId, "clientMessageId");
        }

        [Test]
        public void BinaryMessage()
        {
            SmsClient client = new SmsClient(USERNAME, PASSWORD, URL);
            long[] recipientAddressList = new long[1];
            recipientAddressList[0] = 1234567;
            byte[][] data = new byte[2][];
            ArrayList tmp = new ArrayList(new byte[] { 0x05, 0x00, 0x03, 0xCC, 0x02, 0x01 });
            tmp.AddRange(Encoding.UTF8.GetBytes("Hello "));
            data[0] = (byte[])tmp.ToArray(typeof(byte));
            tmp = new ArrayList(new byte[] { 0x05, 0x00, 0x03, 0xCC, 0x02, 0x02 });
            tmp.AddRange(Encoding.UTF8.GetBytes("World!"));
            data[1] = (byte[])tmp.ToArray(typeof(byte));
            BinaryMessage message = new BinaryMessage(recipientAddressList, data);
            message.clientMessageId = "clientMessageId";
            MessageResponse response = client.Send(message, true);
            Assert.AreEqual(response.statusCode, StatusCode.OK);
            Assert.AreEqual(response.statusMessage, "OK");
            Assert.AreEqual(response.clientMessageId, "clientMessageId");
        }
    }
}
