namespace ASP.NETCoreWebApplication1.Controllers.DB;

public class Data
{
    public class cita
    {
        public string? Cliente { get; set; }
        public int? placa { get; set; }
        public string? sucursal { get; set; }
        public string? servicio { get; set; }

        public cita()
        {
            this.Cliente = "";
            this.placa = null;
            this.sucursal = "";
            this.servicio = "";
        }
    }
    
    public class loginUser
    {
        public string? usuario { get; set; }
        public string? contraseña { get; set; }

        public loginUser()
        {
            this.usuario = "";
            this.contraseña = "";
        }

        public loginUser(string? contraseña = null, string usuario = null)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
        }
    }
}