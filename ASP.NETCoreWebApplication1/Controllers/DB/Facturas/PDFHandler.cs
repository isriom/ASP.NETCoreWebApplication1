using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ASP.NETCoreWebApplication1.Controllers.DB.Facturas;

public class PDFHandler
{
    static public string FacturaCita(Data.cita cita)

    {
        byte[] name;
        double No = 0;
        name = MD5.Create()
            .ComputeHash(Encoding.UTF8.GetBytes(cita.Cliente + cita.Servicio_solicitado + cita.Sucursal));
        for (int i = 0; i < name.Length; i++)
        {
            No += name[i] * Math.Pow(2, i);
        }

        Console.Out.Write(No);

        PdfDocument Factura = new PdfDocument(new PdfWriter("Facturas/F" + No + ".pdf"));
        Document layoutDocument = new Document(Factura);
        //TITULO
        layoutDocument.SetFontSize(38f);
        layoutDocument.Add(new Paragraph("FACTURA No." + No).SetBold().SetTextAlignment(TextAlignment.CENTER));
        //Informacion Cita
        AddClientdata(layoutDocument, cita);
        //Desglose de Servicios
        AddServices(layoutDocument, cita);
        layoutDocument.Close();
        PDFHandler.CreateMetaData(cita,No.ToString());
        return No.ToString();
    }

    public static void AddClientdata(Document layoutDocument, Data.cita cita)
    {
        layoutDocument.SetFontSize(12.5f);
        layoutDocument.Add(new LineSeparator(new SolidLine())).SetBorder(Border.NO_BORDER);

        Table tabla = new Table(4, false);
        tabla.AddCell(new Paragraph("Cliente: "))
            .AddCell(new Paragraph(cita.Cliente));
        tabla.AddCell(new Paragraph("Fecha: "))
            .AddCell(new Paragraph(System.DateTime.Now.ToString("G")));

        tabla.AddCell("Sucursal: ")
            .AddCell(new Paragraph(cita.Sucursal));
        tabla.AddCell(new Paragraph("Mecanico: "));
        if (cita.GetMecanico() == null)
        {
            tabla.AddCell("");
        }
        else
        {
            tabla.AddCell(new Paragraph(cita.GetMecanico()));
        }

        tabla.AddCell(new Paragraph("Vehiculo: "))
            .AddCell(new Paragraph(cita.Placa_del_Vehiculo.ToString()));
        tabla.AddCell(new Paragraph("Rol:"))
            .AddCell(new Paragraph("WIP"));

        tabla.SetWidth(UnitValue.CreatePercentValue(100));

        layoutDocument.Add(new Paragraph("Cita"));
        layoutDocument.Add(new LineSeparator(new DashedLine()));
        RemoveBorder(tabla);
        layoutDocument.Add(tabla).SetBorder(Border.NO_BORDER);
    }

    public static void AddServices(Document layoutDocument, Data.cita cita)
    {
        layoutDocument.SetFontSize(12.5f);
        layoutDocument.Add(new LineSeparator(new SolidLine())).SetBorder(Border.NO_BORDER);

        Table tabla = new Table(3, false);
        tabla.AddCell(new Paragraph("Servicio: "))
            .AddCell(new Paragraph("cantidad"))
            .AddCell(new Paragraph("Precio"));

        tabla.AddCell(new Paragraph(cita.Servicio_solicitado))
            .AddCell(new Paragraph("Place holder"))
            .AddCell(new Paragraph("Place holder"));

        tabla.SetWidth(UnitValue.CreatePercentValue(100));

        layoutDocument.Add(new Paragraph("Desglose"));
        layoutDocument.Add(new LineSeparator(new DashedLine()));
        layoutDocument.Add(tabla);
    }

    public static void RemoveBorder(Table table)
    {
        foreach (var element1 in table.GetChildren())
        {
            var element = (Cell)element1;
            element.SetBorder(Border.NO_BORDER);
        }
    }

    public static void CreateMetaData(Data.cita cita, string No)
    {
        var file = File.Create("./Facturas/Metadata/M" + No + ".json");
        
        var data = JsonSerializer.Serialize(cita);
        byte[] bytes = new UTF8Encoding(true).GetBytes(data);
        Console.Write(bytes);
        Console.Write(data);
        file.Write(bytes,0,bytes.Length);
        file.Close();
    }
}