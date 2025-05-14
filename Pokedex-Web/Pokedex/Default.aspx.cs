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
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> ListaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonServicio servicio = new PokemonServicio();
            ListaPokemon = servicio.listarConSP();

            //Repetidor
            if(!IsPostBack)
            {
                rptRepeater.DataSource = ListaPokemon;
                rptRepeater.DataBind();
            }


        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}