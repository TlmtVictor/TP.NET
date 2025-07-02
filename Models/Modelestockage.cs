namespace TPLOCAL1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

        public class FormModel
        {
            // Ici, création de classe qui va recevoir les informations entrées dans le formulaire
            // Réception automatique des données à condition que les bons fichiers soient dans les bons dossiers controlers, views, models 
            // Table 1 : Infos personnelles
            [Required]
            public string nom { get; set; }

            [Required]
            public string prenom { get; set; }

            [Required]
            public string genre { get; set; }

            public string adresse { get; set; }

            [RegularExpression(@"^\d{5}$", ErrorMessage = "Code postal invalide")]
            public string codepostal { get; set; }

            public string ville { get; set; }

            [Required, EmailAddress]
            public string email { get; set; }

            // Table 2 : Formation suivie
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date de début")]
            public DateTime dateDebut { get; set; }

            [Required(ErrorMessage = "Veuillez sélectionner une formation")]
            public string typeFormation { get; set; }

            // Table 3 : Avis de formation
            [Required(ErrorMessage = "L'avis Cobol est requis")]
            public string avisCobol { get; set; }

            [Required(ErrorMessage = "L'avis C# est requis")]
            public string avisCsharp { get; set; }
        }
    
}
