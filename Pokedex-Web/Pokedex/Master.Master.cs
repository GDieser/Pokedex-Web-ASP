using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Servicio;

namespace Pokedex
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://i.pinimg.com/222x/57/70/f0/5770f01a32c3c53e90ecda61483ccb08.jpg";

            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);
            }

            //if (Seguridad.sesionActiva(Session["trainee"]) && ((Trainee)Session["trainee"]).ImagenPerfil != null)
            if (Seguridad.sesionActiva(Session["trainee"]))
            {
                imgAvatar.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).ImagenPerfil;
            }
            else
            {
                Trainee user = (Trainee)Session["trainee"];
                lblUser.Text = user.Email;
                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}