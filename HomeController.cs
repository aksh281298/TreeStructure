using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TreeStructure.Models;

namespace TreeStructure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DBCtx _context { get; }

        public HomeController(ILogger<HomeController> logger, DBCtx context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            foreach (ParentType type in _context.ParentTypes)
            {
                nodes.Add(new TreeViewNode { Id = type.parentId.ToString(), Parent = "#", Text = type.parentName });
            }
            foreach (ParentSubType subtype in _context.ParentSubTypes)
            {
                nodes.Add(new TreeViewNode { Id = subtype.parentNodeId.ToString() + "-" + subtype.nodeId.ToString(), Parent = subtype.parentNodeId.ToString(), Text = subtype.nodeName });
            }
            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View();
        }

        [HttpPost]
        public IActionResult Index(string selectedItems)
        {
            List<TreeViewNode> items = JsonConvert.DeserializeObject<List<TreeViewNode>>(selectedItems);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}