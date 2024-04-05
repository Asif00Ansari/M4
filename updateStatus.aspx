<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="updateStatus.aspx.cs" Inherits="FleetTrack.updateStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <h2>Update Parcel Status</h2>
        <table class="form">
             <tr>
                <td>Status</td>
                <td>
                      <asp:DropDownList ID="ddlStatus" CssClass="textboxs" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus" Display="Dynamic" 
                        ForeColor="Red" ErrorMessage="Please select Status" />
                </td>
                    <asp:HiddenField ID="hdnCustomerId" runat="server" />
                
            </tr>
          
         <%-- <tr>
                <td>Vehicle</td>
                <td>
                      <asp:DropDownList ID="ddlVehicle" CssClass="textboxs" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvVehicle" runat="server" ControlToValidate="ddlVehicle" Display="Dynamic" 
                        ForeColor="Red" ErrorMessage="Please select Vehicle" />
                </td>
                    
                
            </tr>
            <tr>
                <td>Route</td>
                <td>
                      <asp:DropDownList ID="ddlRoute" CssClass="textboxs" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvRoute" runat="server" ControlToValidate="ddlRoute" Display="Dynamic" 
                        ForeColor="Red" ErrorMessage="Please select Route" />
                </td>
                    
                
            </tr>

            <tr>
                <td>Security Team</td>
                <td>
                      <asp:DropDownList ID="ddlST" CssClass="textboxs" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvST" runat="server" ControlToValidate="ddlST" Display="Dynamic" 
                        ForeColor="Red" ErrorMessage="Please select Security Team" />
                </td>
                    
                
            </tr>--%>

        </table>
        <div class="btns">
            <%--<asp:Button ID="BtnDelete" CssClass="btn-danger" runat="server" Text="Delete" OnClick="BtnDelete_Click" CausesValidation="False" />--%>
             <asp:Button ID="BtnUpdate" CssClass="btn-warning" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
           <%-- <asp:Button ID="BtnSave" CssClass="btn-success" runat="server" Text="Save" OnClick="BtnSave_Click" />--%>
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
                OnRowDataBound="GridView1_RowDataBound"
                AllowPaging="True"
                PageSize="5"
                OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="AssignToId"
                        HeaderText="ID"
                        InsertVisible="False" ReadOnly="True"
                        SortExpression="" />
                    <asp:BoundField DataField="FullName"
                        HeaderText="Driver"
                        SortExpression="CustomerName" />
                 
                    <asp:BoundField DataField="VehicleNumber"
                        HeaderText="Vehicle Number"
                        SortExpression="Address" />

                     <asp:BoundField DataField="RouteNumber"
                        HeaderText="Route"
                        SortExpression="Address" /> 
                    <asp:BoundField DataField="SecurityTeamName"
                        HeaderText="Security Team"
                        SortExpression="Address" />

                     <asp:BoundField DataField="Status"
                        HeaderText="Status"
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

