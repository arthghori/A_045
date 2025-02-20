<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drop.aspx.cs" Inherits="A_045.drop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="ddldepa" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldepa_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlcou" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </form>
</body>
</html>
