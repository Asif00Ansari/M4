<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SecurityTeam.aspx.cs" Inherits="FleetTrack.SecurityTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <h2>Security Team Registration Form</h2>
        <table class="form">
             <tr>
                <td>Security Team Name</td>
                <td>
                    <asp:TextBox ID="txtSTName" CssClass="textboxs" runat="server"></asp:TextBox></td>
                    <asp:HiddenField ID="hdnCustomerId" runat="server" />
                <td>
                    <asp:RequiredFieldValidator ID="rfvFullName" runat="server"
                        ErrorMessage="Team Name is Required" ForeColor="Red" Display="Dynamic"
                        ControlToValidate="txtSTName">

                    </asp:RequiredFieldValidator></td>
            </tr>
            <%--<tr>
                <td>Contact Number</td>
                <td>
                    <asp:TextBox ID="txtContactNumber" CssClass="textboxs" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvUserName" runat="server"
                        ErrorMessage="Contact number is Required" ForeColor="Red"
                        ControlToValidate="txtContactNumber">

                    </asp:RequiredFieldValidator></td>
            </tr>--%>
           <%-- <tr>
                <td>Email Address&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="textboxs" runat="server" TextMode="Email"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" Display="Dynamic"
                        ErrorMessage="Email Address is Required" ForeColor="Red"
                        ControlToValidate="txtEmail">
                    </asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="validateEmail"
                       runat="server" ErrorMessage="Invalid email." Display="Dynamic"
                     ControlToValidate ="txtEmail" ForeColor="Red"
                     ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" /></td>
            </tr>--%>
            <tr>
                <td>Number Of Guards</td>
                <td>
                    <asp:TextBox ID="NoOfGuards" type="number"  runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvPassword" runat="server"
                        ErrorMessage="No Of Guard is Required" ForeColor="Red"
                        ControlToValidate="NoOfGuards"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button ID="BtnDelete" CssClass="btn-danger" runat="server" Text="Delete" OnClick="BtnDelete_Click" CausesValidation="False" />
             <asp:Button ID="BtnUpdate" CssClass="btn-warning" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
            <asp:Button ID="BtnSave" CssClass="btn-success" runat="server" Text="Save" OnClick="BtnSave_Click" />
        </div>
        <div class="Grid">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="True"
                BorderStyle="None"
                CssClass="Grid"
                EditRowStyle-ForeColor="#0066FF"
                Width="650px"
                BackColor="White"
                BorderColor="#CCCCCC"
                BorderWidth="1px"
                CellPadding="3"
                Height="20px"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                AllowPaging="True"
                PageSize="5"
                OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="SecurityTeamId"
                        HeaderText="ID"
                        InsertVisible="False" ReadOnly="True"
                        SortExpression="" />
                    <asp:BoundField DataField="SecurityTeamName"
                        HeaderText="Security Team Name"
                        SortExpression="CustomerName" />
                   <%-- <asp:BoundField DataField="ContactNumber"
                        HeaderText="Contact Number"
                        SortExpression="ContactNumber" />
                    <asp:BoundField DataField="Email"
                        HeaderText="Email-Address"
                        SortExpression="" />--%>
                    <asp:BoundField DataField="NoOfGuards"
                        HeaderText="No Of Guards"
                        SortExpression="Address" />
                </Columns>

                <EditRowStyle ForeColor="#0066FF" />

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

            </asp:GridView>
        </div>
    </div>
</asp:Content>

