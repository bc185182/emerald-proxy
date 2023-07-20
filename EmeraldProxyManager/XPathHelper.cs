using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace EmeraldProxyManager
{
    public static class XPathHelper
    {
        public static string PerformOperations(string fileContent, List<Operation> Operations)
        {
            //var currentServiceOperations = Operations.Where(o => o.ServiceName == ServiceName);
            var xDocument = XDocument.Parse(fileContent);
            foreach (var operation in Operations)
            {
                fileContent = ReplaceXPathValuesAccordingToService(xDocument, operation);
            }

            return fileContent;
        }

        private static string ReplaceXPathValuesAccordingToService(XDocument xDocument, Operation operation)
        {
            UpdateValueInRequest(xDocument, operation.XPath, operation.Content, operation.OperationType);
            return xDocument.ToString();
        }

        private static void UpdateValueInRequest(XDocument xDocument, string xPath, string value, OperationType operationType)
        {
            if (value == null)
                return;

            try
            {
                UpdateElements(xDocument, xPath, value, operationType);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        private static void UpdateElements(XDocument xDocument, string xPath, string value, OperationType operationType)
        {
            if (xDocument.Root == null) return;

            IEnumerable<XElement> xElements =
                from node in
                    xDocument.XPathSelectElements(xPath, GetNamespaceResolver(xDocument.Root.ToString()))
                select node;

            foreach (var xElement in xElements)
            {
                
                ////  When the DateTime is Min DateTime do not update it
                //if (xElement.Value == "0001-01-01T00:00:00")
                //    continue;

                //if (xElement.Value.StartsWith("{") && xElement.Value.EndsWith("}"))
                //    value = xElement.Value;

                if (operationType == OperationType.UpdateValue)
                    xElement.Value = value;

                if (operationType == OperationType.AddNode)
                {
                    
                    var document = XDocument.Parse(value);
                    var newElement = document.Root;

                    XNamespace ns = xElement.GetDefaultNamespace();

                    foreach (XElement el in newElement.DescendantsAndSelf())
                    {
                        el.Name = ns.GetName(el.Name.LocalName);
                        List<XAttribute> atList = el.Attributes().ToList();
                        el.Attributes().Remove();
                        foreach (XAttribute at in atList)
                            el.Add(new XAttribute(ns.GetName(at.Name.LocalName), at.Value));
                    }


                    xElement.Add(newElement);
                }
            }
        }

        private static IXmlNamespaceResolver GetNamespaceResolver(string text)
        {
            XmlNameTable nameTable = new NameTable();
            var namespaceManager = new XmlNamespaceManager(nameTable);


            if (text.Contains("www.nrf-arts.org"))
                namespaceManager.AddNamespace("arts", "http://www.nrf-arts.org/IXRetail/namespace/");

            if (text.Contains("retalix.com/R10/services"))
                namespaceManager.AddNamespace("r10", "http://retalix.com/R10/services");

            if (text.Contains("Retalix_Extension"))
                namespaceManager.AddNamespace("uri", "uri:Retalix_Extension");

            if (text.Contains("www.Retalix.com/Extensions"))
                namespaceManager.AddNamespace("ext", "http://www.Retalix.com/Extensions");

            return namespaceManager;
        }

        public static string FindXPath(string fileContent, string nodeToSearch, string nameSpace = "/arts:")
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(fileContent);

            var xPath = FindXPath(xml.ChildNodes, nodeToSearch, "", nameSpace);

            return xPath;
        }

        private static string FindXPath(XmlNodeList xmlNodeList, string selectedText, string xPath, string nameSpace = "/arts:")
        {
            var innerChildNodeNameSpace = nameSpace;
            foreach (XmlNode childNode in xmlNodeList)
            {
                if (childNode.Attributes != null && childNode.Attributes["xmlns"] != null)
                {
                    nameSpace = GetNamespace(childNode.Attributes["xmlns"].Value);
                    innerChildNodeNameSpace = nameSpace;
                }

                if (childNode.Name == selectedText)
                    return xPath + nameSpace + childNode.Name;

                else if (childNode.ChildNodes.Count > 0)
                {
                    foreach (XmlNode innerChildNode in childNode.ChildNodes)
                    {
                        if (innerChildNode.Attributes != null && innerChildNode.Attributes["xmlns"] != null)
                            innerChildNodeNameSpace = GetNamespace(innerChildNode.Attributes["xmlns"].Value);

                        if (innerChildNode.Name == selectedText)
                            return xPath + nameSpace + childNode.Name + innerChildNodeNameSpace + innerChildNode.Name;

                        var possiblexPath = FindXPath(innerChildNode.ChildNodes, selectedText, xPath + nameSpace + childNode.Name + innerChildNodeNameSpace + innerChildNode.Name, innerChildNodeNameSpace);
                        if (possiblexPath != "")
                            return possiblexPath;
                    }
                }
                //else
                //    return "";
            }

            return "";
        }

        private static string GetNamespace(string value)
        {
            if (value == "http://www.nrf-arts.org/IXRetail/namespace/")
                return "/arts:";

            if (value == "http://retalix.com/R10/services")
                return "/r10:";

            if (value == "uri:Retalix_Extension")
                return "/uri:";

            if (value == "http://www.Retalix.com/Extensions")
                return "/ext:";


            return "/";
        }
    }
}
