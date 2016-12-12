<%@ Page Title="" Language="C#" MasterPageFile="~/AcademiaMasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="UI.Web.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="collapsed navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-6" aria-expanded="false">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span> </button>
                <a href="Home.aspx" class="navbar-brand">Academia</a>
            </div>
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-6">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Error</a></li>
                </ul
            </div>
        </div>
    </nav>
    <div class="container">
      <div class="row">
        <div class="span12">
          <div class="hero-unit center">
              <h1>Ha ocurrido un error. <small><font face="Tahoma" color="red">Código del Error: <span runat="server" id="spnErrorCode"></span></font></small></h1>
              <br />
              <p runat="server" id="pErrorDescription"></p>
            </div>
        </div>
      </div>
    </div>

    <nav class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <span>© 2016</span>
            <span class="pull-right">Tecnologías de Desarrollo de Software IDE</span>
        </div>
    </nav>

</asp:Content>
