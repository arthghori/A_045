<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="A_045.crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        LOGIN PAGE<br />
        <br />
        USER NAME:
        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
        <p>
            PASSWORD:
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="login" />
            <asp:Button ID="btnReset" runat="server" Text="reset" />
        </p>
    </form>
</body>
</html>
