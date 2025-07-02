using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;


//This file is not to be modified
namespace TPLOCAL1.Models
{
    public class OpinionList
    {
        /// <summary>
        /// Function that alow to recover the opinions list inside an xml file
        /// </summary>
        /// <param name="file">file path</param>
        public List<Opinion> GetAvis(string file)
        {
            // instantiating empty list
            List<Opinion> opinionList = new List<Opinion>();

            // Creation of an XMLDocument object that alow to recover datas from the file
            XmlDocument xmlDoc = new XmlDocument();
            // Reading of the file thank to a StreamReader file
            StreamReader streamDoc = new StreamReader(file);
            string dataXml = streamDoc.ReadToEnd();
            // Loading data in the XmlDocument
            xmlDoc.LoadXml(dataXml);

            // Retrieve the nodes, convert them to the "Avis" object, and add them to the "OpinionList" list.
            // Loop through each XmlNode node with the path "root/row" (see xml file structure)
            // The SelectNodes method retrieves all nodes with the specified path.
            var nodes = xmlDoc.SelectNodes("root/row");
            if (nodes != null)
            {
                // Safely get the InnerText of the <LastName> element from the current XML node.
                // The null-conditional operator ?. prevents a NullReferenceException if the element is missing.
                // If null, default to an empty string.
                foreach (XmlNode node in nodes)
                {
                    // Safely get the InnerText of the <FirstName> element from the current XML node.
                    // Uses the same null-checking and default as above.
                    string LastName = node["LastName"]?.InnerText ?? "";
                    string FirstName = node["FirstName"]?.InnerText ?? "";
                    string OpinionGiven = node["OpinionGiven"]?.InnerText ?? "";

                    // Create a new Opinion object, initializing its properties
                    // with the values extracted from the current XML node.
                    Opinion opinion = new Opinion
                    {
                        LastName = LastName,
                        FirstName = FirstName,
                        OpinionGiven = OpinionGiven
                    };

                    opinionList.Add(opinion);
                }
            }

            // Returning the list formed by processing to the calling method.
            return opinionList;
        }
    }

    // .: Info :.
    // This class can be extracted to a new C# page, but for the sake of this exercise, it can be left in the same page.
    // It's best to avoid having multiple classes inside the same page as it can complicate code readability and maintenance in the long run.
    /// <summary>
    /// Object that groups data related to reviews
    /// \nCan be modified
    /// </summary>
    public class Opinion
    {
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Review given (Possible values: O or N)
        /// </summary>
        public string OpinionGiven { get; set; } = string.Empty;
    }
}
