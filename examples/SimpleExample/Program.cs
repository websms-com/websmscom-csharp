using Websms;

#region Variables

// Username to access API
string username = "";
// Password to access API
string password = "";
// Phone number of the recipient
long phonenumber = 4367612345678;
// If simulation = true, it's just a test. No real sms will be sent.
bool simulation = false;

#endregion

// Create the client.
SmsClient client = new SmsClient(username, password, "https://api.websms.com/json");
// Create new message with one recipient.
TextMessage textMessage = new TextMessage(phonenumber, "Hello World!");

try
{
    // Send the message.
    MessageResponse response = client.Send(textMessage, 1, simulation);
    // Print the response.
    Console.WriteLine("Status message: " + response.statusMessage);
    Console.WriteLine("Status code: " + response.statusCode);
}
catch (Exception ex)
{
    // Handle exceptions.
    Console.WriteLine(ex.Message);
}

Console.ReadKey();