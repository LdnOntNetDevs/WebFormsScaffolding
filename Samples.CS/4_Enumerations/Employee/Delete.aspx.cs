﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Samples.Enumerations;
using Samples.Models;

namespace Samples._4_Enumerations.Employee
{
    public partial class Delete : System.Web.UI.Page
    {
		protected Samples.Models.ApplicationDbContext _db = new Samples.Models.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected Employee item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(Guid Id)
        {
            using (_db)
            {
                var item = _db.Employees.Find(Id);

                if (item != null)
                {
                    _db.Employees.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single Employee item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public Samples.Enumerations.Employee GetItem([FriendlyUrlSegmentsAttribute(0)]Guid? Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Employees.Where(m => m.Id == Id).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}

