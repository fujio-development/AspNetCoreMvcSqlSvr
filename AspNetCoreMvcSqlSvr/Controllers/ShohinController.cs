using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcSqlSvr.Controllers
{
    public class ShohinController : Controller
    {
        // GET: /Syohin/(※Index省略可)
        // コントローラー名のControllerを除いたアドレス/ となる。
        // URLルーティングロジックは、Startup.csのConfigureメソッドで設定。
        public IActionResult Index()
        {
            return View();
        }

        //public string Index()
        //{
        //    return "これは私のデフォルトの動作です...";
        //}


        // GET: /Syohin/Welcome?name=xxx&numTimes=x
        // コントローラー名のControllerを除いたアドレス/このメソッド名/パラメータ となる。
        // URLルーティングロジックは、Startup.csのConfigureメソッドで設定。
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            // URLのクエリ文字列からディクショナリオブジェクトを経由しViewへ渡す。※マッピングは自動で行う。
            ViewData["Message"] = "こんにちは " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        // GET: /Shohin/Welcome/
        // System.Text.Encodings.Webを使用する必要があります。
        // コントローラー名のControllerを除いたアドレス/このメソッド名/パラメータ となる。
        // URLルーティングロジックは、Startup.csのConfigureメソッドで設定。
        //public string Welcome(string name, int numTimes = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"こんにちは {name}, NumTimesは: {numTimes}");
        //}

        //public string Welcome()
        //{
        //    // 戻り値をstringとし、文字列をダイレクトで返しページに表示している。
        //    return "これはようこそアクションメソッドです...";
        //}
    }
}