using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AdvanceSoftware.VBReport;  // 名前空間を追記

namespace src.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Index()
        {
            // インスタンスを生成
            using (CellReport cellReport1 = new CellReport())
            {
                // 帳票作成処理
                cellReport1.Report.Start();
                cellReport1.Report.Create(ExcelVersion.ver2021);
                cellReport1.Page.Start("Sheet1", "1-9999");
                cellReport1.Cell("A1").Value = "VB-Report11をWebアプリに組み込みWindows Server 2022にデプロイする";
                cellReport1.Page.End();
                cellReport1.Report.End();
                // SVGZ 形式で帳票ドキュメントを取得します。
                string reportDocument = cellReport1.Report.GetSvgzReport(SvgSaveType.IncludeExcelPdf);
                ViewData["document"] = reportDocument;
            }

            return View();
        }
    }
}
