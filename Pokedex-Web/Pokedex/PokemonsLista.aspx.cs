using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicio;

namespace Pokedex
{
    public partial class PokemonsLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonServicio servicio = new PokemonServicio();

            dgvPokemon.DataSource = servicio.listarConSP();
            dgvPokemon.DataBind();

        }
    }
}