<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="re form.aspx.cs" Inherits="A_045.re_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 2px solid #000000;
            background-color: #33CCFF;
        }
        .auto-style2 {
            width: 249px;
        }
        .auto-style3 {
            width: 249px;
            height: 120px;
        }
        .auto-style4 {
            width: 249px;
            height: 56px;
        }
        .auto-style5 {
            width: 426px;
        }
        .auto-style6 {
            width: 171px;
        }
        .auto-style7 {
            width: 249px;
            height: 118px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="3" cellspacing="3" class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2" rowspan="1" style="text-align: center">Registration Form</td>
            </tr>
            <tr>
                <td class="auto-style6">Name</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtName" runat="server" Height="26px" Width="363px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Email</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtEmail" runat="server" Height="29px" TextMode="Email" Width="291px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Phone No</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtPhone" runat="server" Height="30px" TextMode="Phone" Width="212px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Password</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtPassword" runat="server" Height="30px" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Confirm Password</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtCpassword" runat="server" Height="30px" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Date of Birth</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtBod" runat="server" Height="28px" TextMode="Date" Width="188px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Gender</td>
                <td class="auto-style5">
                    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" Width="245px">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Which Social Media Do you Use?</td>
                <td class="auto-style5">
                    <asp:CheckBoxList ID="cblSocial" runat="server" RepeatDirection="Horizontal" Width="492px">
                        <asp:ListItem>facebook</asp:ListItem>
                        <asp:ListItem>instragram</asp:ListItem>
                        <asp:ListItem>snapchat</asp:ListItem>
                        <asp:ListItem>tinder</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Address</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtAddress" runat="server" Height="100px" TextMode="MultiLine" Width="274px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">State &amp; City</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" Width="183px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlCity1" runat="server" Width="180px">
                        <asp:ListItem Value=" ">--Select City--</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Img</td>
                <td class="auto-style5">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="347px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="2">
                    <asp:Button ID="btnSave" runat="server" Height="42px" OnClick="btnSave_Click" Text="Save" Width="126px" />
                    <asp:Button ID="btnReset" runat="server" Height="42px" OnClick="btnReset_Click" Text="Reset" Width="126px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">
                    <asp:Label ID="lblDetalis" runat="server" Text="Detalis"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">
                    <asp:GridView ID="gvdepa" runat="server" OnSelectedIndexChanged="gvdepa_SelectedIndexChanged">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style7" colspan="2">
                    <asp:DropDownList ID="ddlDepa" runat="server" AutoPostBack="True" Height="38px" OnSelectedIndexChanged="ddlDepa_SelectedIndexChanged" Width="161px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlCou" runat="server" AutoPostBack="True" Height="42px" OnSelectedIndexChanged="ddlCou_SelectedIndexChanged" Width="154px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
