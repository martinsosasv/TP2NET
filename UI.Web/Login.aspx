<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="navbar">
        <div class="navbar-inner">
                <ul class="nav pull-right">
                    
                </ul>
                <a class="brand" href="Home.aspx">UTN <span class="second">Academia</span></a>
        </div>
    </div>

    
        <div class="row-fluid">
    <div class="dialog">
        <div class="block">
            <p class="block-heading">Identificarse</p>
            <div class="block-body">
                <form>
                    <label>Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
&nbsp;<label>Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;<asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click" 
                        Text="Ingresar" />
                    <br />
                    &nbsp;&nbsp;<asp:Label ID="lblErrorIngreso" runat="server" Font-Bold="True" 
                        ForeColor="Red" Text="Usuario y/o contraseña no validos"></asp:Label>
                    &nbsp;&nbsp;<br />
                    &nbsp;</form>
                <a href="reset-password.html">
            <asp:LinkButton ID="lbOlvidaPassword" runat="server" 
                onclick="lbOlvidaPassword_Click">Olvidé mi contraseña</asp:LinkButton>
            </a>
            </div>
        </div>
        <p class="pull-right" style="">&nbsp;</p>
        <p>&nbsp;</p>
    </div>
</div>


    


    <script src="lib/bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript">
        $("[rel=tooltip]").tooltip();
        $(function () {
            $('.demo-cancel-click').click(function () { return false; });
        });
    </script>

</asp:Content>
