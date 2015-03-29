using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Munchies.Admin
{
    public partial class Code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                // Do Admin Stuff
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
}