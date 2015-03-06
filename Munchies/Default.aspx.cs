using System;
using System.Web.UI;

namespace Munchies
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlFoodType.Items.Add("");

                ddlFoodType.Items.Add("cake");
                ddlFoodType.Items.Add("chicken");
                ddlFoodType.Items.Add("chinese food");
                ddlFoodType.Items.Add("indian food");
                ddlFoodType.Items.Add("pie");
                ddlFoodType.Items.Add("pita");
                ddlFoodType.Items.Add("pizza");
                ddlFoodType.Items.Add("sushi");
            }
        }

        protected void WhenGoClicked(object sender, EventArgs e)
        {
            //TODO Find food
        }
    }
}