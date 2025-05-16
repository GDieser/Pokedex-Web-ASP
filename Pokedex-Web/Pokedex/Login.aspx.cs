using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;
using Dominio;

namespace Pokedex
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeServicio servicio = new TraineeServicio();   
            try
            {

                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;

                if(servicio.Login(trainee))
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Datos incorrectos");
                    Response.Redirect("Error.aspx");
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}