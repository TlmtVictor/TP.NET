using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;


//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{


    public class HomeController : Controller     // héritage de la classe controller qu icontient pleins de fonctions utiles
                                                 // on s'en sert pour créer la class que l'on va utiliser
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "Listedavis":
                        string path = Path.Combine(_env.ContentRootPath, "XmlFile", "DataAvis.xml"); // chemin vers fichier XML

                        OpinionList opinionListService = new OpinionList();
                        var avisList = opinionListService.GetAvis(path);
                        return View("Listedavis", avisList);

                    case "Formulaire":
                        //TODO : call the Form view with data model empty
                        return View(id);

                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        // méthode pour aller chercher les données du fichier XML
        private readonly IWebHostEnvironment _env;   // chemin
        public HomeController(IWebHostEnvironment env)  // chemin
        {
            _env = env;
        }

        //methode to send datas from form to validation page
        [HttpPost]

        // ici création d'une méthode ValidationFormulaire avec (nom de classe + paramètre qui réçoit les données)
        public ActionResult ValidationFormulaire(Modelestockage model)
        {
            ModelState.Remove("avisCsharp");
            ModelState.Remove("avisCobol");

            if (ModelState.IsValid)
            {
                // Traite les données reçues dans model
                return View("Validation", model);
            }
            else
            {
                // Revenir au formulaire si les données sont invalides
                return View("Formulaire", model);
            }

        }
    }

}
