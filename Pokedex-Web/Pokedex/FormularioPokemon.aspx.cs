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
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmarEliminacion = false;
            try
            {
                //Alta
                if (!IsPostBack)
                {
                    ElementoServicio servicio = new ElementoServicio();
                    List<Elemento> lista = servicio.listar();

                    ddlTipo.DataSource = lista;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                }
                //Modificacion
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    PokemonServicio servicio = new PokemonServicio();
                    //List<Pokemon> lista = servicio.listar(id);
                    //Pokemon selec = lista[0];
                    Pokemon selec = (servicio.listar(id))[0];
                    txtNombre.Text = selec.Nombre;
                    txtDescripcion.Text = selec.Descripcion;
                    txtImagenUrl.Text = selec.UrlImagen;
                    txtNumero.Text = selec.Numero.ToString();

                    ddlTipo.SelectedValue = selec.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = selec.Debilidad.Id.ToString();

                    txtImagenUrl_TextChanged(sender, e);

                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonServicio servicio = new PokemonServicio();

                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;

                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    servicio.modificarConSp(nuevo);
                }
                else
                    servicio.agregarConSP(nuevo);

                Response.Redirect("PokemonsLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmar.Checked)
                {
                    PokemonServicio servicio = new PokemonServicio();
                    servicio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("PokemonsLista.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }

}