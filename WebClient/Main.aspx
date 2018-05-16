<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Web_Client.Main" %>

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
                    <th colspan="2">Discretistation</th>
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
                    <td>Abstraction Method</td>
                    <td>
                        <table>
                            <tr><td><asp:CheckBox ID="CheckBoxSAX" runat="server"></asp:CheckBox></td><td>SAX</td></tr>
                            <tr><td><asp:CheckBox ID="CheckBoxEQW" runat="server"></asp:CheckBox></td><td>EQW</td></tr>
                            <tr><td><asp:CheckBox ID="CheckBoxTD4CEnt" runat="server"></asp:CheckBox></td><td>TD4C_Ent</td></tr>
                            <tr><td><asp:CheckBox ID="CheckBoxTD4CDiffSumMax" runat="server"></asp:CheckBox></td><td>TD4C_DiffSumMax</td></tr>
                            <tr><td><asp:CheckBox ID="CheckBoxTD4CDEnt" runat="server"></asp:CheckBox></td><td>TD4C_DEnt</td></tr>
                            <tr><td><asp:CheckBox ID="CheckBoxTD4CDiffSum" runat="server"></asp:CheckBox></td><td>TD4C_DiffSum</td></tr>
                            <tr><td><asp:CheckBox ID="CheckBoxTD4CKL" runat="server"></asp:CheckBox></td><td>TD4C_KL</td></tr>
                             <tr><td><asp:CheckBox ID="CheckBoxTD4CCos" runat="server"></asp:CheckBox></td><td>TD4C_Cos</td></tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>Class Separator</td>
                    <td><asp:TextBox ID="TextBoxClassSearator" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Bins Number</td>
                    <td><asp:TextBox ID="TextBoxBinsNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Abstracted Time Series</td>
                    <td><asp:CheckBox ID="CheckBoxAbstractedTimeSeries" runat="server"></asp:CheckBox></td>
                </tr>
                <tr>
                    <td>Variable Map</td>
                    <td><asp:FileUpload ID="FileUploadVariableMap" runat="server" accept=".csv" /></td>
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

