<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="arabic_words_check.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 461px">
            <h3 style="font:bold">This website is for checking the correction of Arabic words.</h3>
            <br />

            <asp:TextBox ID="QueryText" runat="server" Style="margin-left: 288px" Width="432px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="SubmitButton" runat="server" Text="أفحص" Style="margin-left: 437px" Width="149px" />
            <br />
            <div style="width: 171px; margin-left: 438px">
                <asp:Literal ID="ResultHtml" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
