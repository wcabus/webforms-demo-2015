using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;

using Munchies.Data;
using Munchies.Data.Repositories;

namespace Munchies
{
    public partial class _Default : Page
    {
        public IAsyncReaderRepository<FoodType> FoodTypeRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.RegisterAsyncTask(new PageAsyncTask(LoadFoodTypes));
            }
        }

        private async Task LoadFoodTypes()
        {
            var foodTypes = await FoodTypeRepository.GetOrderedAsync(orderBy: f => f.Name);

            foodTypes.Insert(0, new FoodType());

            ddlFoodType.DataValueField = "Id";
            ddlFoodType.DataTextField = "Name";
            ddlFoodType.DataSource = foodTypes;

            ddlFoodType.DataBind();
        }

        protected void WhenGoClicked(object sender, EventArgs e)
        {
            //TODO Find food
        }
    }
}