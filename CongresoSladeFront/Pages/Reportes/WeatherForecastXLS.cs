using ClosedXML.Excel;

namespace CongresoServer.Pages.Reportes
{
    public class WeatherForecastXLS
    {
        public byte[] Edition(Model.RegistrosViewModel[] data)
        {
            var wb = new XLWorkbook();
            wb.Properties.Author = "the Author";
            wb.Properties.Title = "the Title";
            wb.Properties.Subject = "the Subject";
            wb.Properties.Category = "the Category";
            wb.Properties.Keywords = "the Keywords";
            wb.Properties.Comments = "the Comments";
            wb.Properties.Status = "the Status";
            wb.Properties.LastModifiedBy = "the Last Modified By";
            wb.Properties.Company = "the Company";
            wb.Properties.Manager = "the Manager";

            var ws = wb.Worksheets.Add(data[0].NombreEvento.Substring(0,4));

            ws.Cell(1, 1).Value = "Nombre";
            ws.Cell(1, 2).Value = "Email";
            ws.Cell(1, 3).Value = "Hora Registro";

            // Fill a cell with a date
            //var cellDateTime = ws.Cell(1, 2);
            //cellDateTime.Value = new DateTime(2010, 9, 2);
            //cellDateTime.Style.DateFormat.Format = "yyyy-MMM-dd";

            for (int row = 1; row <= data.Length; row++)
            {
                ws.Cell(row + 1, 1).Value = data[row-1].NombreParticipante;
                ws.Cell(row + 1, 2).Value = data[row-1].Email;
                ws.Cell(row + 1, 3).Value = data[row-1].HoraDeRegistro;
            }

            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        } 
        public byte[] Edition2(Model.RegistrosViewModel[] data)
        {
            var wb = new XLWorkbook();
            wb.Properties.Author = "the Author";
            wb.Properties.Title = "the Title";
            wb.Properties.Subject = "the Subject";
            wb.Properties.Category = "the Category";
            wb.Properties.Keywords = "the Keywords";
            wb.Properties.Comments = "the Comments";
            wb.Properties.Status = "the Status";
            wb.Properties.LastModifiedBy = "the Last Modified By";
            wb.Properties.Company = "the Company";
            wb.Properties.Manager = "the Manager";

            var ws = wb.Worksheets.Add(data[0].NombreEvento.Substring(0,4));

            ws.Cell(1, 1).Value = "Nombre";
            ws.Cell(1, 2).Value = "Registros con asistencias";
            ws.Cell(1, 3).Value = "Registros sin asistencias";

            // Fill a cell with a date
            //var cellDateTime = ws.Cell(1, 2);
            //cellDateTime.Value = new DateTime(2010, 9, 2);
            //cellDateTime.Style.DateFormat.Format = "yyyy-MMM-dd";

            for (int row = 1; row <= data.Length; row++)
            {
                ws.Cell(row + 1, 1).Value = data[row-1].NombreParticipante;
                ws.Cell(row + 1, 2).Value = data[row-1].Email;
                ws.Cell(row + 1, 3).Value = data[row-1].HoraDeRegistro;
            }

            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        }
    }
}
