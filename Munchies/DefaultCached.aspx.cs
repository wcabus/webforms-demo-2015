using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.UI;

using Munchies.Data;
using Munchies.Data.Queries;

namespace Munchies
{
    public partial class DefaultCached : Page
    {
        public IGetFoodTypesQuery GetFoodTypesQuery { get; set; }
        public IFindRestaurantQuery FindRestaurantQuery { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.RegisterAsyncTask(new PageAsyncTask(LoadFoodTypes));
                txtPostalCode.Attributes.Add("data-init", "true"); // Triggers the client-side geolocation script.
            }
            else
            {
                txtPostalCode.Attributes.Remove("data-init");
            }
        }

        private async Task LoadFoodTypes()
        {
            var foodTypes = Cache["FoodTypes"] as IList<FoodType>;
            if (foodTypes == null)
            {
                foodTypes = (await GetFoodTypesQuery.ExecuteAsync()).ToList();
                foodTypes.Insert(0, new FoodType());

                Cache.Add("FoodTypes", foodTypes, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.Normal, null);
            }

            ddlFoodType.DataValueField = "Id";
            ddlFoodType.DataTextField = "Name";
            ddlFoodType.DataSource = foodTypes;

            ddlFoodType.DataBind();
        }

        protected void WhenGoClicked(object sender, EventArgs e)
        {
            lblErrors.Text = "";

            // Find all restaurants near me that offer the selected type of food (or all types if nothing has been selected)
            string postalCode = txtPostalCode.Text;
            if (string.IsNullOrEmpty(postalCode))
            {
                lblErrors.Text = "Please enter a postal code";
                txtPostalCode.Focus();
                return;
            }

            try
            {
                var data = FindRestaurantQuery.Execute(postalCode, GetSelectedFoodType());

                lstResults.Visible = true;
                lstResults.DataSource = data;
                lstResults.DataBind();
            }
            catch
            {
                // Log the error, ...
            }
        }

        private int? GetSelectedFoodType()
        {
            var selValue = ddlFoodType.SelectedValue;
            if (string.IsNullOrEmpty(selValue))
            {
                return null;
            }

            int parsedValue;
            if (!int.TryParse(selValue, out parsedValue))
            {
                return null;
            }

            return parsedValue;
        }
    }
}