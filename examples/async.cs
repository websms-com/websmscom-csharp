// A more complex example using multiple recipients, binary messages and threads.

using System;
using System.Collections;
using System.Text;
using System.Threading;

using Websms;

class Test
{
    static void Main()
    {
        // Create the client.
        SmsClient client = new SmsClient("username", "password", "https://api.websms.com/json");

        // Create array with multiple recipients.
        long[] recipients = new long[3];
        recipients[0] = 1000001;
        recipients[1] = 1000002;
        recipients[2] = 1000003;

        // Binary message - Create concatenated SMS using a user data header
        // (http://en.wikipedia.org/wiki/Concatenated_SMS)
        
        byte[][] data = new byte[2][];
        ArrayList tmp = new ArrayList(new byte[] { 0x05, 0x00, 0x03, 0xCC, 0x02, 0x01 });
        tmp.AddRange(Encoding.UTF8.GetBytes("Hello "));
        data[0] = (byte[])tmp.ToArray(typeof(byte));
        tmp = new ArrayList(new byte[] { 0x05, 0x00, 0x03, 0xCC, 0x02, 0x02 });
        tmp.AddRange(Encoding.UTF8.GetBytes("World!"));   
        data[1] = (byte[])tmp.ToArray(typeof(byte));
                
        BinaryMessage binaryMessage = new BinaryMessage(recipients, data);
        binaryMessage.userDataHeaderPresent = true;

        Thread thread = new Thread(delegate()
        {
            try
            {
                // If test = true, it's just a test. No real sms will be sent.
                bool test = false;

                // Send the message.
                MessageResponse response = client.Send(binaryMessage, test);
                // Print the response.
                Console.WriteLine("Status message: " + response.statusMessage);
                Console.WriteLine("Status code: " + response.statusCode);
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                Console.WriteLine(ex.Message);
            }
        });

        thread.Start();
        thread.Join();
        Console.ReadKey();
    }
}
