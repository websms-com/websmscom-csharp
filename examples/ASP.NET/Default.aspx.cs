using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Websms;

namespace ASPExample
{
    public partial class Default : System.Web.UI.Page
    {
        private static string URL = "https://api.websms.com/json";
        private static uint MAX_SMS_PER_MESSAGE = 1;
        private static bool TEST_MESSAGE = true;

        // webmsms.com username
        private static string USERNAME = "";
        // websms.com password
        private static string PASSWORD = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Validate_Recipient(object source, ServerValidateEventArgs args)
        {
            Regex regx = new Regex("^\\d{1,20}$");

            if (Recipient.Text.Length == 0)
            {
                RecipientValidator.ErrorMessage = "Required";
                args.IsValid = false;
            }
            else if (regx.IsMatch(Recipient.Text) == false)
            {
                RecipientValidator.ErrorMessage = "Not a valid number";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                Output.Style.Add("color", "black");
                Output.Text = "-";
                return;
            }

            // Create the client.
            SmsClient client = new SmsClient(USERNAME, PASSWORD, URL);
            // Create new message with one recipient.
            TextMessage textMessage = new TextMessage(Int64.Parse(Recipient.Text), Text.Text);

            try
            {
                // Send the message.
                MessageResponse response = client.Send(textMessage, MAX_SMS_PER_MESSAGE, TEST_MESSAGE);
                // Print the response.
                Output.Style.Add("color", "black");
                Output.Text = response.statusMessage;
                Text.Text = "";
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                Output.Style.Add("color", "red");
                Output.Text = ex.Message;
            }
        }
    }
}