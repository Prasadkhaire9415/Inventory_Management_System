using InventoryManagementSystem1.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

public class AccountController : Controller
{
    // GET: Account/Login
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (ValidateUser(model.Username, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("Index", "Dashboard");
            }
            ModelState.AddModelError("", "Invalid username or password.");
        }

        return View(model);
    }

    public ActionResult Logout()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Login", "Account");
    }

    // GET: Account/Register
    public ActionResult Register()
    {
        return View();
    }

    // POST: Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (Register(model.Username, model.Password)) // method 
            {
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("", "Registration failed.");
        }
        return View(model);
    }

    private bool ValidateUser(string username, string password)
    {
        bool isValid = false;

        using (SqlConnection conn = new SqlConnection("Data Source=PRASAD\\SQLEXPRESS;Initial Catalog=InventoryManagementSystem;Integrated Security=True;"))
        {
            string query = "SELECT COUNT(*) FROM login WHERE Username = @Username AND Password = @Password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password); // Hash password for comparison

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            if (count == 1)
            {
                isValid = true;
            }
        }

        return isValid;
    }

    private bool Register(string username, string password)
    {
        bool isRegistered = false;

        // Define your connection string
        string connectionString = "Data Source=PRASAD\\SQLEXPRESS;Initial Catalog=InventoryManagementSystem;Integrated Security=True;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // Corrected SQL query
            string query = "INSERT INTO Login (Username, Password) VALUES (@Username, @Password)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // Hash password before storing

                // Open connection
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                isRegistered = rowsAffected > 0;
            }
        }

        return isRegistered;
    }
   
}
