using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ASP.NETCoreWebApplication1.Controllers.DB;

public class DBController
{
    public static DBController DB;

    /**
     * 
     */
    public DBController(cita[] citas, trabajador[] trabajadores, cliente[] clientes, Factura[] facturas)
    {
        Citas = new List<cita>(citas ?? throw new ArgumentNullException(nameof(citas)));
        Trabajadores = new List<trabajador>(trabajadores ?? throw new ArgumentNullException(nameof(trabajadores)));
        Clientes = new List<cliente>(clientes ?? throw new ArgumentNullException(nameof(clientes)));
        Facturas = new List<Factura>(facturas ?? throw new ArgumentNullException(nameof(facturas)));
        DB = this;
    }

    /**
     * 
     */
    public DBController()
    {
        Citas = new List<cita>(
            new[] { new cita(new Data.cita(), 1), new cita(new Data.cita(), 2), new cita(new Data.cita(), 3) } ??
            throw new ArgumentNullException(nameof(Citas)));
        Trabajadores =
            new List<trabajador>(new[]
            {
                new trabajador(new Data.G_trabajadores()), new trabajador(new Data.G_trabajadores()),
                new trabajador(new Data.G_trabajadores())
            } ?? throw new ArgumentNullException(nameof(Trabajadores)));
        Clientes = new List<cliente>(new[]
        {
            new cliente(new Data.G_clientes()), new cliente(new Data.G_clientes()), new cliente(new Data.G_clientes())
        } ?? throw new ArgumentNullException(nameof(Clientes)));
        Facturas = new List<Factura>(new[]
        {
            new Factura(new Data.Consulta_factura()), new Factura(new Data.Consulta_factura()),
            new Factura(new Data.Consulta_factura())
        } ?? throw new ArgumentNullException(nameof(Facturas)));
    }

    /**
     * 
     */
    public List<cita> Citas { get; set; }

    /**
     * 
     */

    public List<trabajador> Trabajadores { get; set; }

    /**
     * 
     */

    public List<cliente> Clientes { get; set; }

    /**
     * 
     */

    public List<Factura> Facturas { get; set; }

    /**
     * 
     */
    public static string FoundUser(string name, string pass)
    {
        Console.Out.Write(pass);
        foreach (var trabajador in DB.Trabajadores)
            if (trabajador.Nombre == name && trabajador.Password == pass)
            {
                Console.Out.Write("trabajador");
                return "Trabajador";
            }

        foreach (var cliente in DB.Clientes)
            if (cliente.Usuario == name && cliente.Password == pass)
            {
                Console.Out.Write("cliente");
                return "Cliente";
            }

        return "No Found";
    }

    public static bool IsOwner(string name, double? Nfactura)
    {
        foreach (var factura in DB.Facturas)
            if (factura.Cliente == name && factura.Numero_de_Factura == Nfactura)
            {
                Console.Out.Write(factura.Cliente);
                return true;
            }

        return false;
    }


    public static void RegistrarCitayFactura(Data.cita cita, double NO)
    {
        AddCita(cita, NO);
        AddFactura(cita, NO);
    }

    public static void AddCita(Data.cita cita, double No)
    {
        DB.Citas.Add(new cita(cita, No));
    }

    public static void AddFactura(Data.cita cita, double No)
    {
        DB.Facturas.Add(new Factura(new Data.Consulta_factura(cita.Cliente, No)));
        save();
    }

    public static void load()
    {
        var file = File.ReadAllText("./controllers/DB/DB.json");
        var data = JsonSerializer.Deserialize<DBController>(file);

        if (data != null) DB = data;
    }

    public static void RegistrarTC(Data.G_clientes c)
    {
        DB.Clientes.Add(new cliente(c));
        save();
    }

    public static void RegistrarCC(Data.G_ClientesVC C)
    {
        DB.Clientes.Add(new cliente(C));
        save();
    }

    public static void RegistrarTT(Data.G_trabajadores T)
    {
        DB.Trabajadores.Add(new trabajador(T));
        Console.Write("Registrado");
        save();
    }


    public static void save()
    {
        var file = File.Create("./controllers/DB/DB.json");

        var data = JsonSerializer.Serialize(DB);
        var bytes = new UTF8Encoding(true).GetBytes(data);
        Console.Write(data);
        file.Write(bytes, 0, bytes.Length);
        file.Close();
    }

    public static void init()
    {
        var file = File.Create("./controllers/DB/DB.json");
        var controller = new DBController();
        Console.Write(controller);
        Console.Write(controller.Citas.Count);

        var data = JsonSerializer.Serialize(controller);
        var bytes = new UTF8Encoding(true).GetBytes(data);
        Console.Write(bytes);
        Console.Write(data);
        file.Write(bytes, 0, bytes.Length);
        file.Close();
    }

    public class cita : Data.cita
    {
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

        public double Number { get; set; }
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
            byte[] tmp = { };
            double No = 0;
            if (Nombre_Completo != null)
            {
                tmp = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Nombre_Completo));
                for (var i = 0; i < tmp.Length; i++) No += tmp[i] * Math.Pow(2, i);
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
}