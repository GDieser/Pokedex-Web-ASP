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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Trainee trainee = Session["trainee"] != null ? (Trainee)Session["trainee"] : null;
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeServicio servicio = new TraineeServicio();

                //escribir
                /*
                string ruta = Server.MapPath("./Images/");
                Trainee user = (Trainee)Session["trainee"];
                txtImagen.PostedFile.SaveAs(ruta + "image-" + user.Id + ".jpg");*/
                Trainee user = (Trainee)Session["trainee"];

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.ImagenPerfil = "image-" + user.Id + ".jpg";
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                servicio.Actualizar(user);


                //leer img
                //Image img = (Image)Master.FindControl("imgAvatar");
                //img.ImageUrl = "~//Images/" + user.ImagenPerfil;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}