namespace TPLOCAL1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Modelestockage : IValidatableObject
    {
        // Ici, création de classe qui va recevoir les informations entrées dans le formulaire
        // Réception automatique des données à condition que les bons fichiers soient dans les bons dossiers controlers, views, models 
        // Table 1 : Infos personnelles

        [Required(ErrorMessage = "Veuillez remplir le champ Nom")]
        public string nom { get; set; }

        [Required(ErrorMessage = "Veuillez remplir le champ Prénom")]
        public string prenom { get; set; }

        [Required(ErrorMessage = "Veuillez choisir un genre")]
        public string genre { get; set; }

        [Required(ErrorMessage = "Veuillez remplir le champ adresse")]
        [MinLength(5, ErrorMessage = "L'adresse doit contenir au moins 5 caractères")]
        public string adresse { get; set; }

        [Required(ErrorMessage = "Veuillez remplir le code postal")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Code postal invalide")]
            public string codepostal { get; set; }

        [Required(ErrorMessage = "Veuillez choisir une ville")]
        public string ville { get; set; }

        [Required(ErrorMessage = "Veuillez rentrez une adresse mail")]
            public string email { get; set; }

        // Table 2 : Formation suivie
        [Required(ErrorMessage = "Veuillez choisir une date")]
        [DataType(DataType.Date)]
            [Display(Name = "Date de début")]
            public DateTime? dateDebut { get; set; }

        // Méthode pour validation personnalisée pour la dateDebut
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (dateDebut > new DateTime(2021, 1, 1))
            {
                yield return new ValidationResult(
                    "La date de début doit être antérieure au 01/01/2021",
                    new[] { nameof(dateDebut) }
                );
            }

            // Validation conditionnelle : avisCobol requis si formation Cobol
            if (typeFormation == "cobol" && string.IsNullOrWhiteSpace(avisCobol))
            {
                yield return new ValidationResult(
                    "L'avis Cobol est requis pour la formation Cobol",
                    new[] { nameof(avisCobol) }
                );
            }

            //  Validation conditionnelle : avisCsharp requis si formation Objet
            if (typeFormation == "objet" && string.IsNullOrWhiteSpace(avisCsharp))
            {
                yield return new ValidationResult(
                    "L'avis C# est requis pour la formation par objet",
                    new[] { nameof(avisCsharp) }
                );
            }

            //  Validation conditionnelle : avisCsharp requis si formation Objet
            if (typeFormation == "double")
            {
                if (string.IsNullOrWhiteSpace(avisCobol))
                {
                    yield return new ValidationResult(
                        "L'avis Cobol est requis pour la formation à double compétence",
                        new[] { nameof(avisCobol) }
                    );
                }

                if (string.IsNullOrWhiteSpace(avisCsharp))
                {
                    yield return new ValidationResult(
                        "L'avis C# est requis pour la formation à double compétence",
                        new[] { nameof(avisCsharp) }
                    );
                }
            }
        }

        [Required(ErrorMessage = "Veuillez choisir une formation")]
        public string typeFormation { get; set; }

        public string avisCobol { get; set; }

        public string avisCsharp { get; set; }


    }
    
}
