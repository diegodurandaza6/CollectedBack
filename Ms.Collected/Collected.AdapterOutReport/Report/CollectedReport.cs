
using Collected.Domain.IPortsOut;
using Microsoft.Reporting.NETCore;
using System.Data;
using System.Reflection;
using System.Text;

namespace Collected.AdapterOutReport.Report
{
    public class CollectedReport : ICollectedReport
    {
        public byte[] GetReport(DataTable data)
        {
            return Generate(data);
        }

        private static byte[] Generate(DataTable data)
        {
            string reportName = "GeneralCollected";
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Collected.AdapterOutReport.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}Rdlc\\{1}.rdlc", fileDirPath, reportName);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");

            byte[]? bytes = null;

            using (LocalReport report = new())
            {
                report.EnableExternalImages = true;
                report.ReportPath = rdlcFilePath;
                ReportDataSource dataSourceVirtual = new()
                {
                    Name = "CollectedDataSet",
                    Value = data
                };
                report.DataSources.Add(dataSourceVirtual);

                string encoding = string.Empty;
                string mimeType = string.Empty;
                string extension = string.Empty;

                bytes = report.Render("PDF", null, out mimeType, out encoding, out extension, out string[] streamids, out Warning[] warningss);
            }
            return bytes;
        }
    }
}
