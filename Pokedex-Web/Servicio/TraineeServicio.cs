using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicio
{
    public class TraineeServicio
    {

        public int insertarNuevo(Trainee nuevo)
        {

			AccesoDatos datos = new AccesoDatos();

			try
			{

				datos.seterarProcedimiento("insertarNuevo");
				datos.setearParametro("@email", nuevo.Email);
				datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();

				
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }



    }
}
