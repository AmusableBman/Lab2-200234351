<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="Lab2.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>

    <h5>All fields are required</h5>

    <div class="form-group">
        <label for="txtFirstName" class="col-sm-3">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtLastName" class="col-sm-3">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>