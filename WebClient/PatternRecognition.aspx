<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatternRecognition.aspx.cs" Inherits="Web_Client.PatternRecognition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Discretistation</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <table cellpadding="10" border="1" bgcolor="white">
                <tr>
                    <th colspan="2">KarmaLego</th>
                </tr>
                <tr>
                    <td>Target File</td>
                    <td><asp:FileUpload ID="FileUploadTargetFile" runat="server" accept=".csv"/></td>
                </tr>
                <tr>
                    <td>Email Address</td>
                    <td><asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>*</td>
                </tr>
                <tr>
                    <td>Minimum Vertical Support</td>
                    <td><asp:TextBox ID="TextBoxMinVSup" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Maximum Gap</td>
                    <td><asp:TextBox ID="TextBoxMaxGap" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Epsilon</td>
                    <td><asp:TextBox ID="TextBoxEpsilon" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Horizontal Support Enabled</td>
                    <td><asp:CheckBox ID="CheckBoxHSup" runat="server" Checked="False" Enabled="False"></asp:CheckBox></td>
                </tr>
                <tr>
                    <td>Dataset Name</td>
                    <td><asp:TextBox ID="TextBoxDatasetName" runat="server"></asp:TextBox>*</td>
                </tr>
                <tr>
                    <td colspan="2"><center><asp:Button ID="Button1" runat="server" Text="Run Algorithm" OnClick="Button1_Click" /></center></td>
                </tr>
            </table>
        </center>    
        
        <br/>
        <br/>
        <br/>
        <asp:Label ID="Label1" runat="server" Text="&lt;a href=&quot;"></asp:Label>  
    </div> 
    
    </form>
</body>
</html>
