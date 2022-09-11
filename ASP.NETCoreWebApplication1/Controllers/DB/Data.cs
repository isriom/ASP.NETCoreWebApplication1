namespace ASP.NETCoreWebApplication1.Controllers.DB;

public class Data
{
    public class cita
    {
        public string? Cliente { get; set; }
        public int? Placa_del_Vehiculo { get; set; }
        public string? Sucursal { get; set; }
        public string? Servicio_solicitado { get; set; }

        public cita()
        {
            this.Cliente = "";
            this.Placa_del_Vehiculo = null;
            this.Sucursal = "";
            this.Servicio_solicitado = "";
        }
    }
    public class G_trabajadores
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public int? Numero_Cedula { get; set; }
        public string? Fecha_Ingreso { get; set; }
        public string? Fecha_Nacimiento { get; set; }
        public int? Edad { get; set; }
        public string? Password { get; set; }
        public string? Rol { get; set; }

        public G_trabajadores()
        {
            this.Nombre = "";
            this.Apellidos = "";
            this.Numero_Cedula = null;
            this.Fecha_Ingreso = "";
            this.Fecha_Nacimiento = "";
            this.Edad = null;
            this.Password = "";
            this.Rol = "";
        }
    }
    public class G_clientes
    {
        public string? Nombre_Completo { get; set; }
        
        public int? Cedula { get; set; }
        public string? Correo_electronico { get; set; }
        public string? Direccion1 { get; set; }
        public string? Direccion2 { get; set; }
        public int? Telefono_1 { get; set; }
        public int? Telefono_2 { get; set; }
        public string? Usuario { get; set; }

        public G_clientes()
        {
            this.Nombre_Completo = "";
            this.Correo_electronico = "";
            this.Cedula = null;
            this.Direccion1 = "";
            this.Direccion2 = "";
            this.Telefono_1 = null;
            this.Telefono_2 = null;
            this.Usuario = "";
        }
    }
    
    public class G_ClientesVC
    {
        public string? Nombre_Completo { get; set; }
        
        public int? Cedula { get; set; }
        public string? Correo_electronico { get; set; }
        public string? Direccion1 { get; set; }
        public string? Direccion2 { get; set; }
        public int? Telefono_1 { get; set; }
        public int? Telefono_2 { get; set; }
        public string? Usuario { get; set; }
        
        public string? Password { get; set; }

        public G_ClientesVC()
        {
            this.Nombre_Completo = "";
            this.Correo_electronico = "";
            this.Cedula = null;
            this.Direccion1 = "";
            this.Direccion2 = "";
            this.Telefono_1 = null;
            this.Telefono_2 = null;
            this.Usuario = "";
            this.Password = "";
        }
    }

    public class Consulta_factura
    {
        public string? Cliente { get; set; }
        public int? Numero_de_Factura { get; set; }

        public Consulta_factura()
        {
            this.Cliente = "";
            this.Numero_de_Factura = null;
        }

    }

    public class loginUser
    {
        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }

        public loginUser()
        {
            this.Usuario = "";
            this.Contraseña = "";
        }

        public loginUser(string? contraseña = null, string usuario = null)
        {
            this.Usuario = usuario;
            this.Contraseña = contraseña;
        }
    }
}