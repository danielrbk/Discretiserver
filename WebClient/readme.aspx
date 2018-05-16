<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readme.aspx.cs" Inherits="Web_Client.readme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
    <h1><u>File Input Format</u></h1>
        <h2>Dataset</h2>
        The dataset must be a csv file following this exact pattern: <br /><br />
        
        EntityID,TemporalPropertyID,TimeStamp,TemporalPropertyValue<br />
        [int],[int],[int],[float]<br />
        [int],[int],[int],[float]<br />
        .<br />
        .<br />
        .<br />
        [int],[int],[int],[float]<br />
        <br />
        <h2>Variable Map</h2>
        The variable map maps between the temporal property ID to its name. <br />
        The file expected is a csv file of the following format: <br/>
        <br />
        TemporalPropertyID,TemporalPropertyName<br />
        [int],[string]<br />
        [int],[string]<br />
        .<br />
        .<br />
        .<br />
        [int],[string]<br />
        <h2>Example</h2>
        An example can be found <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
        To run this file, use the following configurations: 55 as class separator, 3 as bins number.
    </div>
        
    </form>
</body>
</html>
