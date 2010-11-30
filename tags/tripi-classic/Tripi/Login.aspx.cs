using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void AutenticateUser(object sender, AuthenticateEventArgs e)
    {
        string login = this.LoginCtrl.UserName;
        string password = this.LoginCtrl.Password;

        e.Authenticated = UserCredentialsValid(login, password);
    }

    private bool UserCredentialsValid(string login, string password)
    {
        TripiWCF.ClientMockup.Proxy.TripServiceClient service =
            new TripiWCF.ClientMockup.Proxy.TripServiceClient("TripiStaro");

        string result = service.LoginUser(login, password);
        return result != string.Empty;
    }
}
