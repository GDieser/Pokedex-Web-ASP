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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();   
                TraineeServicio servicio = new TraineeServicio();
                EmailServicio email = new EmailServicio();

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                int id = servicio.insertarNuevo(user);

                email.armarCorreo(user.Email, "Bienvenido usuario!", "Te damos la bienvenida!");
                email.enviarEmail();
                Response.Redirect("Default.aspx");

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}