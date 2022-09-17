namespace ASP.NETCoreWebApplication1.Controllers.DB;

public class Data
{
    public class cita
    {
        public cita()
        {
            Cliente = "";
            Placa_del_Vehiculo = null;
            Sucursal = "";
            Servicio_solicitado = "";
        }

        public string? Cliente { get; set; }
        public int? Placa_del_Vehiculo { get; set; }
        public string? Sucursal { get; set; }
        public string? Servicio_solicitado { get; set; }
    }

    public class G_trabajadores
    {
        public G_trabajadores()
        {
            Nombre = "";
            Apellidos = "";
            Numero_Cedula = null;
            Fecha_Ingreso = "";
            Fecha_Nacimiento = "";
            Edad = null;
            Password = "";
            Rol = "";
        }

        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public int? Numero_Cedula { get; set; }
        public string? Fecha_Ingreso { get; set; }
        public string? Fecha_Nacimiento { get; set; }
        public int? Edad { get; set; }
        public string? Password { get; set; }
        public string? Rol { get; set; }
    }

    public class G_clientes
    {
        public G_clientes()
        {
            Nombre_Completo = "";
            Correo_electronico = "";
            Cedula = null;
            Direccion1 = "";
            Direccion2 = "";
            Telefono_1 = null;
            Telefono_2 = null;
            Usuario = "";
        }

        public string? Nombre_Completo { get; set; }

        public int? Cedula { get; set; }
        public string? Correo_electronico { get; set; }
        public string? Direccion1 { get; set; }
        public string? Direccion2 { get; set; }
        public int? Telefono_1 { get; set; }
        public int? Telefono_2 { get; set; }
        public string? Usuario { get; set; }
    }

    public class G_ClientesVC
    {
        public G_ClientesVC()
        {
            Nombre_Completo = "";
            Correo_electronico = "";
            Cedula = null;
            Direccion1 = "";
            Direccion2 = "";
            Telefono_1 = null;
            Telefono_2 = null;
            Usuario = "";
            Password = "";
        }

        public string? Nombre_Completo { get; set; }

        public int? Cedula { get; set; }
        public string? Correo_electronico { get; set; }
        public string? Direccion1 { get; set; }
        public string? Direccion2 { get; set; }
        public int? Telefono_1 { get; set; }
        public int? Telefono_2 { get; set; }
        public string? Usuario { get; set; }

        public string? Password { get; set; }
    }

    public class Consulta_factura
    {
        public Consulta_factura()
        {
            Cliente = "";
            Numero_de_Factura = null;
        }

        public string? Cliente { get; set; }
        public int? Numero_de_Factura { get; set; }
    }

    public class loginUser
    {
        public loginUser()
        {
            Usuario = "";
            Contraseña = "";
        }

        public loginUser(string? contraseña = null, string usuario = null)
        {
            Usuario = usuario;
            Contraseña = contraseña;
        }

        public string? Usuario { get; set; }
        public string? Contraseña { get; set; }
    }
}