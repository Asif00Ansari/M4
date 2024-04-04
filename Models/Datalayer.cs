using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FleetTrack.Models
{
    public class clsDataLayer
    {
        public string conString = ConfigurationManager.ConnectionStrings["DBcon"].ToString();
        public DataSet ExecuteSqlString(string sqlstring)
        {
            try
            {
                SqlConnection objsqlconn = new SqlConnection(conString);
                objsqlconn.Open();

                DataSet Ds = new DataSet();
                SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(Ds);
                objsqlconn.Close();
                return Ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertUpdateDeleteSQLString(string sqlstring)
        {

            try
            {
                SqlConnection objsqlconn = new SqlConnection(conString);
                objsqlconn.Open();
                SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
                objcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet FillManufacturer()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Manufacturer";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        public DataSet Fillvehicle()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_vehicle";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        public DataSet FillStatus()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_ParcelStatus";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        public DataSet Filldriver()
        {
            DataSet obj = new DataSet();
            string sql = "select * from tbl_Login where IsAdmin = 0";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        public DataSet FillRoute()
        {
            DataSet obj = new DataSet();
            string sql = "select * from tbl_Route";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        public DataSet FillST()
        {
            DataSet obj = new DataSet();
            string sql = "select * from tbl_SecurityTeam";
            obj = ExecuteSqlString(sql);
            return obj;

        }
    }
    // User class
    public class clsUser : clsDataLayer
    {

        // Validate Username and Password
        public DataSet ISValid(User user)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT *  from tbl_Login where username='" + user.username + "' and password= '" + user.password + "'";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        // Add new user on tlb_Login
        public void AddNewUser(User obj)
        {

            string sql = "INSERT INTO tbl_Login (FullName,Username,Password ,Email,IsAdmin )"
                        + "VALUES('" + obj.FullName + "','" + obj.username + "', '" + obj.password + "' , '" + obj.email + "', '" + obj.IsAdmin + "' )";

            InsertUpdateDeleteSQLString(sql);


        }
        // Update existing user
        public void UpdateUser(User obj)
        {

            string sql = " UPDATE  tbl_Login" +
                         " SET UserName='" + obj.username + "'," +
                         " Password='" + obj.password + "'," +
                         " Email='" + obj.email + "'," +
                         " IsAdmin='" + obj.IsAdmin + "'" +
                         "Where UserId='" + obj.UserId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing user
        public void DeleteUser(int userId)
        {
            User obj = new User();
            string sql = "Delete from tbl_Login where userId='" + userId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all users to DataGrid
        public DataSet LoadUser()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT *,Case when IsAdmin=1 then 'Admin' else 'Driver' end as UserType from tbl_Login order by userId";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }
    // Customer class
    public class clsCustomer : clsDataLayer
    {
        // Add new customer on tlb_Customer
        public void AddNewCustomer(Customers obj)
        {

            string sql = "INSERT INTO tbl_Vehicle (VehicleNumber,Address)"
                        + "VALUES('" + obj.CustomerName + "','" + obj.Address + "')";

            InsertUpdateDeleteSQLString(sql);
        }
        // Update existing customer
        public void UpdateCustomer(Customers obj)
        {

            string sql = " UPDATE  tbl_Vehicle" +
                         " SET VehicleNumber='" + obj.CustomerName + "'," +
                         " Address='" + obj.Address + "'" +
                         "Where VehicleId=" + obj.CustomerId + "";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing Customer
        public void DeleteCustomer(int userId)
        {
            User obj = new User();
            string sql = "Delete from tbl_Vehicle where VehicleId='" + userId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all Customers to DataGrid
        public DataSet LoadCustomer()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Vehicle order by VehicleId";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }

    // Route Class

    public class clsRoute : clsDataLayer
    {

        public void AddNewRoute(Router obj)
        {

            string sql = "INSERT INTO tbl_Route (RouteNumber,Address)"
                        + "VALUES('" + obj.RouteName + "','" + obj.Address + "')";

            InsertUpdateDeleteSQLString(sql);
        }
        // Update existing customer
        public void UpdateRoute(Router obj)
        {

            string sql = " UPDATE  tbl_Route" +
                         " SET RouteNumber='" + obj.RouteName + "'," +
                         " Address='" + obj.Address + "'" +
                         "Where RouteId=" + obj.RouteId + "";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing Customer
        public void DeleteRoute(int Routeid)
        {
            User obj = new User();
            string sql = "Delete from tbl_Route where RouteId='" + Routeid + "'";
            InsertUpdateDeleteSQLString(sql);

        }


        public DataSet LoadRoute()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Route order by RouteId";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }

    //  Sales Class

    public class clsOrderes : clsDataLayer
    {

        // Add new Order to OrderDetails table.
        public void AddNewOrder(OrderDetails obj)
        {

            string sql = "INSERT INTO OrderDetails" +
                         " (ProductId,Quantity ,UnitPrice,TotalPrice,CustomerId,OrderBy )" +
                         " VALUES( '" + obj.ProductId + "' , "
                                     + obj.Quantity + ", " + obj.UnitPrice + ","
                                     + obj.TotalPrice + ", " + obj.CustomerId + "," + obj.OrderBy + " )";

            InsertUpdateDeleteSQLString(sql);
            UpdateProductDetail(obj);
        }
        // add new sales information to productDetail tables.
        public void AddNewProductDetail(Product obj)
        {

            string sql = "INSERT INTO tbl_ProductDetail" +
                         " (ProductName,Descreption,ProductImage ,ManufId,Quantity,UnitCost,CurrentCost)" +
                         " VALUES('" + obj.ProductName + "', '" + obj.Descreption + "' , '"
                         + obj.ProductImage + "', " + obj.ManufId + "," + obj.Quantity + ", " + obj.UnitCost + "," + obj.TotalCost + " )";
            DataTable dt = ExecuteSqlString("select Max(ProductId) ProductId FROM tbl_ProductDetail").Tables[0];
            string transaction = "insert into tbl_Transaction(TransactionType,CreatedBy,ProductId,Quantity,UnitPrice,TotalPrice)" +
                "values(2," + obj.CreatedBy + "," + int.Parse("0" + dt.Rows[0]["ProductId"]) + "," + obj.Quantity + "," + obj.UnitCost + "," + obj.TotalCost + ")";

            InsertUpdateDeleteSQLString(sql);
            InsertUpdateDeleteSQLString(transaction);
        }
        // update Product information in product detail table
        public void UpdateProductDetail(OrderDetails obj)
        {
            string sql = " Update tbl_ProductDetail set Quantity=(Quantity-" + obj.Quantity + "),CurrentCost=(UnitCost*(Quantity-" + obj.Quantity + ")),ModifiedDate=GETDATE() where ProductId=" + obj.ProductId;
            string transaction = "insert into tbl_Transaction(TransactionType,CreatedBy,ProductId,Quantity,UnitPrice,TotalPrice)" +
                "values(1," + obj.OrderBy + "," + obj.ProductId + "," + obj.Quantity + "," + obj.UnitPrice + "," + obj.TotalPrice + ")";
            InsertUpdateDeleteSQLString(sql);
            InsertUpdateDeleteSQLString(transaction);
        }

        // Load Order List  to DataGrid
        public DataSet LoadOrderList(int userId)
        {
            DataSet obj = new DataSet();
            string sql = string.Empty;
            if (userId > 0)
            {
                sql = "select O.ProductId,ProductName,Descreption,ProductImage,O.Quantity,O.UnitPrice,O.TotalPrice,C.CustomerName," +
                    " O.OrderId,O.UniqueId OrderNo, Convert(varchar, O.OrderDate,106) OrderDate,L.FullName UserName from OrderDetails O" +
                    " JOIN tbl_ProductDetail P  ON P.ProductId = O.ProductId" +
                    " JOIN tbl_Customer C ON C.CustomerId = O.CustomerId" +
                    " JOIN tbl_Login L ON L.UserId = O.OrderBy" +
                    " where O.OrderBy = " + userId;
            }
            else
            {
                sql = "select O.ProductId,ProductName,Descreption,ProductImage,O.Quantity,O.UnitPrice,O.TotalPrice,C.CustomerName," +
                    " O.OrderId,O.UniqueId OrderNo, Convert(varchar, O.OrderDate,106) OrderDate,L.FullName UserName from OrderDetails O" +
                    " JOIN tbl_ProductDetail P  ON P.ProductId = O.ProductId" +
                    " JOIN tbl_Customer C ON C.CustomerId = O.CustomerId" +
                    " JOIN tbl_Login L ON L.UserId = O.OrderBy";
            }
            obj = ExecuteSqlString(sql);
            return obj;
        }
        // Load LoadTransactionList List  to DataGrid
        public DataSet LoadTransactionList(int userId)
        {
            DataSet obj = new DataSet();
            string sql = string.Empty;
            if (userId > 0)
            {
                sql = "select T.TransactionId,ProductName,Descreption,ProductImage,T.Quantity,T.UnitPrice,T.TotalPrice," +
                      " case When T.TransactionType = 1 then 'Credit' else 'Debit' end TransactionType, T.TransactionNumber," +
                      " Convert(varchar, T.CreatedDate,106) TransactionDate,L.FullName UserName from tbl_Transaction T" +
                      " JOIN tbl_ProductDetail P  ON P.ProductId = T.ProductId" +
                      " JOIN tbl_Login L ON L.UserId = T.CreatedBy where T.CreatedBy = " + userId;
            }
            else
            {
                sql = "select T.TransactionId,ProductName,Descreption,ProductImage,T.Quantity,T.UnitPrice,T.TotalPrice," +
                      " case When T.TransactionType = 1 then 'Credit' else 'Debit' end TransactionType, T.TransactionNumber," +
                      " Convert(varchar, T.CreatedDate,106) TransactionDate,L.FullName UserName from tbl_Transaction T" +
                      " JOIN tbl_ProductDetail P  ON P.ProductId = T.ProductId" +
                      " JOIN tbl_Login L ON L.UserId = T.CreatedBy";
            }
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public DataSet LoadProduct(int productId)
        {
            DataSet obj = new DataSet();
            string sql = string.Empty;
            if (productId > 0)
            {
                sql = "select ProductId,ProductName,Descreption,ProductImage,ManufId,Quantity,UnitCost,CurrentCost,CreatedDate,ModifiedDate," +
                    "M.ManufacturerName from  tbl_ProductDetail P JOIN tbl_Manufacturer M ON M.ManufacturerID = P.ManufId where ProductId =" + productId;
            }
            else
            {
                sql = "select ProductId,ProductName,Descreption,ProductImage,ManufId,Quantity,UnitCost,CurrentCost,CreatedDate,ModifiedDate," +
                    "M.ManufacturerName from  tbl_ProductDetail P JOIN tbl_Manufacturer M ON M.ManufacturerID = P.ManufId ";
            }
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public void DeleteProduct(Product obj)
        {
            InsertUpdateDeleteSQLString("delete from tbl_ProductDetail where ProductId=" + obj.ProductId);
        }
        public void UpdateProduct(Product obj)
        {
            InsertUpdateDeleteSQLString("update tbl_ProductDetail set ProductName='" + obj.ProductName + "',ManufId=" + obj.ManufId + ",Descreption='" + obj.Descreption + "'" +
                ",ProductImage='" + obj.ProductImage + "',Quantity=" + obj.Quantity + ",UnitCost=" + obj.UnitCost + ",CurrentCost=" + obj.TotalCost + ",ModifiedDate=getdate()  where ProductId=" + obj.ProductId);
            string transaction = "insert into tbl_Transaction(TransactionType,CreatedBy,ProductId,Quantity,UnitPrice,TotalPrice)" +
                "values(2," + obj.CreatedBy + "," + obj.ProductId + "," + obj.Quantity + "," + obj.UnitCost + "," + obj.TotalCost + ")";
            InsertUpdateDeleteSQLString(transaction);
        }
    }

    public class clsManufacturer : clsDataLayer
    {
        // Add new Manufacturer to sales table.
        public void AddNewManufacturer(Manufacturer obj)
        {

            string sql = "INSERT INTO tbl_Manufacturer" +
                         " (ManufacturerName,Email ,PhoneNumber,Address)" +
                         " VALUES('" + obj.ManufacturerName + "' , '" + obj.Email + "', '" + obj.PhoneNumber + "','" + obj.Address + "')";

            InsertUpdateDeleteSQLString(sql);

        }

        // Update existing Manufacturer
        public void UpdateManufacturer(Manufacturer obj)
        {

            string sql = " UPDATE  tbl_Manufacturer" +
                         " SET ManufacturerName='" + obj.ManufacturerName + "'," +
                         " Address='" + obj.Address + "'," +
                         " PhoneNumber='" + obj.PhoneNumber + "'," +
                         " Email='" + obj.Email + "'" +
                         " Where ManufacturerID='" + obj.ManufacturerID + "'";

            InsertUpdateDeleteSQLString(sql);

        }

        //Delete existing Manufacturer
        public void DeleteManufacturer(string manufacturerId)
        {
            Manufacturer obj = new Manufacturer();
            string sql = "Delete from tbl_Manufacturer where ManufacturerID='" + manufacturerId + "'";
            InsertUpdateDeleteSQLString(sql);

        }

        // Load all Manufacturer to DataGrid
        public DataSet LoadManufacturer()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Manufacturer order by ManufacturerID";
            obj = ExecuteSqlString(sql);
            return obj;
        }
    }

    public class clsSecurityTeam : clsDataLayer
    {

        public void AddNewST(ST obj)
        {

            string sql = "INSERT INTO tbl_SecurityTeam (SecurityTeamName,NoOfGuards)"
                        + "VALUES('" + obj.SecurityTeamName + "','" + obj.NoOfGuards + "')";

            InsertUpdateDeleteSQLString(sql);
        }
        // Update existing ST
        public void UpdateST(ST obj)
        {

            string sql = " UPDATE  tbl_SecurityTeam" +
                         " SET SecurityTeamName='" + obj.SecurityTeamName + "'," +
                         " NoOfGuards='" + obj.NoOfGuards + "'" +
                         "Where SecurityTeamId=" + obj.SecurityTeamId + "";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing ST
        public void DeleteST(int userId)
        {
            User obj = new User();
            string sql = "Delete from tbl_SecurityTeam where SecurityTeamId='" + userId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all STs to DataGrid
        public DataSet LoadST()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_SecurityTeam order by SecurityTeamId";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }

    public class clsAssignToDriver : clsDataLayer
    {

        public void AddNewAssignToDriver(AssignToDriver obj)
        {

            string sql = "INSERT INTO tbl_AssignToDriver (DriverId,SecurityTeamId,RouteId,VehicleId)"
                        + "VALUES('" + obj.DriverId + "','" + obj.STId + "','" + obj.RouteId + "','" + obj.VehicleId + "')";

            InsertUpdateDeleteSQLString(sql);
        }
        // Update existing ST
        public void UpdateAssignToDriver(AssignToDriver obj)
        {

            string sql = " UPDATE  tbl_AssignToDriver" +
                         " SET DriverId ='" + obj.DriverId + "'," +
                         " SecurityTeamId ='" + obj.STId + "'," +
                         " RouteId ='" + obj.RouteId + "'," +
                         " VehicleId ='" + obj.VehicleId + "'" +
                         "Where AssignToId =" + obj.AssignToId + "";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing ST
        public void DeleteAssignToDriver(int userId)
        {
            User obj = new User();
            string sql = "Delete from tbl_AssignToDriver where AssignToId='" + userId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all STs to DataGrid
        public DataSet LoadAssignToDriver()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT AssignToId,l.FullName,v.VehicleNumber,r.RouteNumber,st.SecurityTeamName,case when ad.Status is null then 'New' else ad.Status end as [Status] from tbl_AssignToDriver AD inner join tbl_Login L on ad.DriverId = l.UserId inner join tbl_Vehicle V on ad.VehicleId = v.VehicleId inner join tbl_Route R on ad.RouteId = r.RouteId inner join tbl_SecurityTeam St on ad.SecurityTeamId = st.SecurityTeamId order by Ad.AssignToId";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }

    public class clsUpdateStatus : clsDataLayer
    {

        public void AddNewupdateStatus(UpdateStatus1 obj)
        {

            string sql = "INSERT INTO tbl_AssignToDriver (DriverId,SecurityTeamId,RouteId,VehicleId)"
                        + "VALUES('" + obj.DriverId + "','" + obj.STId + "','" + obj.RouteId + "','" + obj.VehicleId + "')";

            InsertUpdateDeleteSQLString(sql);
        }
        // Update existing ST
        public void updateStatus(UpdateStatus1 obj)
        {

            string sql = " UPDATE  tbl_AssignToDriver" +
                         " SET Status ='" + obj.Status + "'" +
                         "Where AssignToId =" + obj.AssignToId + "";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing ST
        public void DeleteupdateStatus(int userId)
        {
            User obj = new User();
            string sql = "Delete from tbl_AssignToDriver where AssignToId='" + userId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all STs to DataGrid
        public DataSet LoadStatus1(int userid)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT AssignToId,l.FullName,v.VehicleNumber,r.RouteNumber,st.SecurityTeamName,case when ad.Status is null then 'New' else ad.Status end as [Status] from tbl_AssignToDriver AD inner join tbl_Login L on ad.DriverId = l.UserId inner join tbl_Vehicle V on ad.VehicleId = v.VehicleId inner join tbl_Route R on ad.RouteId = r.RouteId inner join tbl_SecurityTeam St on ad.SecurityTeamId = st.SecurityTeamId where l.UserId = '" + userid + "'" + " and l.IsAdmin=0 order by Ad.AssignToId";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }
}