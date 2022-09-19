using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;

public class DBController
{
    public static DBController DB;

    public class cita : Data.cita
    {
        public double Number { get; set; }

        public cita()
        {
        }

        public cita(Data.cita cita, double No)
        {
            Cliente = cita.Cliente;
            Placa_del_Vehiculo = cita.Placa_del_Vehiculo;
            Sucursal = cita.Sucursal;
            Servicio_solicitado = cita.Servicio_solicitado;
            Number = No;
        }
    }

    public class trabajador : Data.G_trabajadores
    {
        public trabajador()
        {
        }

        public trabajador(Data.G_trabajadores trabajador)
        {
            Nombre = trabajador.Nombre;
            Apellidos = trabajador.Apellidos;
            Numero_Cedula = trabajador.Numero_Cedula;
            Fecha_Ingreso = trabajador.Fecha_Ingreso;
            Fecha_Nacimiento = trabajador.Fecha_Nacimiento;
            Edad = trabajador.Edad;
            Password = trabajador.Password;
            Rol = trabajador.Rol;
        }
    }

    public class cliente : Data.G_ClientesVC
    {
        public cliente()
        {
        }

        public cliente(Data.G_clientes cliente)
        {
            Nombre_Completo = cliente.Nombre_Completo;
            Correo_electronico = cliente.Correo_electronico;
            Cedula = cliente.Cedula;
            Direccion_1 = cliente.Direccion_1;
            Direccion_2 = cliente.Direccion_2;
            Telefono_1 = cliente.Telefono_1;
            Telefono_2 = cliente.Telefono_2;
            Usuario = cliente.Usuario;
            byte[] tmp = new byte[] { };
            double No = 0;
            if (Nombre_Completo != null)
            {
                tmp = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Nombre_Completo));
                for (int i = 0; i < tmp.Length; i++)
                {
                    No += tmp[i] * Math.Pow(2, i);
                }
            }

            Password = No.ToString();
        }

        public cliente(Data.G_ClientesVC cliente)
        {
            Nombre_Completo = cliente.Nombre_Completo;
            Correo_electronico = cliente.Correo_electronico;
            Cedula = cliente.Cedula;
            Direccion_1 = cliente.Direccion_1;
            Direccion_2 = cliente.Direccion_2;
            Telefono_1 = cliente.Telefono_1;
            Telefono_2 = cliente.Telefono_2;
            Usuario = cliente.Usuario;
            Password = cliente.Password;
        }
    }

    public class Factura : Data.Consulta_factura
    {
        public Factura()
        {
        }

        public Factura(Data.Consulta_factura factura)
        {
            Cliente = factura.Cliente;
            Numero_de_Factura = factura.Numero_de_Factura;
        }
    }

    /**
     * 
     */
    public DBController.cita[] Citas { get; set; }
    /**
     * 
     */

    public trabajador[] Trabajadores { get; set; }
    /**
     * 
     */

    public cliente[] Clientes { get; set; }
    /**
     * 
     */

    public Factura[] Facturas { get; set; }
    
    /**
     * 
     */
    public DBController(cita[] citas, trabajador[] trabajadores, cliente[] clientes, Factura[] facturas)
    {
        Citas = citas ?? throw new ArgumentNullException(nameof(citas));
        Trabajadores = trabajadores ?? throw new ArgumentNullException(nameof(trabajadores));
        Clientes = clientes ?? throw new ArgumentNullException(nameof(clientes));
        Facturas = facturas ?? throw new ArgumentNullException(nameof(facturas));
        DBController.DB = this;
    }
    /**
     * 
     */
    public DBController()
    {
        Citas = new[] { new cita(new Data.cita(), 1), new cita(new Data.cita(), 2), new cita(new Data.cita(), 3) } ??
                throw new ArgumentNullException(nameof(DBController.Citas));
        Trabajadores =
            new[]
            {
                new trabajador(new Data.G_trabajadores()), new trabajador(new Data.G_trabajadores()),
                new trabajador(new Data.G_trabajadores())
            } ?? throw new ArgumentNullException(nameof(DBController.Trabajadores));
        Clientes = new[]
        {
            new cliente(new Data.G_clientes()), new cliente(new Data.G_clientes()), new cliente(new Data.G_clientes()),
        } ?? throw new ArgumentNullException(nameof(DBController.Clientes));
        Facturas = new[]
        {
            new Factura(new Data.Consulta_factura()), new Factura(new Data.Consulta_factura()),
            new Factura(new Data.Consulta_factura()),
        } ?? throw new ArgumentNullException(nameof(DBController.Facturas));
    }

    /**
     *
     * 
     */
    public static string FoundUser(string name, string pass)
    {
        foreach (trabajador trabajador in DB.Trabajadores)
        {
            if (trabajador.Nombre == name && trabajador.Password == pass)
            {
                return "Trabajador";
            }
        }

        foreach (cliente cliente in DB.Clientes)
        { 
            if (cliente.Usuario == name && cliente.Password == pass)
            {
                return "Cliente";
            }
        }

        return "No Found";
    }

    public static void load()
    {
        var file = File.ReadAllText("./controllers/DB/DB.json");
        var data = JsonSerializer.Deserialize<DBController>(file);

        if (data != null) DB = data;
        return;
    }

    public static void save()
    {
        var file = File.Create("./controllers/DB/DB.json");

        var data = JsonSerializer.Serialize(DB);
        byte[] bytes = new UTF8Encoding(true).GetBytes(data);
        Console.Write(bytes);
        Console.Write(data);
        file.Write(bytes, 0, bytes.Length);
        file.Close();
    }

    public static void init()
    {
        var file = File.Create("./controllers/DB/DB.json");
        DBController controller = new DBController();
        Console.Write(controller);
        Console.Write(controller.Citas.Length);

        var data = JsonSerializer.Serialize(controller);
        byte[] bytes = new UTF8Encoding(true).GetBytes(data);
        Console.Write(bytes);
        Console.Write(data);
        file.Write(bytes, 0, bytes.Length);
        file.Close();
    }
}