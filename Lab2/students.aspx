<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="Lab2.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Students</h1>

    <a href="student.aspx">Add Student</a>

    <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="false" OnRowDeleting="grdStudents_RowDeleting"
        DataKeyNames="StudentID">
        <Columns>        
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" />
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="student.aspx" 
                 Text="Edit" DataNavigateUrlFields="StudentID"
                 DataNavigateUrlFormatString="student.aspx?StudentID={0}" />
            <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" HeaderText="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>
