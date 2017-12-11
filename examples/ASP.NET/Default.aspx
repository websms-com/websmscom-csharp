<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPExample.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>websms.com C# Toolkit example</title>
</head>
<body>
    <form id="SmsForm" runat="server">
    <table cellspacing="10">
        <tr>
            <td><b>Send text message</b></td>
        </tr>
        <tr>
            <td>Recipient:</td>
            <td>
                <asp:TextBox ID="Recipient" runat="server"
                    Width="100%" />
            </td>
            <td>
                <asp:CustomValidator ID="RecipientValidator" runat="server" ValidationGroup="First"
                    ControlToValidate="Recipient" ValidateEmptyText="true"
                    ForeColor="red"
                    OnServerValidate="Validate_Recipient" />
            </td>
        </tr>
        <tr valign="top">
            <td>Text:</td>
            <td>
                <asp:TextBox ID="Text" runat="server"
                    Width="100%" TextMode="MultiLine" Rows="5" />
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ValidationGroup="First"
                    ControlToValidate="Text" ErrorMessage="Required"
                    ForeColor="red"/>
            </td>
        </tr>
        <tr>
            <td />
            <td>
                <asp:Button runat="server" 
                    Width="100%"
                    Text="Send"
                    OnClick="Send_Click" ValidationGroup="Input1" />
            </td>
        </tr>
    </table>
    <table cellspacing="10">
        <tr>
            <td><b>Result</b></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Output" runat="server" Text="-" />
            </td>
         </tr>
    </table>
    </form>
</body>
</html>
